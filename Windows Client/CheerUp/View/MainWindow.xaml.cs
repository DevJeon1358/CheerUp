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
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace CheerUp
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Timer serverConnectCheck = new System.Windows.Forms.Timer();
        BackgroundWorker serverChecker = new BackgroundWorker();
        private bool isLogout = false;
        private Place curPlace = new Place();

        public MainWindow()
        {
            InitializeComponent();
            this.send_textbox.DataContext = this;
        }

        private void ServerChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                NetworkMgr nMgr = new NetworkMgr();
                if (nMgr.IsServerConnectionUseable("35.220.152.156"))
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        root_border.Background = new SolidColorBrush(Color.FromRgb(103, 58, 183));
                        connetion_info_label.Content = "연결됨";
                    });
                }
                else
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        root_border.Background = new SolidColorBrush(Color.FromRgb(230, 52, 52));
                        connetion_info_label.Content = "접속 불가";
                    });
                }
            }
            catch (Exception)
            { }
        }



        private void ServerConnectCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                serverChecker.RunWorkerAsync();
            }
            catch (Exception) { }
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
                Debug.WriteLine("Event On init (From MainWindow)");
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
            App.socketManager.EventOn("getplace_res", (s, e) =>
            {
                Debug.WriteLine("Event On getplace_res (From MainWindow)");
                foreach (Place item in (List<Place>)e)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //서버 연결 상태 확인
            serverChecker.DoWork += ServerChecker_DoWork;
            serverChecker.WorkerSupportsCancellation = true;
            serverConnectCheck.Interval = 3000;
            serverConnectCheck.Tick += ServerConnectCheck_Tick;
            serverConnectCheck.Start();
            InitPlace();
            getMessage();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(send_textbox.Text))
            {
                App.socketManager.Emit("addmessage", JObject.FromObject(new { Content = send_textbox.Text, Place = 1 }));
                Debug.WriteLine("addmessage called (from mainwindow)");
                send_textbox.Text = string.Empty;
            }
        }
    }
}
