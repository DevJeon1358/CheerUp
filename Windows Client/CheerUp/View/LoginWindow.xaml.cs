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
                MessageBox.Show("회원가입 창을 뛰우는데 실패했습니다.\n" + RegisterUrl + "주소로 접속을 시도해보십시오.");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //자동 로그인 정보 등록
            if (AutoLogin_Checkbox.IsChecked == true)
            {
                RegisteryMgr rMgr = new RegisteryMgr();
                rMgr.setUserRegisteryValue("CheerUp", "AutoLogin", "true");
                rMgr.setUserRegisteryValue("CheerUp", "LID", id_textbox.Text);
                rMgr.setUserRegisteryValue("CheerUp", "LALP", id_textbox.Text);
            }

            //로그인 수행 후 최종 폼 보이기
            MainWindow mWindow = new MainWindow();
            mWindow.Show();

            this.Close();
        }
    }
}
