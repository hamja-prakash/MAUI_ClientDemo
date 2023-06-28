using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Demo.Helpers
{
    public class ConnectionService
    {
        public static bool IsConnected()
        {
            bool connected = false;
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                connected = true;
            return connected;
        }
    }
}
