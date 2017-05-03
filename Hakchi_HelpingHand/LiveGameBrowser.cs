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
    public partial class LiveGameBrowser : Form
    {
        com.clusterrr.clovershell.ClovershellConnection conn;// = new com.clusterrr.clovershell.ClovershellConnection();
        
        public LiveGameBrowser()
        {
            InitializeComponent();
            conn = new com.clusterrr.clovershell.ClovershellConnection() { AutoReconnect = true, Enabled = true };
            conn.OnConnected += Conn_OnConnected; ;
         
            this.FormClosing += LiveGameBrowser_FormClosing; ;

           
        }
        string basepath = "/var/lib/hakchi/rootfs/usr/share/games/nes/kachikachi/";
        private void Conn_OnConnected()
        {
            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode("Root");
            getTreenode(tn,basepath);
            AddNode(tn, null);
           
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

        private void LiveGameBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void getTreenode(TreeNode tn , string path)
        {
            tn.Nodes.Clear();
            string[] subs = listFolder(path);
            for (int x = 1; x < subs.Length; x++)
            {

                string s = subs[x];
                string filename = s.Substring(57);
                if (filename != "." && filename != ".." && filename.ToLower().StartsWith("clv"))
                {
                    
                    if (s[0] == 'd')
                    {

                        BasicInfo bi = getFolderName(path + filename + "/" + filename + ".desktop");
                        TreeNode c = new TreeNode(bi.name);
                         

                        tn.Nodes.Add(c);
                        if (bi.exec.StartsWith("/bin/chmenu"))
                        {
                            c.Tag = basepath + bi.exec.Replace("/bin/chmenu ", "").Trim() + "/";
                            c.ImageIndex = 1;
                            c.SelectedImageIndex = 1;
                        /*    if (bi.name != "Back")
                            {
                                getTreenode(c, basepath + bi.exec.Replace("/bin/chmenu ", "").Trim() + "/");
                            }*/
                        }
                        else
                        {
                            c.Tag = path + filename;
                            c.ImageIndex = 0;
                            c.SelectedImageIndex = 0;
                        }
                        //         ProcessTreeNode(c);
                    }
                    else
                    {
                    /*   */
                    }
                }
            }
        }
        private BasicInfo getFolderName(string path)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            conn.Execute("cat " + path, null, ms, null, 15000, false);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            System.IO.TextReader rdr = new System.IO.StreamReader(ms);
            string s = rdr.ReadToEnd();
            rdr.Close();
            string[] splitted = s.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            BasicInfo bi = new BasicInfo();
            foreach(string ss in splitted)
            {
                if(ss.StartsWith("Name="))
                {
                    bi.name = ss.Substring(5);
                }
                if (ss.StartsWith("Exec="))
                {
                    bi.exec = ss.Substring(5);
                }
            }
            return bi;
        }
        public class BasicInfo
        {
            public string name;
            public string exec;
        }
        private string[] listFolder(string path)
        {
            string command = "ls -al " + path;
        
            try
            {

                var result = conn.ExecuteSimple(command, 5000, true);
                string[] allLogs = result.Split(new string[] { "\n" }, StringSplitOptions.None);
              
                return allLogs;
            }
            catch (Exception exc)
            {
               
                return new string[] { "" };
            }

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.ImageIndex==1)
            {
                getTreenode(e.Node, e.Node.Tag.ToString());
            }
        }

        private void LiveGameBrowser_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            conn.Disconnect();
            conn.Dispose();
        }
    }
}
