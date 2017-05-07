using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
namespace Hakchi_HelpingHand
{
    public partial class RemoteViewer : Form
    {
      
        com.clusterrr.clovershell.ClovershellConnection conn;// = new com.clusterrr.clovershell.ClovershellConnection();
        BackgroundWorker wrk = new BackgroundWorker();
        public RemoteViewer()
        {
            InitializeComponent();
            conn = Form1.conn;
            conn.OnConnected += Conn_OnConnected;

            this.FormClosing += RemoteViewer_FormClosing;
            wrk.DoWork += Wrk_DoWork;
            wrk.RunWorkerAsync();
        }

        private void Wrk_DoWork(object sender, DoWorkEventArgs e)
        {
           while(!this.IsDisposed)
            {
                if(conn.IsOnline)
                {
                    var rawStream = new MemoryStream();
  
                    conn.Execute("cat /dev/fb0", null, rawStream, null, 1000, true);
                    var raw = rawStream.ToArray();
          
                    Bitmap bmp = new Bitmap(1280,720, 1280*4, PixelFormat.Format32bppRgb, GCHandle.Alloc(raw, GCHandleType.Pinned).AddrOfPinnedObject());
                    pictureBox1.Image = bmp;
                }
                Application.DoEvents();
            }
        }

        private void Conn_OnConnected()
        {
          //  throw new NotImplementedException();
        }

        private void RemoteViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }
    }
}
