using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace CheerUp.Network
{
    public partial class NetworkManager
    {
        Socket socket = IO.Socket("http://35.220.152.156:80");

        public NetworkManager()
        {
            ConnectTo();
        }

        private void ConnectTo()
        {

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                JObject loginData = JObject.FromObject(new { Id = "test", Password = "1234" });
                socket.Emit("login", loginData);
            });

            socket.On("login_res", (data) =>
            {
                if(data != null) { 
                    Debug.WriteLine(data);
                    socket.Disconnect();
                }
            });

        }
    }
}
