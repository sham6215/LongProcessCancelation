using Parago.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LongProcessCancelation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartModal_Click(object sender, RoutedEventArgs e)
        {
            ProgressDialogSettings settings = new ProgressDialogSettings() { ShowCancelButton = true, ShowProgressBarIndeterminate = false, ShowSubLabel = true };
            var result = ProgressDialog.Execute(this, "Test Process", () => {
                int ticks_count = 3000;

                /// Do long time operations

                for (int i = 0; i < ticks_count; ++i)
                {
                    int progress = i * 100 / ticks_count;
                    ProgressDialog.Current.ReportWithCancellationCheck(progress, $"Completed: {progress}%");
                    Thread.Sleep(50);
                }

                /// Return any object as an operations result
                return 12345;
            }, settings);
        }

        private void StartAsync_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
