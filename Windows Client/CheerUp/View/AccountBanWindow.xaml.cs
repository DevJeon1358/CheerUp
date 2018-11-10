using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace CheerUp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AccountBanWindow : Window
    {
        public AccountBanWindow()
        {
            InitializeComponent();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //Procss Kill
            Process.GetCurrentProcess().Kill();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Procss Kill
            Process.GetCurrentProcess().Kill();
        }
    }
}
