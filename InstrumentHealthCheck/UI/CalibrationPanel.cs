using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InstrumentHealthCheck.Config;

namespace InstrumentHealthCheck.UI
{
    public partial class CalibrationPanel : UserControl
    {
        private List<PortDefinition> _ports = new List<PortDefinition> { new PortDefinition("Direct", 1) };
        private CalibrationSet _calSet = new CalibrationSet();
        private string _loadedPath;

        public CalibrationPanel()
        {
            InitializeComponent();
            RebuildColumns(dgvSgToDut);
            RebuildColumns(dgvDutToSa);
        }

        public CalibrationSet CalibrationData => _calSet;
        public string LoadedFilePath => _loadedPath;

        // Called whenever the Port/Switch tab's port list may have changed, so the grid
        // columns (one per port) stay in sync. Existing data is keyed by port position,
        // so it survives even if a port gets renamed elsewhere.
        public void SyncPorts(List<PortDefinition> ports)
        {
            _ports = ports;
            RebuildColumns(dgvSgToDut);
            RebuildColumns(dgvDutToSa);
            RefreshRows(dgvSgToDut, _calSet.ReferenceToDut);
            RefreshRows(dgvDutToSa, _calSet.DutToReference);
        }

        private void RebuildColumns(DataGridView grid)
        {
            grid.Columns.Clear();
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFreq",
                HeaderText = "頻率 (MHz)",
                Width = 110
            });

            for (int i = 0; i < _ports.Count; i++)
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colPort" + i,
                    HeaderText = _ports[i].Name + " (dB)",
                    Width = 100
                });
            }
        }

        private void RefreshRows(DataGridView grid, CalibrationTable table)
        {
            grid.Rows.Clear();
            foreach (CalibrationPoint point in table.Points.OrderBy(p => p.FrequencyMHz))
            {
                int rowIndex = grid.Rows.Add();
                DataGridViewRow row = grid.Rows[rowIndex];
                row.Tag = point;
                row.Cells[0].Value = point.FrequencyMHz;

                for (int i = 0; i < _ports.Count; i++)
                {
                    double loss = i < point.LossDbPerPort.Count ? point.LossDbPerPort[i] : 0;
                    row.Cells[i + 1].Value = loss;
                }
            }
        }

        private void SyncRowToPoint(DataGridView grid, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= grid.Rows.Count) return;

            DataGridViewRow row = grid.Rows[rowIndex];
            if (!(row.Tag is CalibrationPoint point)) return;

            point.FrequencyMHz = ParseCell(row.Cells[0].Value);
            point.LossDbPerPort.Clear();
            for (int i = 0; i < _ports.Count; i++)
                point.LossDbPerPort.Add(ParseCell(row.Cells[i + 1].Value));
        }

        private static double ParseCell(object value)
        {
            double.TryParse(value?.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double result);
            return result;
        }

        private void AddRow(DataGridView grid, CalibrationTable table)
        {
            var point = new CalibrationPoint();
            for (int i = 0; i < _ports.Count; i++)
                point.LossDbPerPort.Add(0);

            table.Points.Add(point);
            RefreshRows(grid, table);
        }

        private void RemoveSelectedRow(DataGridView grid, CalibrationTable table)
        {
            if (grid.CurrentRow == null) return;
            if (grid.CurrentRow.Tag is CalibrationPoint point)
                table.Points.Remove(point);

            RefreshRows(grid, table);
        }

        private void btnAddRowSg_Click(object sender, EventArgs e) => AddRow(dgvSgToDut, _calSet.ReferenceToDut);
        private void btnRemoveRowSg_Click(object sender, EventArgs e) => RemoveSelectedRow(dgvSgToDut, _calSet.ReferenceToDut);
        private void btnAddRowSa_Click(object sender, EventArgs e) => AddRow(dgvDutToSa, _calSet.DutToReference);
        private void btnRemoveRowSa_Click(object sender, EventArgs e) => RemoveSelectedRow(dgvDutToSa, _calSet.DutToReference);

        private void dgvSgToDut_CellEndEdit(object sender, DataGridViewCellEventArgs e) => SyncRowToPoint(dgvSgToDut, e.RowIndex);
        private void dgvDutToSa_CellEndEdit(object sender, DataGridViewCellEventArgs e) => SyncRowToPoint(dgvDutToSa, e.RowIndex);

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "校正檔 (*.csv)|*.csv|所有檔案 (*.*)|*.*" })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    _calSet = CalibrationFile.Load(dlg.FileName);
                    _loadedPath = dlg.FileName;
                    lblFile.Text = Path.GetFileName(_loadedPath);
                    RefreshRows(dgvSgToDut, _calSet.ReferenceToDut);
                    RefreshRows(dgvDutToSa, _calSet.DutToReference);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取校正檔失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog
            {
                Filter = "校正檔 (*.csv)|*.csv",
                FileName = _loadedPath != null ? Path.GetFileName(_loadedPath) : "Calibration.csv"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    List<string> portNames = _ports.Select(p => p.Name).ToList();
                    CalibrationFile.Save(dlg.FileName, _calSet, portNames);
                    _loadedPath = dlg.FileName;
                    lblFile.Text = Path.GetFileName(_loadedPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存校正檔失敗：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要清空目前的校正資料嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            _calSet = new CalibrationSet();
            _loadedPath = null;
            lblFile.Text = "尚未載入校正檔";
            RefreshRows(dgvSgToDut, _calSet.ReferenceToDut);
            RefreshRows(dgvDutToSa, _calSet.DutToReference);
        }
    }
}
