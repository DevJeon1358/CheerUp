using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheerUp.Network
{
    public partial class SocketManager
    {
        public void GetPlaceList()
        {
            Emit("getplace");
        }
    }
}
