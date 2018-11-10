using CheerUp.Model;
using SQ_CRE;
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
    public partial class LoginWindow : Window
    {
        //회원가입 주소
        private string RegisterUrl = "http://weburl.com";


        public LoginWindow()
        {
            InitializeComponent();

            this.DataContext = App.userViewModel.user;
        }


        public void ShowRegisterForm(object sender, RoutedEventArgs e)
        {
            try
            {
                //회원가입 URL 뛰우기
                Process.Start(RegisterUrl);
            }
            catch (Exception)
            {
                //브라우저 문제
                MessageBox.Show("회원가입 창을 띄우는데 실패했습니다.\n" + RegisterUrl + "주소로 접속을 시도해보십시오.");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string inputId = ((User)this.DataContext).Id;
            string inputPw = ((User)this.DataContext).Password;

            //자동 로그인 정보 등록
            if (AutoLogin_Checkbox.IsChecked == true)
            {
                RegisteryMgr rMgr = new RegisteryMgr();
                rMgr.setUserRegisteryValue("CheerUp", "AutoLogin", "true");
                rMgr.setUserRegisteryValue("CheerUp", "LID", id_textbox.Text);
                rMgr.setUserRegisteryValue("CheerUp", "LALP", id_textbox.Text);
            }

            if (inputId != string.Empty && inputPw != string.Empty)
            {
                login(inputId, inputPw);
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다.\n" + "입력 양식을 확인해주세요.");
            }
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

                        getPlace();
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

        private void getPlace()
        {
            App.socketManager.GetPlaceList();
            App.socketManager.EventOn("getplace_res", (s, e) => 
            {
                foreach(Place item in (List<Place>)e)
                {
                    App.placeViewModel.Add(item);
                }
            });
        }

        private void password_textbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            App.userViewModel.user.Password = password_textbox.Password;
        }
    }

}
