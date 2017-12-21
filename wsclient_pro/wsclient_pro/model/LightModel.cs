using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Newtonsoft.Json.Linq;

namespace wsclient_pro.model
{
    public class LightModel
    {
        string url = "http://iot-dev.wahsis.net";
        HttpClientService client;
        HttpsClientService clients;
        public LightModel()
        {
            client = new HttpClientService();
            clients = new HttpsClientService();
        }
        public string update_data_light_switch_on_off(string dt) {
            string res_data = "";
            string path = "/smart/api/light/";
            string uri = "";
            try
            {
                uri = url + path + "?cm=update_data_switch_on_off&dt=" + dt;
                CrestronConsole.PrintLine("update_data_light_switch_on_off: {0}", uri);
                res_data = client.doGet(uri);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex update_data_light_switch_on_off: {0}\r\n", ex.ToString());
                res_data = HttpUtility.FormatResponse(-1, "unknown");
                return res_data;
            }
            return res_data;
        }
        public string update_data_light_change_brightness(string dt) {
            string res_data = "";
            string path = "/smart/api/light/";
            string uri = "";
            try
            {
                uri = url + path + "?cm=update_data_change_brightness&dt=" + dt;
                CrestronConsole.PrintLine("update_data_light_change_brightness: {0}", uri);
                res_data = client.doGet(uri);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex update_data_light_change_brightness: {0}\r\n", ex.ToString());
                res_data = HttpUtility.FormatResponse(-1, "unknown");
                return res_data;
            }
            return res_data;
        }
        public string update_data_light_switch_on_off_group(string dt) {
            string res_data = "";
            string path = "/smart/api/light/";
            string uri = "";
            try
            {
                uri = url + path + "?cm=update_data_switch_on_off_group&dt=" + dt;
                CrestronConsole.PrintLine("update_data_switch_on_off_group: {0}", uri);
                res_data = client.doGet(uri);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex update_data_light_switch_on_off_group: {0}\r\n", ex.ToString());
                res_data = HttpUtility.FormatResponse(-1, "unknown");
                return res_data;
            }
            return res_data;
        }
        public string update_data_light_change_brightness_group(string dt) {
            string res_data = "";
            string path = "/smart/api/light/";
            string uri = "";
            try
            {
                uri = url + path + "?cm=update_data_change_brightness_group&dt=" + dt;
                CrestronConsole.PrintLine("update_data_change_brightness_group: {0}", uri);
                res_data = client.doGet(uri);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex update_data_light_change_brightness_group: {0}\r\n", ex.ToString());
                res_data = HttpUtility.FormatResponse(-1, "unknown");
                return res_data;
            }
            return res_data;
        }
    }
}