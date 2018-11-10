using System;
using System.Collections.Generic;
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
using SQ_CRE;
using System.Diagnostics;
using CheerUp.Model;

namespace CheerUp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLogout = false;
        private Place curPlace = new Place();

        public MainWindow()
        {
            InitPlace();
            InitializeComponent();
        }

        private void InitPlace()
        {
            getPlace();
        }

        private void getMessage()
        {
            App.socketManager.SendCurPlace();

            App.socketManager.EventOn("init", (s, e) =>
            {
                List<Message> response = e as List<Message>;

                foreach (Message item in response)
                {
                    App.messageViewModel.Add(item);
                    CheerlistView.ItemsSource = App.messageViewModel.Items;
                    gdCurPlace.DataContext = curPlace;
                }
            });
        }

        private void getPlace()
        {
            App.socketManager.GetPlaceList();
            App.socketManager.EventOn("getplace_res", (v, g) =>
            {
                foreach (Place item in (List<Place>)g)
                {
                    Debug.WriteLine(item.Idx);
                    App.placeViewModel.Add(item);
                    curPlace = App.placeViewModel.Items[0];
                }
            });

        }
        /// <summary>
        /// Init Event
        /// </summary>
        private void Window_Initialized(object sender, EventArgs e)
        {
            //Setting Position
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            System.Drawing.Rectangle screen = System.Windows.Forms.SystemInformation.VirtualScreen;
            this.Left = Convert.ToInt32(screen.Right - this.Width - 10);
            this.Top = Convert.ToInt32(screen.Bottom - this.Height - 35);
            this.ShowDialog();

            //Network Check
            NetworkMgr nMgr = new NetworkMgr();
            NInformation nInfo = nMgr.GetNetworkInformation();
            if (!nInfo.IsConnected)
            {
                MessageBox.Show("인터넷 연결을 확인하십시오.");
                Process.GetCurrentProcess().Kill();
            }


            // SOME STUFF HERE
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void logoout_btn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegisteryMgr rMgr = new RegisteryMgr();
            rMgr.setUserRegisteryValue("CheerUp", "AutoLogin", "false");
            rMgr.setUserRegisteryValue("CheerUp", "LID", "null");
            rMgr.setUserRegisteryValue("CheerUp", "LALP", "null");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
