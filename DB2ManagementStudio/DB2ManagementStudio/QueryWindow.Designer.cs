namespace DB2ManagementStudio
{
    partial class QueryWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exportMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelFilexlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFiletxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVFilecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.exportMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(921, 622);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(103, 76);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(99, 6);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.exportMenu;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(921, 311);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // exportMenu
            // 
            this.exportMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportDataToolStripMenuItem});
            this.exportMenu.Name = "exportMenu";
            this.exportMenu.Size = new System.Drawing.Size(136, 26);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelFilexlsToolStripMenuItem,
            this.textFiletxtToolStripMenuItem,
            this.cSVFilecsvToolStripMenuItem});
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            // 
            // excelFilexlsToolStripMenuItem
            // 
            this.excelFilexlsToolStripMenuItem.Name = "excelFilexlsToolStripMenuItem";
            this.excelFilexlsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.excelFilexlsToolStripMenuItem.Text = "Excel File (.xlsx)";
            this.excelFilexlsToolStripMenuItem.Click += new System.EventHandler(this.excelFilexlsToolStripMenuItem_Click_1);
            // 
            // textFiletxtToolStripMenuItem
            // 
            this.textFiletxtToolStripMenuItem.Name = "textFiletxtToolStripMenuItem";
            this.textFiletxtToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.textFiletxtToolStripMenuItem.Text = "Text File (.txt)";
            this.textFiletxtToolStripMenuItem.Click += new System.EventHandler(this.textFiletxtToolStripMenuItem_Click);
            // 
            // cSVFilecsvToolStripMenuItem
            // 
            this.cSVFilecsvToolStripMenuItem.Name = "cSVFilecsvToolStripMenuItem";
            this.cSVFilecsvToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cSVFilecsvToolStripMenuItem.Text = "CSV File (.csv)";
            this.cSVFilecsvToolStripMenuItem.Click += new System.EventHandler(this.cSVFilecsvToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.richTextBox1.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.richTextBox1.BackBrush = null;
            this.richTextBox1.CharHeight = 14;
            this.richTextBox1.CharWidth = 8;
            this.richTextBox1.CommentPrefix = "--";
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.richTextBox1.IsReplaceMode = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.richTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.richTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("richTextBox1.ServiceColors")));
            this.richTextBox1.Size = new System.Drawing.Size(921, 307);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Zoom = 100;
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown_1);
            // 
            // QueryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "QueryWindow";
            this.Size = new System.Drawing.Size(921, 622);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryWindow_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.exportMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.richTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip exportMenu;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excelFilexlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFiletxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVFilecsvToolStripMenuItem;
        private FastColoredTextBoxNS.FastColoredTextBox richTextBox1;
    }
}
