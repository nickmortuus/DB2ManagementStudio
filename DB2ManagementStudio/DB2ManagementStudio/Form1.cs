using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DB2ManagementStudio
{
    public partial class Form1 : Form
    {
        List<ProtectedKeyword> keywords = new List<ProtectedKeyword>();
        List<QueryWindow> windows = new List<QueryWindow>();
        private int globalIDList = 0;
        public static string theme = Properties.Settings.Default.Theme;
        private string currentTheme = Properties.Settings.Default.Theme;
        public static string outputData = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateDataGrid(DataTable table)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // RunSelectedQuery();
            }
        }

        private void LoadProtectedKeywords()
        {
            ProtectedKeyword kw1 = new ProtectedKeyword();
            kw1.keyword = "select";
            kw1.myColor = Color.Blue;
            keywords.Add(kw1);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProtectedKeywords();
            AddQueryWindow("DataConnection1");
            LoadLibraryList();
            ChangeTheme(theme);
        }

        private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void newQueryWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddQueryWindow("DataConnection1");
        }

        private void AddQueryWindow(string connection)
        {
            TabPage newTab = new TabPage();
            newTab.Text = "DB2Query.sql - " + connection;
            QueryWindow qw = new QueryWindow();
            newTab.Controls.Add(qw);
            qw.Dock = DockStyle.Fill;

            if (windows.Count <= 0)
            {
                qw.windowID = globalIDList;
            }
            else
            {
                qw.windowID = globalIDList + 1;
            }

            qw.systemToQuery = connection;
            windows.Add(qw);
            tabControl1.TabPages.Add(newTab);
        }

        private void AddQueryWindow(string text, string tabName, string connection, string file)
        {
            TabPage newTab = new TabPage();
            newTab.Text = tabName + $"- {connection}";
            QueryWindow qw = new QueryWindow();
            newTab.Controls.Add(qw);
            qw.Dock = DockStyle.Fill;

            if (windows.Count <= 0)
            {
                qw.windowID = globalIDList;
            }
            else
            {
                qw.windowID = globalIDList + 1;
            }

            qw.systemToQuery = connection;
            qw.LoadSQLFile(text, file);
            windows.Add(qw);
            tabControl1.TabPages.Add(newTab);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddQueryWindow("DataConnection1");
        }

        private void saveQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSQLFile();
        }

        public void SaveSQLFile()
        {
            saveFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            int qwWindowID = tabControl1.SelectedIndex;
            string queryText = windows[qwWindowID].currentText;

            if (windows[qwWindowID].saveLoc == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    File.WriteAllText(saveFileDialog1.FileName, queryText);
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = Path.GetFileName(saveFileDialog1.FileName) + windows[qwWindowID].systemToQuery;
                    // update last save text
                    windows[qwWindowID].lastSaveText = queryText;
                    windows[qwWindowID].saveLoc = saveFileDialog1.FileName;
                }
            }
            else
            {
                File.WriteAllText(windows[qwWindowID].saveLoc, queryText);
                // update last save text
                windows[qwWindowID].lastSaveText = queryText;
            }

        }

        public void OpenSQLFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = openFileDialog.FileName;
                AddQueryWindow(File.ReadAllText(file), Path.GetFileName(file), "DataConnection1", file);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (windows[tabControl1.SelectedIndex].saved == false)
            {
                DialogResult result = MessageBox.Show($"Do you want save changes to {tabControl1.TabPages[tabControl1.SelectedIndex].Text}", "File Not Saved!", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveSQLFile();
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
                else
                {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void openQueryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSQLFile();
        }

        private async Task LoadLibraryList()
        {
            DataTable dt = LibraryLoader.LoadLibrary("DataConnection1");

            if (dt != null && dt.Rows.Count > 0)
            {
                treeView1.Nodes[0].Nodes.Add("ITSFILE");
                int myNode = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    // 2 Node tables
                    treeView1.Nodes[0].Nodes[0].Nodes.Add(dr["TABLE_NAME"].ToString());
                    DataTable tableData = LibraryLoader.GetTableData(dr["TABLE_NAME"].ToString(), "ITSFILE", "DataConnection1");
                    foreach(DataRow row in tableData.Rows)
                    {
                        string charType = LibraryLoader.FindDataType(row["Data_Type"].ToString());
                        string charAmt = LibraryLoader.FindDataLength(charType, row);
                        treeView1.Nodes[0].Nodes[0].Nodes[myNode].Nodes.Add($"{row["Column_Name"].ToString()} ({charType}({charAmt}), null) ");
                    }
                    myNode++;
                }
            }

            DataTable dt2 = LibraryLoader.LoadLibrary("DataConnection1");

            if (dt2 != null && dt2.Rows.Count > 0)
            {
                treeView1.Nodes[1].Nodes.Add("ITSFILE");
                int myNode = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    // 1 Node
                    treeView1.Nodes[1].Nodes[0].Nodes.Add(dr["TABLE_NAME"].ToString());
                    DataTable tableData = LibraryLoader.GetTableData(dr["TABLE_NAME"].ToString(), "ITSFILE", "DataConnection1");
                    foreach (DataRow row in tableData.Rows)
                    {
                        string charType = LibraryLoader.FindDataType(row["Data_Type"].ToString());
                        string charAmt = LibraryLoader.FindDataLength(charType, row);
                        treeView1.Nodes[0].Nodes[0].Nodes[myNode].Nodes.Add($"{row["Column_Name"].ToString()} ({charType}({charAmt}), null) ");
                    }
                    myNode++;
                }
            }
        }


        private void selectTop1000RowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
              AddQueryWindow($"SELECT * FROM {treeView1.SelectedNode.Parent.Text}.{treeView1.SelectedNode.Text} FETCH FIRST 1000 ROWS ONLY", "DB2Query.sql", treeView1.SelectedNode.Parent.Parent.Text, "");
            }
        }      

        private void excelFilexlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Nodes.Clear();
            treeView1.Nodes[1].Nodes.Clear();
            LoadLibraryList();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences frm = new Preferences();
            frm.Show();
        }

        private void ChangeTheme(string theme)
        {
            if(theme == "Normal")
            {
                toolStrip1.BackColor = SystemColors.Control;
                menuStrip1.BackColor = SystemColors.Control;
                statusStrip1.BackColor = SystemColors.Control;
            }
            else
            {
                // dark theme
                toolStrip1.BackColor = SystemColors.ControlDark;
                menuStrip1.BackColor = SystemColors.ControlDark;
                statusStrip1.BackColor = SystemColors.ControlDark;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(theme != currentTheme)
            {
                ChangeTheme(theme);
                currentTheme = theme;
            }
            if (outputData != null && outputData != "")
            {
               textBox1.Text = outputData;
            }
        }

        private void conn_1_newQueryMenuItem_Click(object sender, EventArgs e)
        {
            AddQueryWindow("DataConnection1");
        }
    }
}
