using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Net;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wsclient_pro.common
{
    enum TYPE{
        WEBSOCKET = 0,
        LIGHT
    }
    class Common {
        public static bool isJsonObject(String data) {
            bool result = false;
            try
            {
                JObject obj = JObject.Parse(data);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            
            return result;
        }
        public void getListIP() {
            string local_name = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(local_name);
            IPAddress[] IPaddr = ip.AddressList;
            for (int i = 0; i < IPaddr.Length; i++)
            {
                CrestronConsole.PrintLine("IP Address {0}: {1} ", i, IPaddr[i].ToString());
            }
        }
        public string getMyIP() {
            string local_ip = "";
            string local_name = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(local_name);
            IPAddress[] IPaddr = ip.AddressList;
            local_ip = IPaddr[0].ToString();
            CrestronConsole.PrintLine("Local IP: {0}", local_ip);
            return local_ip;
        }
        public string getSystemInfor() {
            string result = "";
            
            return result;
        }
        public string getMACAddress() {
            string result = "";
            
            return result;
        }
        public static void getCresnetID() {
            ReadOnlyCollection<CrestronCresnetHelper.DiscoveredDeviceElement> list = CrestronCresnetHelper.DiscoveredElementsList;
            for (int i = 0; i < list.Count; i++)
            {
                string id = list[0].CresnetId.ToString();
                CrestronConsole.PrintLine("id: {0}", id);
            }
        }
    }
}