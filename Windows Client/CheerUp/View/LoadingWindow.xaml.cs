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
using System.Windows.Shapes;
using SQ_CRE;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CheerUp.View
{
    /// <summary>
    /// LoadingWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NetworkMgr nMgr = new NetworkMgr();
            NInformation nInfo = new NInformation();
            nInfo = nMgr.GetNetworkInformation();
            if(nInfo.IsConnected == true)
            {
                //Loading Window Close
                this.Hide();

                RegisteryMgr rMgr = new RegisteryMgr();
                try
                {
                    Object res = rMgr.getUserRegisteryValue("CheerUp", "AutoLogin");
                    if (((string)res).Equals("true"))
                    {
                        bool result_login = login((string)rMgr.getUserRegisteryValue("CheerUp", "LID"), (string)rMgr.getUserRegisteryValue("CheerUp", "LALP"));
                        if (result_login)
                        {
                            MainWindow mWindow = new MainWindow();
                            mWindow.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            LoginWindow lWindow = new LoginWindow();
                            lWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                            System.Drawing.Rectangle screen = System.Windows.Forms.SystemInformation.VirtualScreen;
                            lWindow.Left = Convert.ToInt32(screen.Right - lWindow.Width - 10);
                            lWindow.Top = Convert.ToInt32(screen.Bottom - lWindow.Height - 50);
                            lWindow.ShowDialog();
                        }
                    }
                    else
                    {
                        LoginWindow lWindow = new LoginWindow();
                        lWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                        System.Drawing.Rectangle screen = System.Windows.Forms.SystemInformation.VirtualScreen;
                        lWindow.Left = Convert.ToInt32(screen.Right - lWindow.Width - 10);
                        lWindow.Top = Convert.ToInt32(screen.Bottom - lWindow.Height - 50);
                        lWindow.ShowDialog();
                    }
                }
                catch (Exception)
                {
                    LoginWindow lWindow = new LoginWindow();
                    lWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                    System.Drawing.Rectangle screen = System.Windows.Forms.SystemInformation.VirtualScreen;
                    lWindow.Left = Convert.ToInt32(screen.Right - lWindow.Width - 10);
                    lWindow.Top = Convert.ToInt32(screen.Bottom - lWindow.Height - 50);
                    lWindow.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("인터넷 연결을 확인하십시오.");
                Process.GetCurrentProcess().Kill();
            }
            this.Close();
        }

        private bool login(string inputId, string inputPw)
        {
            bool isRight = false;

            App.socketManager.OnLogin(inputId, inputPw);

            App.socketManager.EventOn("login_res", (s, e) =>
            {
                isRight = (bool)e;
                if (isRight)
                {
                    App.Current.Dispatcher.Invoke(() => { // 크로스 스레드를 해결하기 위한 방법
                        MainWindow mWindow = new MainWindow();
                        mWindow.Show();
                    });
                }
                else
                {
                    MessageBox.Show("로그인에 실패했습니다.\n" + "아이디 / 비밀번호를 확인해주세요.");
                }
            });

            return isRight;
            //socket.On("login_res", (data) =>
            //{
            //    Debug.WriteLine(data);

            //    if (data != null)
            //    {
            //        switch (data)
            //        {
            //            case true:
            //                result = true;
            //                break;

            //            case false:
            //                result = false;
            //                break;

            //            default:
            //                result = false;
            //                break;
            //        }
            //    }
            //    isend = true;
            //});
        }
    }
}
