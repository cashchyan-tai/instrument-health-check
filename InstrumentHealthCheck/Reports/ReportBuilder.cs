using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NReco.PdfGenerator;
using InstrumentHealthCheck.Config;
using InstrumentHealthCheck.Results;
// IDUTInstrument/SignalGenerator/SpectrumAnalyzer live in InstrumentCore.dll but keep
// their original "Pegatron" namespace so the existing Pegatron app didn't need any code
// changes when they were extracted into the shared library.
using Pegatron;

namespace InstrumentHealthCheck.Reports
{
    public static class ReportBuilder
    {
        public static string GenerateHtml(
            IDUTInstrument dut,
            DutRoleType role,
            SignalGenerator refSg,
            SpectrumAnalyzer refSa,
            PortDefinition port,
            bool useSwitch,
            string calibrationFileName,
            List<TestResultRow> results,
            DateTime testDate)
        {
            string dutRoleLabel = role == DutRoleType.SignalAnalyzer
                ? "Spectrum/Signal Analyzer (待測 DUT)"
                : "Signal Generator (待測 DUT)";
            string refRoleLabel = role == DutRoleType.SignalAnalyzer
                ? "Signal Generator (對打參考)"
                : "Spectrum Analyzer (對打參考)";

            string refVendor = role == DutRoleType.SignalAnalyzer ? refSg?.Vendor : refSa?.Vendor;
            string refModel = role == DutRoleType.SignalAnalyzer ? refSg?.Model : refSa?.Model;
            string refSn = role == DutRoleType.SignalAnalyzer ? refSg?.SN : refSa?.SN;

            int totalPass = results.Count(r => r.Pass);

            var sb = new StringBuilder();
            sb.Append("<!DOCTYPE html><html><head><meta charset='utf-8'/><title>Instrument Health Check</title><style>")
              .Append(".equipmentTbl { border:1px solid black; border-collapse: collapse; text-align:left; padding-left:10px; padding-right:10px; }")
              .Append(".resultTbl { border:1px solid black; border-collapse: collapse; text-align:center; padding-left:10px; padding-right:10px; }")
              .Append("</style></head><body>");

            sb.Append("<h1 style='color:gray;'>Instrument Health Check Report</h1>");
            sb.AppendFormat("<p>Test Date: {0}</p>", testDate.ToString("dd-MM-yyyy HH:mm:ss"));
            sb.AppendFormat("<p><b>{0}</b> tests were done, <b>{1}</b> passed.</p>", results.Count, totalPass);

            sb.Append("<h3 style='color:orange;'>Equipment Used</h3>");
            sb.Append("<table class='equipmentTbl' style='width:100%;'>");
            sb.Append("<tr bgcolor='orange' style='color:white;'>" +
                "<th class='equipmentTbl'>Role</th><th class='equipmentTbl'>Vendor</th>" +
                "<th class='equipmentTbl'>Model</th><th class='equipmentTbl'>Serial Number</th></tr>");
            sb.AppendFormat("<tr><td class='equipmentTbl'>{0}</td><td class='equipmentTbl'>{1}</td><td class='equipmentTbl'>{2}</td><td class='equipmentTbl'>{3}</td></tr>",
                dutRoleLabel, dut?.Vendor, dut?.Model, dut?.SN);
            sb.AppendFormat("<tr><td class='equipmentTbl'>{0}</td><td class='equipmentTbl'>{1}</td><td class='equipmentTbl'>{2}</td><td class='equipmentTbl'>{3}</td></tr>",
                refRoleLabel, refVendor, refModel, refSn);
            sb.Append("</table>");

            sb.Append("<p>");
            sb.AppendFormat("Port: <b>{0}</b>{1}<br/>",
                port?.Name,
                useSwitch ? string.Format(" (Switch Port {0})", port.PhysicalPortNumber) : " (直接接線，無 Switch)");
            sb.AppendFormat("Calibration file: <b>{0}</b>",
                string.IsNullOrEmpty(calibrationFileName) ? "未使用 (0 dB)" : calibrationFileName);
            sb.Append("</p>");

            sb.Append("<h3 style='color:orange;'>Results</h3>");
            sb.Append("<table class='resultTbl' style='width:100%;'>");
            sb.Append("<tr bgcolor='orange' style='color:white;'>" +
                "<th class='resultTbl'>Frequency (MHz)</th>" +
                "<th class='resultTbl'>Expected (dBm)</th>" +
                "<th class='resultTbl'>Measured (dBm)</th>" +
                "<th class='resultTbl'>Error (dB)</th>" +
                "<th class='resultTbl'>Pass/Fail</th>" +
                "<th class='resultTbl'>Remarks</th></tr>");

            foreach (TestResultRow r in results)
            {
                bool hasError = !string.IsNullOrEmpty(r.Note);
                string measured = hasError ? "-" : r.MeasuredDbm.ToString("0.00");
                string error = hasError ? "-" : r.ErrorDb.ToString("0.00");
                string pf = r.Pass ? "<b style='color:green;'>P</b>" : "<b style='color:red;'>F</b>";

                sb.AppendFormat(
                    "<tr><td class='resultTbl'>{0}</td><td class='resultTbl'>{1}</td><td class='resultTbl'>{2}</td>" +
                    "<td class='resultTbl'>{3}</td><td class='resultTbl'>{4}</td><td class='resultTbl'>{5}</td></tr>",
                    r.FrequencyMHz, r.ExpectedDbm.ToString("0.00"), measured, error, pf, r.Note);
            }

            sb.Append("</table></body></html>");
            return sb.ToString();
        }

        public static string SaveReport(string html, string dutModel, DateTime dt)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string safeModel = string.IsNullOrWhiteSpace(dutModel) ? "NoDUT" :
                new string(dutModel.Trim().Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c).ToArray());

            string fullPath = Path.Combine(folder, safeModel + "_" + dt.ToString("yyyyMMdd_HHmmss") + ".pdf");

            var pdfConverter = new HtmlToPdfConverter
            {
                PdfToolPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wkhtmltopdf")
            };
            byte[] pdfBytes = pdfConverter.GeneratePdf(html);
            File.WriteAllBytes(fullPath, pdfBytes);

            return fullPath;
        }
    }
}
