using Newtonsoft.Json.Linq;
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

        public void OnLogin(string id, string password)
        {
            JObject json = JObject.FromObject(new { Id = id, Password = password });
            Emit("login", json);
        }
    }
}
