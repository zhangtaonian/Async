using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
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
            txt_loadadd.Text = "https://www.microsoft.com/en-us/download/confirmation.aspx?id=6";
            btn_Pause.Enabled = false;
            btn_PauseAsync.Enabled = false;
            btn_pausetap.Enabled = false;
            GetTotalSize();
            downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dotNetFx35setup.exe";

            if (File.Exists(downloadPath))
            {
                if (File.Exists(downloadPath))
                {
                    File.Delete(downloadPath);
                }
                //FileInfo fileInfo = new FileInfo(downloadPath);
                //DownLoadSize = (int)fileInfo.Length;
                //pgbar.Value = (int)( (float)DownLoadSize / (float)totalSize * 100);  
            }

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            
        }       

        private delegate string AsyncMethodCaller(string fileurl);
        SynchronizationContext sc;//获取UI线程同步上下文

        private void btn_apm_Click(object sender, EventArgs e)
        {
            rtb_State2.Text = "下载中。。。";
            btn_apm.Enabled = false;
            sc = SynchronizationContext.Current;
            AsyncMethodCaller methodcaller = new AsyncMethodCaller(DownLoadFileAsync);
            methodcaller.BeginInvoke(txt_loadadd.Text.Trim(), GetResult, null);
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
                    while (readSize > 0)
                    {
                        filesstream.Write(BufferRead, 0, readSize);
                        readSize = responseStream.Read(BufferRead, 0, BuffSize);
                    }
                    return string.Format("文件下载完成，文件大小为：{0}", filesstream.Length);
                }
            }
            catch (Exception e)
            {
                return string.Format("下载出错");
            }
            finally
            {
                if (myWebResponse != null)
                {
                    myWebResponse.Close();
                }
                if (filesstream != null)
                {
                    filesstream.Close();
                }
            }
            return "";     
        }
        private void GetResult(IAsyncResult result)
        {
            AsyncMethodCaller caller = (AsyncMethodCaller)((AsyncResult)result).AsyncDelegate;
            string returnstring = caller.EndInvoke(result);
            sc.Post(ShowState, returnstring);
        }

        private void ShowState(object reuslt)
        {
            rtb_State2.Text = reuslt.ToString();
            btn_apm.Enabled = true;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //EAP
        public int DownLoadSize = 0;
        public string downloadPath = null;
        long totalSize = 0;
        const int BufferSize = 2048;
        byte[] BufferRead = new byte[BufferSize];
        FileStream filestream = null;
        HttpWebResponse myWebResponse = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eap_Click(object sender, EventArgs e)
        {
            DownLoadSize = 0;
            if (File.Exists(downloadPath))
            {
                File.Delete(downloadPath);
            }
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();

                filestream = new FileStream(downloadPath, FileMode.OpenOrCreate);

                filestream.Seek(DownLoadSize, SeekOrigin.Begin);
                btn_Eap.Enabled = false;
                btn_Pause.Enabled = true;
            }
            else
            {
                MessageBox.Show("正在执行操作,请稍后");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgworker = sender as BackgroundWorker;
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(txt_loadadd.Text.Trim());
            if (DownLoadSize != 0)
            {
                myHttpWebRequest.AddRange(DownLoadSize);
            }

            myWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            Stream responseStream = myWebResponse.GetResponseStream();
            int readSize = 0;
            while (true)
            {
                if (bgworker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
        
                readSize = responseStream.Read(BufferRead, 0 , BufferSize);
                if (readSize > 0)
                {
                    DownLoadSize += readSize;
                    int percentComplete = (int)((float)DownLoadSize / (float)totalSize * 100);
                    filestream.Write(BufferRead, 0, BufferSize);

                    bgworker.ReportProgress(percentComplete);//引发ProgressChanged
                }
                else
                {
                    break;
                }
            }
        }


        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbar.Value = e.ProgressPercentage;
        
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                myWebResponse.Close();
            }
            else if ( e.Cancelled )
            {
                rtb_State2.Text = string.Format("下载暂停，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);
               
                myWebResponse.Close();
                filestream.Close();
                filestream.Close();

                btn_Eap.Enabled = true;
                btn_Pause.Enabled = false;
            }
            else
            {
                rtb_State2.Text = string.Format("下载已完成，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);  
                filestream.Close();
                filestream.Close();

                btn_Eap.Enabled = false;
                btn_Pause.Enabled = false;
            }
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy && backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void GetTotalSize()
        {
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(txt_loadadd.Text.Trim());
            HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
            totalSize = response.ContentLength;
            response.Close();
        }



        /////////////////////////////////////////////////////////////
        //TAP
        //int DownLoadSize1 = 0;
        //string downloadPath1 = "";
        //long totalSize1 = 0;
        //FileStream filestream1;
        CancellationTokenSource cts = null;
        Task task = null;

        private void btn_downloadtap_Click(object sender, EventArgs e)
        {
            DownLoadSize = 0;
            if (File.Exists(downloadPath))
            {
                File.Delete(downloadPath);
            }
            filestream = new FileStream(downloadPath, FileMode.OpenOrCreate);
            btn_downloadtap.Enabled = false;
            btn_pausetap.Enabled = true;

            filestream.Seek(DownLoadSize, SeekOrigin.Begin);

            //捕捉调用线程的同步上下文派生对象
            sc = SynchronizationContext.Current;
            cts = new CancellationTokenSource();
            

            task = new Task(()=>DawnLoadFileWithTap(txt_loadadd.Text.Trim(), cts.Token, new Progress<int>(p => {
                sc.Post(new SendOrPostCallback((result) => pgbar.Value = (int)result), p);
            })));
            task.Start();
        }

        private void DawnLoadFileWithTap(string url, CancellationToken ct, IProgress<int> progress)
        {
            try
            {
                HttpWebResponse response = null;
                HttpWebRequest  request = (HttpWebRequest)WebRequest.Create(txt_loadadd.Text.Trim());
                if (DownLoadSize != 0)
                {
                    request.AddRange(DownLoadSize);
                }

                response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                int readSize = 0;
                while (true)
                {
                    if (ct.IsCancellationRequested == true)
                    {
                        

                        response.Close();
                        filestream.Close();

                        sc.Post((state) =>
                        {
                            rtb_State2.Text = string.Format("下载暂停，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);
                            btn_downloadtap.Enabled = true;
                            btn_pausetap.Enabled = false;
                        }, null);

                        break;
                       
                    }
                    readSize = responseStream.Read(BufferRead, 0, BufferSize);
                    if (readSize > 0)
                    {
                        DownLoadSize += readSize;
                        int percentComplete = (int)((float)DownLoadSize / (float)totalSize * 100);
                        filestream.Write(BufferRead, 0, BufferSize);

                        progress.Report(percentComplete);
                    }
                    else
                    {                                 
                        sc.Post((state) =>
                        {
                            rtb_State2.Text = string.Format("下载完成，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);
                            btn_downloadtap.Enabled = false;
                            btn_pausetap.Enabled = false;
                        }, null);

                        response.Close();
                        filestream.Close();

                        break;
                    }
                   
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is OperationCanceledException);
            }
                     
        }
        private void btn_pausetap_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////
        //async和await

        private async void btn_DownLoadAsync_Click(object sender, EventArgs e)
        {
            DownLoadSize = 0;
            if (File.Exists(downloadPath))
            {
                File.Delete(downloadPath);
            }
            filestream = new FileStream(downloadPath, FileMode.OpenOrCreate);
            btn_DownLoadAsync.Enabled = false;
            btn_PauseAsync.Enabled = true;

            filestream.Seek(DownLoadSize, SeekOrigin.Begin);

            //捕捉调用线程的同步上下文派生对象
            cts = new CancellationTokenSource();

            await DownLoadFileAsync(txt_loadadd.Text.Trim(), cts.Token, new Progress<int>(p => pgbar.Value = p));

        }

        private async Task DownLoadFileAsync(string url, CancellationToken ct, IProgress<int> progress)
        {
            try
            {
                HttpWebResponse response = null;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(txt_loadadd.Text.Trim());
                if (DownLoadSize != 0)
                {
                    request.AddRange(DownLoadSize);
                }

                response = (HttpWebResponse)await request.GetResponseAsync(); ;
                Stream responseStream = response.GetResponseStream();
                int readSize = 0;
                while (true)
                {
                    if (ct.IsCancellationRequested == true)
                    {


                        response.Close();
                        filestream.Close();

                        rtb_State2.Text = string.Format("下载暂停，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);
                        btn_DownLoadAsync.Enabled = true;
                        btn_PauseAsync.Enabled = false;

                        break;

                    }
                    readSize = await responseStream.ReadAsync(BufferRead, 0, BufferSize);
                    if (readSize > 0)
                    {
                        DownLoadSize += readSize;
                        int percentComplete = (int)((float)DownLoadSize / (float)totalSize * 100);
                        await filestream.WriteAsync(BufferRead, 0, BufferSize);

                        progress.Report(percentComplete);
                    }
                    else
                    {
                        rtb_State2.Text = string.Format("下载完成，下载的地址为：{0}\n 已经下载的字节数为：{1}字节", downloadPath, DownLoadSize);
                        btn_DownLoadAsync.Enabled = true;
                        btn_PauseAsync.Enabled = false;

                        response.Close();
                        filestream.Close();

                        break;
                    }

                }
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is OperationCanceledException);
            }
        }

        private void btn_PauseAsync_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }


    }
   
}
