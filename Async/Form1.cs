using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_loadadd.Text = "https://www.microsoft.com/en-us/download/details.aspx?id=6";
        }

        private delegate string AsyncMethodCaller(string fileurl);

        SynchronizationContext sc;

        private void btn_apm_Click(object sender, EventArgs e)
        {
            rtb_State.Text = "下载中。。。";
            btn_apm.Enabled = false;
            sc = SynchronizationContext.Current;
            AsyncMethodCaller methodcaller = new AsyncMethodCaller(DownLoadFileAsync);
        }

        private string DownLoadFileAsync(string url)
        {
            int BuffSize = 2048;
            byte[] BufferRead = new byte[BuffSize];
            string savepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dotNetFx35setup.exe";
            FileStream filesstream = null;
            HttpWebResponse myWebResponse = null;
            if (File.Exists(savepath))
            {
                File.Delete(savepath);
            }
            filesstream = new FileStream(savepath, FileMode.OpenOrCreate);
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                if (myHttpWebRequest != null)
                {
                    myWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    Stream responseStream = myWebResponse.GetResponseStream();
                    int readSize = responseStream.Read(BufferRead, 0, BuffSize);
                }
            }
            catch (Exception e)
            {
               
            }
                 

            return "";
        }
    }
}
