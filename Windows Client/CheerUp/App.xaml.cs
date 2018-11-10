using CheerUp.Network;
using CheerUp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CheerUp
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class App : Application
    {
        public static SocketManager socketManager = new SocketManager();
        public static UserViewModel userViewModel = new UserViewModel();
        public static PlaceViewModel placeViewModel = new PlaceViewModel();
    }
}
