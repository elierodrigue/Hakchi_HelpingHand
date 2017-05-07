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
    
        Timer tmr = new Timer();
        bool ranOnce = false;
        public CloverFileBrowser()
        {
            InitializeComponent();
            ClovershellWrapper.getInstance().OnConnected += Conn_OnConnected;
         
            // conn.ShellEnabled = true;
            tmr.Interval = 500;
            tmr.Tick += Tmr_Tick;
            tmr.Enabled = true;
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
                    Conn_OnConnected();
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
            
            if (!ranOnce)
            {
                ranOnce = true;
                TreeNode tn = new TreeNode("root");
                tn.Tag = "/";
                tn.ImageIndex = 1;
                tn.SelectedImageIndex = 1;
                ProcessTreeNode(tn);
                AddNode(tn, null);
                AddLog("Connected");
            }
        }

        private void ProcessTreeNode(TreeNode tn)
        {
            tn.Nodes.Clear();
            string path = tn.Tag.ToString();
            ClovershellWrapper.FolderDetail fd = ClovershellWrapper.getInstance().GetFolderDetail(path);
            foreach(string f in fd.Folders)
            {
                TreeNode c = new TreeNode(f);
                c.Tag = path + f + "/";
                c.ImageIndex = 1;
                c.SelectedImageIndex = 1;

                tn.Nodes.Add(c);
            }
            foreach (string f in fd.Files)
            {
                TreeNode c = new TreeNode(f);
                c.Tag = path + f;
                c.ImageIndex = 0;
                c.SelectedImageIndex = 0;

                tn.Nodes.Add(c);
            }
            
            tn.Expand();
          

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Tag.ToString().EndsWith("/"))
            {
                ProcessTreeNode(e.Node);
            }
            else
            {
                OpenNode(e.Node);
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
                    ClovershellWrapper.getInstance().GetFileInStream(path, s);
                    s.Close();
                    MessageBox.Show("Done");

                }
            }
            

        }
        private void OpenNode(TreeNode tn)
        {
            List<string> imagesExtensions = new List<string>();
            imagesExtensions.Add(".jpg");
            imagesExtensions.Add(".gif");
            imagesExtensions.Add(".png");

            string path = tn.Tag.ToString();
            string ext = "";
            try
            {
                ext = System.IO.Path.GetExtension(tn.Text);
            }
            catch
            {

            }
            if (imagesExtensions.Contains(ext))
            {
                System.IO.MemoryStream str = new System.IO.MemoryStream();
                ClovershellWrapper.getInstance().GetFileInStream(path, str);
                str.Seek(0, System.IO.SeekOrigin.Begin);
                pictureBox1.Image = Image.FromStream(str);
                str.Close();
            }
            else
            {

                string text = ClovershellWrapper.getInstance().GetFileAsString(path);
                textBox1.Text = text.Replace("\n", "\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                TreeNode toUse = treeView1.SelectedNode;
                while(toUse.ImageIndex != 1)
                {
                    toUse = toUse.Parent;
                }
                string path = toUse.Tag.ToString();

                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.Stream strIn = ofd.OpenFile();
                 
                    string fileName =System.IO.Path.GetFileName( ofd.FileName);
                    ClovershellWrapper.getInstance().UploadFile(path + fileName, strIn);
                    strIn.Close();
                    ProcessTreeNode(toUse);

                }
            }
        }

        private void CloverFileBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
