using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.Network
{
    public partial class SocketManager
    {
        public delegate void SocketEventHandler(object sender, object resp);
        
        Socket socket = IO.Socket("http://35.220.152.156:80");
        public void Emit(string eventName, JObject data)
        {
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit(eventName, data);
            });
        }

        public void EventOn(string eventName, SocketEventHandler OnDataGetEnded)
        {
            socket.On(eventName, (data) =>
            {
                if (data != null)
                {
                    if (OnDataGetEnded != null)
                    {
                        OnDataGetEnded(this, data);
                    }
                }
            });
        }
    }
}
