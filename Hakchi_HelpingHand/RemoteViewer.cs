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
                    var screenshot = new Bitmap(1280, 720, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    conn.Execute("cat /dev/fb0", null, rawStream, null, 1000, true);
                    var raw = rawStream.ToArray();
                    BitmapData data = screenshot.LockBits(new Rectangle(0, 0, screenshot.Width, screenshot.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    int rawOffset = 0;
                    unsafe
                    {
                        for (int y = 0; y < screenshot.Height; ++y)
                        {
                            byte* row = (byte*)data.Scan0 + (y * data.Stride);
                            int columnOffset = 0;
                            for (int x = 0; x < screenshot.Width; ++x)
                            {
                                row[columnOffset] = raw[rawOffset];
                                row[columnOffset + 1] = raw[rawOffset + 1];
                                row[columnOffset + 2] = raw[rawOffset + 2];

                                columnOffset += 3;
                                rawOffset += 4;
                            }
                        }
                    }
                    screenshot.UnlockBits(data);
                    pictureBox1.Image = screenshot;
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
