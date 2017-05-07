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
      
     
        BackgroundWorker wrk = new BackgroundWorker();
        public RemoteViewer()
        {
            InitializeComponent();
           
            ClovershellWrapper.getInstance().OnConnected += Conn_OnConnected;

            this.FormClosing += RemoteViewer_FormClosing;
            wrk.DoWork += Wrk_DoWork;
            wrk.RunWorkerAsync();
        }

        private void Wrk_DoWork(object sender, DoWorkEventArgs e)
        {
           
         

            while (!this.IsDisposed)
            {
                if(ClovershellWrapper.getInstance().IsOnline())
                {
                  
                    pictureBox1.Image = ClovershellWrapper.getInstance().Screenshot(); ;
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
