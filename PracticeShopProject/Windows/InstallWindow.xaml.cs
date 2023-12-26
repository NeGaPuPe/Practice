using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PracticeShopProject.Entities;
using System.ComponentModel;
using System.Threading;

namespace PracticeShopProject.Windows
{
    public partial class InstallWindow : Window
    {
        public InstallWindow()
        {
            InitializeComponent();
        }
        void download_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progressbar.Minimum = 0;
            Progressbar.Maximum = 100;
            Progressbar.Value = e.ProgressPercentage;
            if (Progressbar.Value == 100)
            {
                WebClient wc = new WebClient();
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\Updates");
                if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\Updates\Practice-master"))
                {
                    Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\Updates\Practice-master", true);
                }
                wc.DownloadFile("https://github.com/NeGaPuPe/Practice/archive/master.zip", AppDomain.CurrentDomain.BaseDirectory + @"\Updates\PracticeShopInstaller.zip");
                var apppath = System.IO.Path.GetFullPath("Updates\\PracticeShopInstaller.zip");
                var apppath1 = System.IO.Path.GetFullPath("Updates");
                ZipFile.ExtractToDirectory(apppath, apppath1);
                var process = Cmd("msiexec.exe /x" + AppDomain.CurrentDomain.BaseDirectory + $@"\Updates\Practice-master\PracticeShopInstaller\Debug\PracticeShopInstaller.msi " + $@"TARGETDIR=""{AppDomain.CurrentDomain.BaseDirectory}"" /qn");

                process.EnableRaisingEvents = true;
                process.Exited += (e1, s) => {
                    var process1 = Process.Start(new ProcessStartInfo
                    {
                        FileName = AppDomain.CurrentDomain.BaseDirectory + $@"\Updates\Practice-master\PracticeShopInstaller\Debug\PracticeShopInstaller.msi",
                        Arguments = $@"TARGETDIR=""{AppDomain.CurrentDomain.BaseDirectory}"" /qb",
                        WindowStyle = ProcessWindowStyle.Hidden,
                    });
                    process1.EnableRaisingEvents = true;
                    process1.Exited += Process_Exited;
                };
            }
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "PracticeShop"))
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "PracticeShop\\PracticeShopProject.exe"))
                {
                    MessageBox.Show("Утановка приложения остановлена.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Dispatcher.Invoke(() =>
                    {
                        Close();
                    });
                }
                else
                {
                    MessageBox.Show("Приложение успешно обновлено. Старая версия приложения будет закрыта.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Cmd($@"taskkill /f /im PracticeShopProject.exe && robocopy {AppDomain.CurrentDomain.BaseDirectory}PracticeShop\ {AppDomain.CurrentDomain.BaseDirectory} /E /MOVE & timeout /t 1 /nobreak && {AppDomain.CurrentDomain.BaseDirectory}PracticeShopProject.exe");
                }
            }
        }

        public Process Cmd(string line)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = $"/c {line}",
                WindowStyle = ProcessWindowStyle.Hidden,
            });
        }

        void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(17);
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_Dowork;
            worker.ProgressChanged += download_ProgressChanged;
            worker.RunWorkerAsync();
        }
    }
}
