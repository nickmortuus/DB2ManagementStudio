using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2ManagementStudio
{
    public partial class QueryWindow : UserControl
    {
        List<ProtectedKeyword> keywords = new List<ProtectedKeyword>();
        public string saveLoc = "";
        public int windowID = 0;
        public string lastSaveText = "";
        public string currentText = "";
        public string systemToQuery = "";
        public bool saved = false;
        public DataTable lastQueryTable = null;
        public QueryWindow()
        {
            InitializeComponent();
            LoadProtectedKeywords();
        }

        private void UpdateDataGrid(DataTable table)
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Columns.Clear();
            //int colCount = table.Columns.Count;

            // add headers
            /*for (int p = 0; p < colCount; p++)
            {
                dataGridView1.Columns.Add(table.Columns[p].ColumnName, table.Columns[p].ColumnName);
            }*/

            BindingSource SBind = new BindingSource();
            SBind.DataSource = table;
            dataGridView1.DataSource = table;
            dataGridView1.DataSource = SBind;
            dataGridView1.Refresh();

            /*for (int i = 0; i < table.Rows.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView1);

                for (int x = 0; x < colCount; x++)
                {
                    string colHeader = table.Columns[x].ColumnName;
                    newRow.Cells[x].Value = table.Rows[i][colHeader].ToString();
                }

                dataGridView1.Rows.Add(newRow);
            }*/
        }

        private void RunSelectedQuery()
        {
            if (richTextBox1.Text == "" || richTextBox1.SelectedText == "")
            {
                MessageBox.Show("There isn't a selected query in the query window!");
            }
            else
            {
                DataTable dt = SQLLink.grabIbmData(richTextBox1.SelectedText.Trim(), systemToQuery);

                lastQueryTable = dt;
                if (dt.Rows.Count > 0)
                {
                    UpdateDataGrid(dt);
                }
            }
        }

        private async Task ColorText(string word, Color wordColor)
        {
            /*int index = 0;
            
            index = richTextBox1.Find("select", index + word.Length - 1, richTextBox1.TextLength, RichTextBoxFinds.None);

            richTextBox1.SelectionStart = index;
            richTextBox1.SelectionLength = 6;
            richTextBox1.SelectionColor = wordColor;
            richTextBox1.DeselectAll();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.Focus();
            richTextBox1.ForeColor = Color.Black;*/
        }

        private void LoadProtectedKeywords()
        {
            ProtectedKeyword kw1 = new ProtectedKeyword();
            kw1.keyword = "select";
            kw1.myColor = Color.Blue;
            keywords.Add(kw1);
        }

        private void Intellisense()
        {
            foreach (ProtectedKeyword kw in keywords)
            {
                ColorText(kw.keyword, kw.myColor);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Intellisense();
            currentText = richTextBox1.Text;
            if (currentText != lastSaveText)
            {
                saved = false;
            }
        }

        private void QueryWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSelectedQuery();
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSelectedQuery();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSelectedQuery();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        public void LoadSQLFile(string text, string fileLocation)
        {
            richTextBox1.Text = text;
            saved = true;
            lastSaveText = text;
            saveLoc = fileLocation;
        }

        private void excelFilexlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void excelFilexlsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExcelFile myFile;
            DataTable tableToExport = lastQueryTable;

            if (tableToExport == null || tableToExport.Rows.Count <= 0)
            {
                // do nothing
                MessageBox.Show("No query or data available!");
            }
            else
            {
                List<string> headersForExcelFile = new List<string>();
                foreach (DataColumn col in tableToExport.Columns)
                {
                    headersForExcelFile.Add(col.ColumnName);
                }
                myFile = new ExcelFile(headersForExcelFile.Count);
                myFile.AddHeaders(headersForExcelFile);

                // add data to file
                foreach (DataRow dr in tableToExport.Rows)
                {
                    ExcelRecord rcd = new ExcelRecord(headersForExcelFile.Count);
                    for (int i = 0; i < headersForExcelFile.Count; i++)
                    {
                        rcd.record[i] = dr[i].ToString();
                    }
                    myFile.AddRecord(rcd);
                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                    string path = Path.GetDirectoryName(saveFileDialog1.FileName) + @"\";
                    ExcelFileCreator.saveExcelFile(myFile, file, path);
                }

            }
        }

        private void textFiletxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tableToExport = lastQueryTable;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            string textToSave = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && tableToExport != null)
            {
                string file = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                string path = Path.GetDirectoryName(saveFileDialog1.FileName) + @"\";
                foreach (DataColumn col in tableToExport.Columns)
                {
                    textToSave += col.ColumnName.Trim() + ",";
                }
                //Break headers from data
                textToSave += Environment.NewLine;

                foreach (DataRow dr in tableToExport.Rows)
                {
                    for (int i = 0; i < tableToExport.Columns.Count; i++)
                    {
                        textToSave += dr[i].ToString().Trim() + ",";
                    }
                    textToSave += Environment.NewLine;
                }

                File.WriteAllText(saveFileDialog1.FileName, textToSave);
            }
        }

        private void cSVFilecsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable tableToExport = lastQueryTable;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            string textToSave = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK && tableToExport != null)
            {
                string file = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                string path = Path.GetDirectoryName(saveFileDialog1.FileName) + @"\";
                foreach (DataColumn col in tableToExport.Columns)
                {
                    textToSave += col.ColumnName.Trim() + ",";
                }
                //Break headers from data
                textToSave += Environment.NewLine;

                foreach (DataRow dr in tableToExport.Rows)
                {
                    for (int i = 0; i < tableToExport.Columns.Count; i++)
                    {
                        textToSave += dr[i].ToString().Trim() + ",";
                    }
                    textToSave += Environment.NewLine;
                }

                File.WriteAllText(saveFileDialog1.FileName, textToSave);
            }
        }

        private void richTextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RunSelectedQuery();
            }
        }
    }
}
