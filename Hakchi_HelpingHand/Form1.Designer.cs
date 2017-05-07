namespace Hakchi_HelpingHand
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clovershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filebrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNesParam = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkGameClearingFix = new System.Windows.Forms.CheckBox();
            this.txtAvailableSpace = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNbGames = new System.Windows.Forms.Label();
            this.nudNbGames = new System.Windows.Forms.NumericUpDown();
            this.nudCompressedGames = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudInvalidGames = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressedGames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInvalidGames)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(361, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "1 - Compress all games";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(6, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(361, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "2 - Distinguish duplicate games";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 332);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(1166, 160);
            this.lstLog.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(6, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(361, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "3 - Cleanup Name";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(6, 193);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(361, 52);
            this.button4.TabIndex = 6;
            this.button4.Text = "4 - Fix rom names and rebuild NES Command";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1166, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clovershellToolStripMenuItem,
            this.filebrowserToolStripMenuItem,
            this.gameBrowserToolStripMenuItem,
            this.liveScreenToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // clovershellToolStripMenuItem
            // 
            this.clovershellToolStripMenuItem.Name = "clovershellToolStripMenuItem";
            this.clovershellToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.clovershellToolStripMenuItem.Text = "Clovershell";
            this.clovershellToolStripMenuItem.Click += new System.EventHandler(this.clovershellToolStripMenuItem_Click);
            // 
            // filebrowserToolStripMenuItem
            // 
            this.filebrowserToolStripMenuItem.Name = "filebrowserToolStripMenuItem";
            this.filebrowserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.filebrowserToolStripMenuItem.Text = "Filebrowser";
            this.filebrowserToolStripMenuItem.Click += new System.EventHandler(this.filebrowserToolStripMenuItem_Click);
            // 
            // gameBrowserToolStripMenuItem
            // 
            this.gameBrowserToolStripMenuItem.Name = "gameBrowserToolStripMenuItem";
            this.gameBrowserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.gameBrowserToolStripMenuItem.Text = "Game browser";
            this.gameBrowserToolStripMenuItem.Click += new System.EventHandler(this.gameBrowserToolStripMenuItem_Click);
            // 
            // liveScreenToolStripMenuItem
            // 
            this.liveScreenToolStripMenuItem.Name = "liveScreenToolStripMenuItem";
            this.liveScreenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.liveScreenToolStripMenuItem.Text = "Live Screen";
            this.liveScreenToolStripMenuItem.Click += new System.EventHandler(this.liveScreenToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "NES Command line parameter";
            // 
            // txtNesParam
            // 
            this.txtNesParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNesParam.Location = new System.Drawing.Point(166, 256);
            this.txtNesParam.Name = "txtNesParam";
            this.txtNesParam.Size = new System.Drawing.Size(201, 20);
            this.txtNesParam.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtNesParam);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 284);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Software Database";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Location = new System.Drawing.Point(391, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 284);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "NES Classic Operations";
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(6, 77);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(394, 52);
            this.button7.TabIndex = 1;
            this.button7.Text = "Back Folder Picture Optimisation";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(6, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(394, 52);
            this.button6.TabIndex = 0;
            this.button6.Text = "Apply savegame clearing fix";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkGameClearingFix);
            this.groupBox3.Controls.Add(this.txtAvailableSpace);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Location = new System.Drawing.Point(803, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(351, 104);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NES Mini Info";
            // 
            // chkGameClearingFix
            // 
            this.chkGameClearingFix.AutoSize = true;
            this.chkGameClearingFix.Enabled = false;
            this.chkGameClearingFix.Location = new System.Drawing.Point(6, 19);
            this.chkGameClearingFix.Name = "chkGameClearingFix";
            this.chkGameClearingFix.Size = new System.Drawing.Size(170, 17);
            this.chkGameClearingFix.TabIndex = 14;
            this.chkGameClearingFix.Text = "Save game clearing fix applied";
            this.chkGameClearingFix.UseVisualStyleBackColor = true;
            // 
            // txtAvailableSpace
            // 
            this.txtAvailableSpace.Location = new System.Drawing.Point(6, 237);
            this.txtAvailableSpace.Name = "txtAvailableSpace";
            this.txtAvailableSpace.Size = new System.Drawing.Size(339, 13);
            this.txtAvailableSpace.TabIndex = 13;
            this.txtAvailableSpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudInvalidGames);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.nudCompressedGames);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.nudNbGames);
            this.groupBox4.Controls.Add(this.lblNbGames);
            this.groupBox4.Location = new System.Drawing.Point(803, 137);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(351, 174);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hakchi Database Info";
            // 
            // lblNbGames
            // 
            this.lblNbGames.AutoSize = true;
            this.lblNbGames.Location = new System.Drawing.Point(6, 16);
            this.lblNbGames.Name = "lblNbGames";
            this.lblNbGames.Size = new System.Drawing.Size(99, 13);
            this.lblNbGames.TabIndex = 0;
            this.lblNbGames.Text = "Number of games : ";
            // 
            // nudNbGames
            // 
            this.nudNbGames.Enabled = false;
            this.nudNbGames.Location = new System.Drawing.Point(111, 14);
            this.nudNbGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudNbGames.Name = "nudNbGames";
            this.nudNbGames.Size = new System.Drawing.Size(120, 20);
            this.nudNbGames.TabIndex = 1;
            // 
            // nudCompressedGames
            // 
            this.nudCompressedGames.Enabled = false;
            this.nudCompressedGames.Location = new System.Drawing.Point(111, 40);
            this.nudCompressedGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCompressedGames.Name = "nudCompressedGames";
            this.nudCompressedGames.Size = new System.Drawing.Size(120, 20);
            this.nudCompressedGames.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Compressed games : ";
            // 
            // nudInvalidGames
            // 
            this.nudInvalidGames.Enabled = false;
            this.nudInvalidGames.Location = new System.Drawing.Point(111, 66);
            this.nudInvalidGames.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudInvalidGames.Name = "nudInvalidGames";
            this.nudInvalidGames.Size = new System.Drawing.Size(120, 20);
            this.nudInvalidGames.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Invalid games : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 492);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hakchi Helping Hand 1.2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNbGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCompressedGames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInvalidGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clovershellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filebrowserToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNesParam;
        private System.Windows.Forms.ToolStripMenuItem gameBrowserToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem liveScreenToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtAvailableSpace;
        private System.Windows.Forms.CheckBox chkGameClearingFix;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown nudNbGames;
        private System.Windows.Forms.Label lblNbGames;
        private System.Windows.Forms.NumericUpDown nudInvalidGames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCompressedGames;
        private System.Windows.Forms.Label label2;
    }
}

