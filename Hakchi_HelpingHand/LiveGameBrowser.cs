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
       
        bool ranOnce = false;
        public LiveGameBrowser()
        {
            InitializeComponent();
            ClovershellWrapper.getInstance().OnConnected += Conn_OnConnected; ;
         
            this.FormClosing += LiveGameBrowser_FormClosing; ;
            if(ClovershellWrapper.getInstance().IsOnline())
            {
                Conn_OnConnected();
            }
           
        }
        string basepath = "/var/lib/hakchi/rootfs/usr/share/games/nes/kachikachi/";
        private void Conn_OnConnected()
        {
            if (!ranOnce)
            {
                ranOnce = true;
                treeView1.Nodes.Clear();
                TreeNode tn = new TreeNode("Root");
                getTreenode(tn, basepath);
                AddNode(tn, null);
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

        private void LiveGameBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void getTreenode(TreeNode tn , string path)
        {
            tn.Nodes.Clear();
            ClovershellWrapper.FolderDetail fd = ClovershellWrapper.getInstance().GetFolderDetail(path);
         
            for (int x = 1; x < fd.Folders.Count(); x++)
            {

                string s = fd.Folders[x];
                if (s.ToLower().StartsWith("clv"))
                {
                    BasicInfo bi = getFolderName(path + s + "/" + s + ".desktop");
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
                        c.Tag = path + s;
                        c.ImageIndex = 0;
                        c.SelectedImageIndex = 0;
                    }
                }
                        //         ProcessTreeNode(c);
                 
            }
        }
        private BasicInfo getFolderName(string path)
        {
           
            string s = ClovershellWrapper.getInstance().GetFileAsString(path);

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
      

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count == 0 && e.Node.ImageIndex==1)
            {
                getTreenode(e.Node, e.Node.Tag.ToString());
            }
        }

        private void LiveGameBrowser_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
