using System;
using System.Text;
using System.Linq;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronWebSocketClient;
using Crestron.SimplSharp.Scheduler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace wsclient_pro
{
    public class WebSocketClientService
    {
        private static WebSocketClient ws_client = new WebSocketClient();
        private static WebSocketClient.WEBSOCKET_RESULT_CODES ret;
        private static WebSocketClient.WEBSOCKET_RESULT_CODES wrc;
        private static String DataToSend = "abc123";
        public static byte[] SendData = null;
        public static byte[] ReceiveData;
        public static long session_id = 54880;

        public WebSocketClientService()
        {
            
        }

        public static short PushReceived(int type, string cmd, string device_id, string value) {
            PushEvents PE = new PushEvents();
            PE.PushMessage(type, cmd, device_id, value);
            return 1;
        } 

        public static void init_ws()
        {
            ws_client.Port = 443;
            ws_client.SSL = true;
            ws_client.SendCallBack = SendCallback;
            ws_client.ReceiveCallBack = ReceiveCallback;
            ws_client.ConnectionCallBack = ConnectionCallBack;
            ws_client.DisconnectCallBack = DisconnectCallBack;
            SendData = System.Text.Encoding.ASCII.GetBytes(DataToSend);
            ws_client.URL = "wss://iot-dev.wahsis.net/gateway/ntf/?session_id=" + session_id;
        }

        public static int ConnectionCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            CrestronConsole.PrintLine("Conneted");
            return (int)error; 
        }

        public static int connect()
        {
            wrc = ws_client.Connect(); // ket noi toi server
            if (wrc == (int)WebSocketClient.WEBSOCKET_RESULT_CODES.WEBSOCKET_CLIENT_SUCCESS)
            {
                CrestronConsole.Print("Websocket connected \r\n");
            }
            else
            {
                CrestronConsole.PrintLine("Websocket could not connect to server.  Connect return code: " + wrc.ToString());
                PushReceived((int)wsclient_pro.common.TYPE.WEBSOCKET, "disconnected", "", "");
            }
            return (int)wrc;
        }

        public static int try_to_connect()
        {
            WebSocketClient.WEBSOCKET_RESULT_CODES result = ws_client.Connect();
            return (int)result;
        }

        public static int getConnected()
        {
            if (ws_client.Connected)
                return 1;
            return 0;
        }

        public static void Disconnect()
        {
            CrestronConsole.PrintLine("Websocket disconnected. \r\n");
            ws_client.Disconnect();
        }

        public static void sendPingMsg()
        {
            var jsonObj = new JObject();
            jsonObj["msg_type"] = 1;
            jsonObj["session_id"] = session_id;
            jsonObj["dt"] = "Ping from client";
            string message = JsonConvert.SerializeObject(jsonObj);
            CrestronConsole.PrintLine("Ping Messageff: {0}", message);
            ws_client.SendAsync(System.Text.Encoding.Unicode.GetBytes(message), (uint)message.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
        }

        public static int DisconnectCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error, object obj)
        {
            CrestronConsole.PrintLine("Disconnect");
            return (int)error;
        }

        public static int SendCallback(WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            try
            {
                ret = ws_client.ReceiveAsync();
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Ex SendCallback: {0}\r\n", e.ToString());
                return -1;
            }
            return 0;
        }

        public static int ReceiveCallback(byte[] data, uint datalen, WebSocketClient.WEBSOCKET_PACKET_TYPES opcode, WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            try
            {
                string s = Encoding.UTF8.GetString(data, 0, data.Length);
                CrestronConsole.PrintLine("receive callback: {0}\r\n", s);
                if (s.Trim() == "") {
                    CrestronConsole.PrintLine("push disconnected.");
                    PushReceived((int)wsclient_pro.common.TYPE.WEBSOCKET, "disconnected", "", "");
                }
                if (s.Trim() != "")
                {
                    JObject obj = JObject.Parse(s);
                    string cm = obj["cm"].ToString();
                    string dt = obj["dt"].ToString();
                    if (cm.CompareTo("switch_on_off") == 0)
                    {
                        switch_on_off(dt);
                    }
                    if (cm.CompareTo("change_brightness") == 0)
                    {
                        change_brightness(dt);
                    }
                    if (cm.CompareTo("switch_on_off_group") == 0)
                    {
                        switch_on_off_group(dt);
                    }
                    if (cm.CompareTo("change_brightness_group") == 0)
                    {
                        change_brightness_group(dt);
                    }
                }
                AsyncSendAndReceive();
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", e.ToString());
                return -1;
            }
            return 0;
        }

        public static void switch_on_off(string dt)
        {
            string light_code;
            string light_onoff;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                light_code = obj_dt["light_code"].ToString();
                light_onoff = obj_dt["light_onoff"].ToString();
                PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "switch_on_off", light_code, light_onoff);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", ex.ToString());
            }

        }

        public static void switch_on_off_group(string dt)
        {
            string list_light_code;
            string light_onoff;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                list_light_code = obj_dt["list_light_code"].ToString();
                string[] arr_light_code = list_light_code.Split(',');
                light_onoff = obj_dt["light_onoff"].ToString();
                for (int i = 0; i < arr_light_code.Length; i++)
                {
                    string light_code = arr_light_code[i];
                    PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "switch_on_off", light_code, light_onoff);
                }
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", ex.ToString());
            }
        }

        public static void change_brightness(string dt)
        {
            string light_code;
            string light_onoff;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                light_code = obj_dt["light_code"].ToString();
                light_onoff = obj_dt["light_onoff"].ToString();
                PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "change_brightness", light_code, light_onoff);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", ex.ToString());
            }
        }

        public static void change_brightness_group(string dt)
        {
            string list_light_code;
            string brightness;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                list_light_code = obj_dt["list_light_code"].ToString();
                string[] arr_light_code = list_light_code.Split(',');
                brightness = obj_dt["brightness"].ToString();
                for (int i = 0; i < arr_light_code.Length; i++)
                {
                    string light_code = arr_light_code[i];
                    PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "change_brightness", light_code, brightness);
                }
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", ex.ToString());
            }
        }

        public static void AsyncSendAndReceive()
        {
            try
            {
                ws_client.SendAsync(SendData, (uint)SendData.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
            }
            catch (Exception e)
            {
                CrestronConsole.PrintLine("Ex AsyncSendAndReceive: %s\r\n", e.ToString());
                Disconnect();
            }
        }
    }
}
