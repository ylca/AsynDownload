
using AltoHttp;
using System;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
            HttpDownloader mDownloader =  null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        /// <summary>
        /// 下载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadComplete(object sender, EventArgs e)
        {
            MessageBox.Show("下载完成");
        }
        /// <summary>
        /// 下载进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.Progress;
            label1.Text = e.Speed / 1024  +"kb/s";
        }

        private void button_start_Click(object sender, EventArgs e)
        {

            progressBar1.Value = 0;
            mDownloader = new HttpDownloader(textBox_url.Text, "D:\\update.zip");
            mDownloader.DownloadCompleted += new EventHandler(downloadComplete);
            mDownloader.DownloadProgressChanged += new ProgressChangedEventHandler(downloadProgress);
            mDownloader.StartAsync();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            //PAUSE 
            mDownloader.Pause();
        }

        private void button_continue_Click(object sender, EventArgs e)
        {
            //RESUME
            mDownloader.ResumeAsync();
        }
    }


   
}
