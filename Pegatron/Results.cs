using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using NReco.PdfGenerator;
using System.Xml;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using System.Collections;

namespace Pegatron
{
    public class Results
    {
        private static bool isDebug = false;
        public static void createReport(System.Data.DataTable resultTable, TestData testData, IDUTInstrument dut, SignalGenerator SG, SpectrumAnalyzer SA, PowerSensor PS, ISwitchBox Sw, DateTime dt, int totalPass, TimeSpan testDuration, bool isStopped, bool isdebug)
        {
            isDebug = isdebug;

            try
            {
                if (string.IsNullOrEmpty(dut.Model))
                    dut.Model = "NoDUT";

                string instrType = "Trial Run";
                if (dut.Model.ToUpper().Contains("IQXEL"))
                    instrType = "Wireless Test System";

                string resultStr = string.Format(" has completed all the test. <b>{0}</b> tests were done and <b>{1}</b> of them passed.", resultTable.Rows.Count, totalPass);
                if (isStopped)
                    resultStr = " testing has been stopped abruptly and did not finish the full test.";

                string htmlStr =
                    @"<!DOCTYPE html>" +
                    "<html>" +
                    "<style>" +
                        ".equipmentTbl { border:1px solid black; border-collapse: collapse; text-align: left; padding-left: 10px; padding-right: 10px; }" +
                        ".resultTbl { border:1px solid black; border-collapse: collapse; text-align: center; padding-left: 10px; padding-right: 10px; }" +
                    "</style>" +

                    "<head>" +
                        "<meta charset='utf-8' />" +
                        "<title>" + dut.Model + "</title>" +
                    "</head>" +

                    "<header>" +
                        "<h1 style='color:gray;'>" + dut.Vendor + " " + dut.Model + "</h1>" +
                    "</header>" +

                    "<body>" +
                    "<table style='width:100%; border:0px;'>" +
                        "<tr style='color:orange;'>" +
                            "<th>Instrument Type</th>" +
                            "<th>Serial Number</th>" +
                            "<th>Model Number</th>" +
                            "<th>Test Date</th>" +
                        "</tr>" +
                        "<tr style='text-align: center;' >" +
                            "<td>" + instrType + "</td>" +
                            "<td>" + dut.SN + "</td>" +
                            "<td>" + dut.Model + "</td>" +
                            "<td>" + dt.ToString("dd-MM-yyyy") + "</td>" +
                        "</tr>" +
                    "</table>" +
                    "<br>" +

                    "<h3><b style='color:orange;'>Accuracy Acceptance Limit</b></h3>" +
                    "<u>VSG High Power Accuracy (≥ -50 dBm )</u>" +
                    "<p>400-3800 MHz: ± " + testData.VSGHighPowerAccuracy.LowFreqLimit + " dB</p>" +
                    "<p>3801-7300 MHz: ± " + testData.VSGHighPowerAccuracy.HighFreqLimit + " dB</p>" +
                    "<u>VSG Low Power Accuracy (-100 to -50 dBm )</u>" +
                    "<p>400-3800 MHz: ± " + testData.VSGLowPowerAccuracy.LowFreqLimit + " dB</p>" +
                    "<p>3801-7300 MHz: ± " + testData.VSGLowPowerAccuracy.HighFreqLimit + " dB</p>" +
                    "<u>VSA Power Accuracy</u>" +
                    "<p>400-3800 MHz: ± " + testData.VSAPowerAccuracy.LowFreqLimit + " dB</p>" +
                    "<p>3801-7300 MHz: ± " + testData.VSAPowerAccuracy.HighFreqLimit + " dB</p>" +
                    "<u>Frequency Accuracy</u>" +
                    "<p>± " + testData.FrequencyAccuracy.FreqLimit + " ppm</p>" +
                    "<br>" +

                    "<h3><b style='color:orange;'>Results</b></h3>" +
                    "<p>Your " + dut.Model + resultStr + " Total test duration was " + testDuration.Minutes.ToString("00") + "minutes " + testDuration.Seconds.ToString("00") + "." + testDuration.Milliseconds.ToString("000") + "seconds.</p>" +
                    "<br>" +

                    "<h3><b style='color:orange;'>Equipment Used to Verify the Test System</b></h3>" +
                    "<table class='equipmentTbl'>" +
                        "<tr bgcolor='orange' style='color:white;'>" +
                            "<th class='equipmentTbl'>Description</th>" +
                            "<th class='equipmentTbl'>Model</th>" +
                            "<th class='equipmentTbl'>Serial Number</th>" +
                            "<th class='equipmentTbl'>Manufacturer</th>" +
                        "</tr>" +
                        "<tr>" +
                            "<td class='equipmentTbl'>Signal Generator</td>" +
                            "<td class='equipmentTbl'>" + SG.Model + "</td>" +
                            "<td class='equipmentTbl'>" + SG.SN + "</td>" +
                            "<td class='equipmentTbl'>" + SG.Vendor + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td class='equipmentTbl'>Spectrum Analyzer</td>" +
                            "<td class='equipmentTbl'>" + SA.Model + "</td>" +
                            "<td class='equipmentTbl'>" + SA.SN + "</td>" +
                            "<td class='equipmentTbl'>" + SA.Vendor + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td class='equipmentTbl'>Power Sensor</td>" +
                            "<td class='equipmentTbl'>" + PS.Model + "</td>" +
                            "<td class='equipmentTbl'>" + PS.SN + "</td>" +
                            "<td class='equipmentTbl'>" + PS.Vendor + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td class='equipmentTbl'>Switch Box</td>" +
                            "<td class='equipmentTbl'>" + Sw.Model + "</td>" +
                            "<td class='equipmentTbl'>" + Sw.SN + "</td>" +
                            "<td class='equipmentTbl'>" + Sw.Vendor + "</td>" +
                        "</tr>" +
                    "</table>" +
                    "<p style='page-break-after: always;'>&nbsp;</p>" +

                    "<header>" +
                        "<h2 style='color:orange;'>Calibration Results and Additional Details</h2>" +
                    "</header>";

                int testIndexCount = 1;
                string testName = "";
                string portName = "";
                string frequencyValue = "";
                bool isFirstPort = false;

                if (resultTable.Rows.Count > 0)
                {
                    foreach (DataRow row in resultTable.Rows)
                    {
                        if (testName != row[0].ToString() && !string.IsNullOrEmpty(row[0].ToString()))
                        {
                            isFirstPort = true;
                            portName = "";

                            if (testIndexCount != 1)//Close previous loop table tag before start(first table does not have a previous tag to close)
                                htmlStr +=
                                    "</table>" +
                                    "<p style='page-break-after: always;'>&nbsp;</p>";

                            testName = row[0].ToString();
                            htmlStr += string.Format("<h3>{0}. {1}</h3>", testIndexCount, testName);

                            testIndexCount++;
                        }
                        else
                            isFirstPort = false;

                        string[] arrPortFreq = row[1].ToString().Split(',');

                        if (portName != arrPortFreq[0])
                        {
                            portName = arrPortFreq[0];
                            frequencyValue = "";

                            if (!isFirstPort)//Close previous loop table tag before start(first table does not have a previous tag to close)
                                htmlStr +=
                                    "</table>" +
                                    "<p style='page-break-before: always;'>&nbsp;</p>";

                            htmlStr +=
                                string.Format("<table class='resultTbl' style='width:100%; '>" +
                                    "<tr>" +
                                        "<th class='resultTbl'>" + portName + " Port</th>" +
                                        "<th class='resultTbl'></th><th class='resultTbl'></th><th class='resultTbl'></th><th class='resultTbl'></th>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<th class='resultTbl'></th><th class='resultTbl'></th><th class='resultTbl'></th><th class='resultTbl'></th><th class='resultTbl'></th>" +
                                    "</tr>" +
                                    "<tr>" +
                                        "<th class='resultTbl'>Frequency<br>MHz</th>" +
                                        "<th class='resultTbl'>Reference Value<br>dBm</th>" +
                                        "<th class='resultTbl'>Measured Value<br>{0}</th>" +
                                        "<th class='resultTbl'>Accuracy<br>{1}</th>" +
                                        "<th class='resultTbl'>Pass/Fail</th>" +
                                    "</tr>", testName == "Frequency Accuracy" ? "MHz" : "dBm", testName == "Frequency Accuracy" ? "ppm" : "dB");
                        }

                        string writtenFreq = arrPortFreq[1];
                        if (frequencyValue != writtenFreq)
                        {
                            frequencyValue = arrPortFreq[1];
                            writtenFreq = arrPortFreq[1];
                        }
                        else
                            writtenFreq = "";

                        string resultPF = "";
                        if (row[5].ToString() == "P")//Pass/Fail column text color
                            resultPF = "<b style='color:green;'>P</b>";
                        else
                            resultPF = "<b style='color:red;'>F</b>";

                        htmlStr += string.Format(
                            "<tr>" +
                                "<td class='resultTbl'>{0}</td>" +
                                "<td class='resultTbl'>{1}</td>" +
                                "<td class='resultTbl'>{2}</td>" +
                                "<td class='resultTbl'>{3}</td>" +
                                "<td class='resultTbl'>{4}</td>" +
                            "</tr>"
                            , writtenFreq, row[2], row[3], row[4], resultPF);
                    }

                }

                htmlStr +=
                    "</table>" +
                    "<p style='page-break-after: always;'>&nbsp;</p>" +

                    "<h3 style='color:orange;'>Explanation</h3>" +
                    "<p>This report is only valid for the tester being tested. The report cannot be selectively copied (if you want to copy, you should copy the whole report).</p>" +
                    "<br>" +

                    "<h3 style='color:orange;'>Functions of Error Calculation</h3>" +
                    "<p>Error of Power Level (dB) = Result of DUT - Standard Value</p>" +
                    "<p>Frequency Error (ppm) = 1,000,000 X (Result of DUT - Standard Value) / Standard Value</p>" +

                    "</body>" +
                    "</html>";

                string sfolderName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
                if (!Directory.Exists(sfolderName)) Directory.CreateDirectory(sfolderName);

                string safeModel = string.IsNullOrWhiteSpace(dut.Model) ? "NoDUT" :
                    new string(dut.Model.Trim().Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c).ToArray());
                if (string.IsNullOrWhiteSpace(safeModel)) safeModel = "NoDUT";

                string fullPath = Path.Combine(sfolderName, safeModel + "_" + dt.ToString("yyyyMMdd_HHmmss"));

                var pdfConverter = new HtmlToPdfConverter();
                pdfConverter.PdfToolPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wkhtmltopdf");
                var pdfBytes = pdfConverter.GeneratePdf(htmlStr);
                using (var pdfFile = new FileStream(fullPath + ".pdf", FileMode.OpenOrCreate, FileAccess.Write))
                    pdfFile.Write(pdfBytes, 0, pdfBytes.Length);

                ConvertHtmlToDocx(htmlStr, fullPath + ".docx");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:\n " + ex.ToString(), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ConvertHtmlToDocx(string htmlContent, string outputFilePath)
        {
            try
            {
                // Create the Word document file at the specified path.
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(outputFilePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {
                    // Add a main document part.
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();
                    mainPart.Document.Append(body);

                    // Create an HtmlConverter object to convert the HTML to OpenXML elements.
                    HtmlConverter converter = new HtmlConverter(mainPart);

                    // Split HTML content into parts to handle the page breaks manually.
                    string[] htmlParts = htmlContent.Split(new[] { "<p style='page-break-after: always;'>&nbsp;</p>" }, System.StringSplitOptions.None);

                    // Convert each part and append to the document, adding page breaks in between.
                    for (int i = 0; i < htmlParts.Length; i++)
                    {
                        var paragraphs = converter.Parse(htmlParts[i]);

                        foreach (var paragraph in paragraphs)
                        {
                            body.Append(paragraph);
                        }

                        // If it's not the last part, insert a page break.
                        if (i < htmlParts.Length - 1)
                        {
                            AddPageBreak(body);
                        }
                    }

                    // After all content and page breaks are processed, apply borders and width to tables.
                    ApplyBordersAndWidthToTables(body, htmlContent);

                    // Save the document.
                    mainPart.Document.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n " + ex.ToString(), ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to insert a page break.
        private static void AddPageBreak(Body body)
        {
            Paragraph paragraph = new Paragraph(new Run(new Break() { Type = BreakValues.Page }));
            body.Append(paragraph);
        }

        // Method to apply borders and width to all tables in the document body.
        private static void ApplyBordersAndWidthToTables(Body body, string htmlContent)
        {
            // Find all tables in the document body.
            var tables = body.Elements<Table>();

            // Regular expression to extract the width from the HTML style attribute.
            Regex widthRegex = new Regex(@"width\s*:\s*(\d+)%", RegexOptions.IgnoreCase);

            foreach (var table in tables)
            {
                // Create table border properties.
                TableProperties tblProperties = table.GetFirstChild<TableProperties>();
                if (tblProperties == null)
                {
                    tblProperties = new TableProperties();
                    table.InsertAt(tblProperties, 0);
                }

                // Apply table borders.
                TableBorders tableBorders = new TableBorders(
                    new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                    new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 }
                );
                tblProperties.TableBorders = tableBorders;

                // Find the corresponding HTML for the table to check the style attribute for width.
                string tableHtml = htmlContent.ToLower().Contains("<table") ? htmlContent.ToLower().Split(new[] { "<table" }, System.StringSplitOptions.None)[1] : null;
                if (tableHtml != null)
                {
                    Match widthMatch = widthRegex.Match(tableHtml);
                    if (widthMatch.Success)
                    {
                        // Convert width percentage to OpenXML's table width (1/50th of a percent units).
                        int widthPercent = int.Parse(widthMatch.Groups[1].Value);
                        TableWidth tblWidth = new TableWidth() { Type = TableWidthUnitValues.Pct, Width = (widthPercent * 50).ToString() };
                        tblProperties.TableWidth = tblWidth;
                    }
                }
            }
        }

        //public static void CreateResults(System.Data.DataTable resultTable, TestData testData, DUT dut, SignalGenerator SG, SpectrumAnalyzer SA, PowerSensor PS, Switch Sw, DateTime dt, int totalPass, TimeSpan testDuration, bool isStopped)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(dut.Model))
        //            dut.Model = "NoDUT";

        //        string instrType = "Trial Run";
        //        if (dut.Model != "NoDut")
        //            instrType = "Wireless Test System";

        //        string resultStr = string.Format(" has completed all the test. <b>{0}</b> tests were done and <b>{1}</b> of them passed.", resultTable.Rows.Count, totalPass);
        //        if (isStopped)
        //            resultStr = " testing has been stopped abruptly and did not finish the full test.";

        //        const string nl = "\n";
        //        string csvStr = "";
        //        csvStr += dut.Vendor + " " + dut.Model + nl + nl;
        //        csvStr += "Instrument Type,,Serial Number,,Model Number,,Test Date\n";
        //        csvStr += instrType + ",," + dut.SN + ",," + dut.Model + ",," + dt.ToString("dd-MM-yyyy") + nl + nl;
        //        csvStr += "Accuracy Acceptance Limit\n";
        //        csvStr += "VSG High Power Accuracy (>-50 dBm)\n";
        //        csvStr += " 400-3800 MHz: ±" + testData.VSGHighPowerAccuracy.LowFreqLimit + "dB\n";
        //        csvStr += "3801-7300 MHz: ±" + testData.VSGHighPowerAccuracy.HighFreqLimit + "dB\n";
        //        csvStr += "VSG Low Power Accuracy (-100 to -50 dBm)\n";
        //        csvStr += " 400-3800 MHz: ±" + testData.VSGLowPowerAccuracy.LowFreqLimit + "dB\n";
        //        csvStr += "3801-7300 MHz: ±" + testData.VSGLowPowerAccuracy.HighFreqLimit + "dB\n";
        //        csvStr += "VSA Power Accuracy\n";
        //        csvStr += " 400-3800 MHz: ±" + testData.VSAPowerAccuracy.LowFreqLimit + "dB\n";
        //        csvStr += "3801-7300 MHz: ±" + testData.VSAPowerAccuracy.HighFreqLimit + "dB\n";
        //        csvStr += "Frequency Accuracy\n";
        //        csvStr += testData.VSGLowPowerAccuracy.FreqLimit + "ppm\n\n";
        //        csvStr += "Results\n";
        //        csvStr += "Your " + dut.Model + resultStr + " Total test duration was " + testDuration.Minutes.ToString("00") + "minutes " + testDuration.Seconds.ToString("00") + "." + testDuration.Milliseconds.ToString("000") + "seconds.\n\n";
        //        csvStr += "Equipment used to Verify the Test System\n";
        //        //Equipment details
        //        csvStr += "Date:" + dt.ToString("dd/MM/yyyy HH:mm:ss");
        //        csvStr += "Equipment,Manufacturer,Model,Serial Number";
        //        //csvStr += "Signal Generator,{0},{1},{2}", SG.Vendor, SG.Model, SG.SN;
        //        //csvStr += "Spectrum Analyzer,{0},{1},{2}", SA.Vendor, SA.Model, SA.SN;
        //        //csvStr += "Switch LAN Hub,{0},{1},{2}", Sw.Vendor, Sw.Model, Sw.SN;

        //        //oOutWriter.WriteLine();//next line

        //        //oOutWriter.WriteLine(string.Format("Test,Settings,Reference Value (dBm),Measured Value (dBm),Accuracy,Pass/Fail,Duration (minutes:seconds.milliseconds)")); //header title


        //        string sfolderName = @".\\Results";
        //        if (new DirectoryInfo(sfolderName).Exists == false) { new DirectoryInfo(sfolderName).Create(); }

        //        FileStream oOutFStream = new FileStream(sfolderName + "\\" + dut.Model + "_" + dt.ToString("ddMMyyyy_HHmmss") + ".csv", FileMode.OpenOrCreate, FileAccess.Write);
        //        StreamWriter oOutWriter = new StreamWriter(oOutFStream);

        //        oOutWriter.WriteLine();//next line

        //        oOutWriter.Close();
        //        oOutFStream.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error creating result CSV file.\nError: " + ex.Message, "Creating result file fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    try
        //    {
        //        FileStream oOutFStream = new FileStream("", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        //        StreamWriter oOutWriter = new StreamWriter(oOutFStream);

        //        string sDuration = testDuration.Minutes.ToString("00") + ":" + testDuration.Seconds.ToString("00") + "." + testDuration.Milliseconds.ToString("000");

        //        //if (isLastLine)
        //        //    oOutWriter.WriteLine("Total test duration is " + sDuration);
        //        //else
        //        //    if (isStopped)
        //        //    oOutWriter.WriteLine("Testing was stopped abruptly at this point. Total test duration is " + sDuration);
        //        //else
        //        //oOutWriter.WriteLine(string.Format("{0},\"{1}\",{2},{3},{4},{5},=\"{6}\"", row[0], row[1], row[2], row[3], row[4], row[5], sDuration));

        //        oOutWriter.Close();
        //        oOutFStream.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error writing result CSV file.\nError: " + ex.Message, "Creating result file fail");
        //    }
        //}

        //public static string CreateResults(DUT dut, SignalGenerator SG, SpectrumAnalyzer SA, LanSwitch Sw, DateTime date)
        //{
        //    try
        //    {
        //        string sfolderName = @".\\Results";
        //        if (new DirectoryInfo(sfolderName).Exists == false) { new DirectoryInfo(sfolderName).Create(); }

        //        DateTime oNowTime = DateTime.Now;
        //        string sDate = date.ToString("yyyyMMdd_HHmmss");
        //        string sFileName = string.Format(sfolderName + "\\Calibration_{0}.csv", sDate);

        //        FileStream oOutFStream = new FileStream(@sFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        //        StreamWriter oOutWriter = new StreamWriter(oOutFStream);

        //        //Equipment details
        //        oOutWriter.WriteLine("Date:,{0}", date.ToString("dd/MM/yyyy HH:mm:ss"));
        //        oOutWriter.WriteLine("Equipment,Manufacturer,Model,Serial Number");
        //        oOutWriter.WriteLine("DUT,{0},{1},{2}", dut.Vendor, dut.Model, dut.SN);
        //        oOutWriter.WriteLine("Signal Generator,{0},{1},{2}", SG.Vendor, SG.Model, SG.SN);
        //        oOutWriter.WriteLine("Spectrum Analyzer,{0},{1},{2}", SA.Vendor, SA.Model, SA.SN);
        //        oOutWriter.WriteLine("Switch LAN Hub,{0},{1},{2}", Sw.Vendor, Sw.Model, Sw.SN);

        //        oOutWriter.WriteLine();//next line

        //        oOutWriter.WriteLine(string.Format("Test,Settings,Reference Value (dBm),Measured Value (dBm),Accuracy,Pass/Fail,Duration (minutes:seconds.milliseconds)")); //header title

        //        oOutWriter.Close();
        //        oOutFStream.Close();

        //        return sFileName;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error creating result CSV file.\nError: " + ex.Message, "Creating result file fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return "";
        //    }
        //}

        //public static bool WriteResult(string fileName, TimeSpan testDuration, bool isLastLine, bool isStopped = false, DataRow row = null)
        //{
        //    startWrite:
        //    try
        //    {
        //        FileStream oOutFStream = new FileStream(@fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        //        StreamWriter oOutWriter = new StreamWriter(oOutFStream);

        //        string sDuration = testDuration.Minutes.ToString("00") + ":" + testDuration.Seconds.ToString("00") + "." + testDuration.Milliseconds.ToString("000");

        //        if (isLastLine)
        //            oOutWriter.WriteLine("Total test duration is " + sDuration);
        //        else
        //            if (isStopped)
        //            oOutWriter.WriteLine("Testing was stopped abruptly at this point. Total test duration is " + sDuration);
        //        else
        //            oOutWriter.WriteLine(string.Format("{0},\"{1}\",{2},{3},{4},{5},=\"{6}\"", row[0], row[1], row[2], row[3], row[4], row[5], sDuration));

        //        oOutWriter.Close();
        //        oOutFStream.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (isStopped || isLastLine)
        //            return false;

        //        DialogResult result = MessageBox.Show("Error writing result CSV file.\nError: " + ex.Message, "Creating result file fail", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        //        if (result == DialogResult.Abort)
        //            return false;
        //        else if (result == DialogResult.Ignore)
        //            return true;
        //        else//Retry
        //            goto startWrite;
        //    }
        //}
    }
}
