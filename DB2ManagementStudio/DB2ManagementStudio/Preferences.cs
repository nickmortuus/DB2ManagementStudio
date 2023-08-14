using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB2ManagementStudio
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Theme = comboBox1.Text.Trim();
            Properties.Settings.Default.Save();
            Form1.theme = comboBox1.Text.Trim();
            this.Close();
        }
    }
}
