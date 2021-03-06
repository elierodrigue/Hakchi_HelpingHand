﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hakchi_HelpingHand
{
    public partial class ClovershellConsolecs : Form
    {
 
        Timer tmr = new Timer();
        public ClovershellConsolecs()
        {
            InitializeComponent();
            ClovershellWrapper.getInstance().OnConnected += Conn_OnConnected;
          
           // conn.ShellEnabled = true;
            tmr.Interval = 500;
            tmr.Tick += Tmr_Tick;
            tmr.Enabled = true;
            this.FormClosing += ClovershellConsolecs_FormClosing;
            
        }

        private void ClovershellConsolecs_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        bool oldStatus = false;
        private void Tmr_Tick(object sender, EventArgs e)
        {
           if (ClovershellWrapper.getInstance().IsOnline() != oldStatus)
            {
                oldStatus = ClovershellWrapper.getInstance().IsOnline();
                if (ClovershellWrapper.getInstance().IsOnline())
                {
                    AddLog("Connected");
                }
                else
                {
                    AddLog("Disconnected");
                }
            }
        }

        private void AddLog(string message)
        {
            AddLog(message, null);
        }
        private void AddLog(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new EventHandler(AddLog), new object[] { sender, e });
            }
            else
            {
                listBox1.Items.Add(sender);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }
        private void Conn_OnConnected()
        {
            AddLog("Connected");
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLog("->" + textBox1.Text);
            try
            {
                string[] allLogs = ClovershellWrapper.getInstance().ExecuteConsoleCommand(textBox1.Text);
                foreach (string s in allLogs)
                {
                    AddLog(s);
                }
            }
            catch(Exception exc)
            {
                string[] allLogs = exc.Message.Split(new string[] { "\n" }, StringSplitOptions.None);
                foreach (string s in allLogs)
                {
                    AddLog(s);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
                textBox1.Text = "";
            }
        }
    }
}
