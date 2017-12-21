using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronIO;
using System.Collections.ObjectModel;
namespace wsclient_pro.common
{
    public class GatewayInfor
    {
        ReadOnlyCollection<CrestronCresnetHelper.DiscoveredDeviceElement> list = CrestronCresnetHelper.DiscoveredElementsList;
        CrestronCresnetHelper.eCresnetDiscoveryReturnValues _a = CrestronCresnetHelper.DiscoverAllDevices();
        
        public void getVersion() {
            int i = list.Count;
            CrestronConsole.PrintLine("Gateway version: {0}", i);
        }
    }
}