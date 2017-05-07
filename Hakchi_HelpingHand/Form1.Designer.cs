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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNesParam = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.liveScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(502, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "1 - Compress all games";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(502, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "2 - Distinguish duplicate games";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 393);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(526, 160);
            this.lstLog.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(502, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "3 - Cleanup Name";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 200);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(502, 52);
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
            this.menuStrip1.Size = new System.Drawing.Size(526, 24);
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
            this.clovershellToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clovershellToolStripMenuItem.Text = "Clovershell";
            this.clovershellToolStripMenuItem.Click += new System.EventHandler(this.clovershellToolStripMenuItem_Click);
            // 
            // filebrowserToolStripMenuItem
            // 
            this.filebrowserToolStripMenuItem.Name = "filebrowserToolStripMenuItem";
            this.filebrowserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filebrowserToolStripMenuItem.Text = "Filebrowser";
            this.filebrowserToolStripMenuItem.Click += new System.EventHandler(this.filebrowserToolStripMenuItem_Click);
            // 
            // gameBrowserToolStripMenuItem
            // 
            this.gameBrowserToolStripMenuItem.Name = "gameBrowserToolStripMenuItem";
            this.gameBrowserToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gameBrowserToolStripMenuItem.Text = "Game browser";
            this.gameBrowserToolStripMenuItem.Click += new System.EventHandler(this.gameBrowserToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "NES Command line parameter";
            // 
            // txtNesParam
            // 
            this.txtNesParam.Location = new System.Drawing.Point(163, 263);
            this.txtNesParam.Name = "txtNesParam";
            this.txtNesParam.Size = new System.Drawing.Size(351, 20);
            this.txtNesParam.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 289);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(502, 52);
            this.button5.TabIndex = 11;
            this.button5.Text = "5 - Apply cache clearing fix";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // liveScreenToolStripMenuItem
            // 
            this.liveScreenToolStripMenuItem.Name = "liveScreenToolStripMenuItem";
            this.liveScreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.liveScreenToolStripMenuItem.Text = "Live Screen";
            this.liveScreenToolStripMenuItem.Click += new System.EventHandler(this.liveScreenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 553);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.txtNesParam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hakchi Helping Hand 1.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}

