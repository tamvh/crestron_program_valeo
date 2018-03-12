using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Newtonsoft.Json.Linq;

namespace common_lib
{
    public class CommonUtil
    {
        public static string WSS_URL            = "wss://iot-dev.wahsis.net/gateway/ntf/?";
        public static string WS_URL             = "";
        public static string HTTP_SERVER_URL    = "";
        public static string HTTPS_SERVER_URL   = "";

        public enum DEVICE_TYPE
        {
            WEBSOCKET = 0,
            LIGHT_ONOFF,
            LIGHT_DIM
        }

        public enum MSG_TYPE {
            MSG_REQUEST                     = 0,
            MSG_RESPONSE                    = 1000,
            //define message type of request
            MSG_PING                        = MSG_REQUEST + 1,
            //define message type of response
            MSG_PONG                        = MSG_RESPONSE + 1,
            MSG_LIGHT_SWITCH_ONOFF          = MSG_RESPONSE + 2,
            MSG_LIGHT_CHANGE_BRIGHTNESS     = MSG_RESPONSE + 3,
            MSG_LIGHT_SWITCH_ONOFF_GROUP    = MSG_RESPONSE + 4
        }

        public static string FormatPing(string cunit_no)
        {
            string str = "";
            JObject obj = new JObject();
            obj["msg_type"] = (int)MSG_TYPE.MSG_PING;
            JObject dt = new JObject();
            dt["msg"] = "ping form " + cunit_no;
            obj["dt"] = dt.ToString();
            str = obj.ToString();
            return str;
        }

        public static string FormatMsgLightOnOff(long company_id, string light_code, int on_off, int brightness)
        {
            string res = "";
            JObject obj = new JObject();
            JObject dt = new JObject();

            JObject obj_light = new JObject();
            obj_light["light_code"] = light_code;
            obj_light["on_off"] = on_off;
            obj_light["brightness"] = brightness;
            JObject obj_company = new JObject();
            obj_company["company_id"] = company_id;
            obj["light"] = obj_light;
            obj["company"] = obj_company;
            dt["msg_type"] = (int)MSG_TYPE.MSG_LIGHT_SWITCH_ONOFF;
            dt["dt"] = obj;
            res = dt.ToString();
            return res;
        }
    }
}
