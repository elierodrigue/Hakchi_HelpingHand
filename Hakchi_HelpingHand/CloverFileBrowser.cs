using System;
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
    public partial class CloverFileBrowser : Form
    {
        com.clusterrr.clovershell.ClovershellConnection conn;// = new com.clusterrr.clovershell.ClovershellConnection();
        Timer tmr = new Timer();

        public CloverFileBrowser()
        {
            InitializeComponent();
            conn = new com.clusterrr.clovershell.ClovershellConnection() { AutoReconnect = true, Enabled = true };
            conn.OnConnected += Conn_OnConnected;
            // conn.ShellEnabled = true;
            tmr.Interval = 500;
            tmr.Tick += Tmr_Tick;
            tmr.Enabled = true;
        }
        bool oldStatus = false;
        private void Tmr_Tick(object sender, EventArgs e)
        {
            if (conn.IsOnline != oldStatus)
            {
                oldStatus = conn.IsOnline;
                if (conn.IsOnline)
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
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(AddLog), new object[] { sender, e });
            }
            else
            {
                listBox1.Items.Add(sender);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }
        private void AddNode(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(AddNode), new object[] { sender, e });
            }
            else
            {
                treeView1.Nodes.Add((TreeNode)sender);
            }
        }
        private void Conn_OnConnected()
        {
            AddLog("Connected");
            TreeNode tn = new TreeNode("root");
            tn.Tag = "/";
            tn.ImageIndex = 1;
            tn.SelectedImageIndex = 1;
            ProcessTreeNode(tn);
            AddNode(tn, null);
        }
        private string[] listFolder(string path)
        {
            string command = "ls -al " + path;
            AddLog("->" + command);


            var result = conn.ExecuteSimple(command, 5000, true);
            string[] allLogs = result.Split(new string[] { "\n" }, StringSplitOptions.None);
            foreach (string s in allLogs)
            {
                AddLog(s);
            }
            return allLogs;
        }
        private void ProcessTreeNode(TreeNode tn)
        {
            tn.Nodes.Clear();
            string path = tn.Tag.ToString();
            string[] subs = listFolder(path);
            for(int x=1;x<subs.Length;x++)
            {
                
                string s = subs[x];
                string filename = s.Substring(57);
                if (filename != "." && filename != "..")
                {
                    TreeNode c = new TreeNode(filename);
                    

                    tn.Nodes.Add(c);
                    if (s[0] == 'd')
                    {
                        c.Tag = path + filename + "/";
                        c.ImageIndex = 1;
                        c.SelectedImageIndex = 1;
               //         ProcessTreeNode(c);
                    }
                    else
                    {
                        c.Tag = path + filename;
                        c.ImageIndex = 0;
                        c.SelectedImageIndex = 0;
                    }
                }
            }
            tn.Expand();
          

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag.ToString().EndsWith("/"))
            {
                ProcessTreeNode(e.Node);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.ImageIndex == 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = treeView1.SelectedNode.Text;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.Stream s = sfd.OpenFile();

                    string path = treeView1.SelectedNode.Tag.ToString();
                    conn.Execute("cat " + path, null, s, null, 15000, false);
                    s.Close();
                    MessageBox.Show("Done");

                }
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (treeView1.SelectedNode != null && treeView1.SelectedNode.ImageIndex == 0)
            {
                    string path = treeView1.SelectedNode.Tag.ToString();
                   string text = conn.ExecuteSimple("cat " + path, 15000, false);
                textBox1.Text = text.Replace("\n","\r\n");
              

                
            }
        }
    }
}
