using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Progressbar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Progressbar pbw = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        protected void btn_StartLengthyTask_Click(object sender, RoutedEventArgs e)
        {
            
            ShowProgress();
        }
        private void ShowProgress()
        {
            try
            {
                // Using background worker to asynchronously run work method.
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += ProcessLogsAsynch;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Notifying the progress bar window of the current progress.
            pbw.UpdateProgress(e.ProgressPercentage);
        }

        private void ProcessLogsAsynch(object sender, DoWorkEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                // Disabling parent window controls while the work is being done.
                btn_StartLengthyTask.IsEnabled = false;

                // Launch the progress bar window using Show()
                // Note: ShowDialog() wouldn't work as it waits for the child window to close.
                pbw = new Progressbar();
                pbw.Show();
            });

            for (int i = 1; i <= 100; i++)
            {
                // Simulates work being done
                Thread.Sleep(100);

                //DAY LA CAI VONG LAP CHINH CUA MAY NE , BIEN CAI DONG CODE CUA MAY THANH 1 METHOD ROI CALL O DAY
                // Reports progress
                (sender as BackgroundWorker).ReportProgress(i);
            }

            Dispatcher.Invoke(() =>
            {
                // Enables parent window controls
                btn_StartLengthyTask.IsEnabled = true;
            });
        }
    }
}
