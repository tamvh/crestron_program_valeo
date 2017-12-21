using System;
using System.Text;
using System.Linq;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronWebSocketClient;
using Crestron.SimplSharp.Scheduler;
using Crestron.SimplSharp.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace wsclient_pro
{
    public delegate void PushEventHandler(PushEventArgs e);
    public class WSClientService
    {
        private WebSocketClient ws_client;
        private WebSocketClient.WEBSOCKET_RESULT_CODES ret;
        private WebSocketClient.WEBSOCKET_RESULT_CODES wrc;
        private String DataToSend = "abc123";
        public byte[] SendData = null;
        public byte[] ReceiveData;
        public string Access_Code;
        public bool isConnected = false;
        public int countPingConnectServer = 0;
        public long session_id = 54880; //54870
        public WSClientService() { 
            
        }
        public void getLocalIP() {
            string local_name = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(local_name);
            IPAddress[] IPaddr = ip.AddressList;
            for (int i = 0; i < IPaddr.Length; i++)
            {
                CrestronConsole.PrintLine("IP Address {0}: {1} ", i, IPaddr[i].ToString());
            }
        }
        public void init() {
            ws_client = new WebSocketClient();
            ws_client.Port = 443;
            ws_client.SSL = true;
            ws_client.SendCallBack = SendCallback;
            ws_client.ReceiveCallBack = ReceiveCallback;
            ws_client.ConnectionCallBack = ConnectionCallBack;
            ws_client.DisconnectCallBack = DisconnectCallBack;
            SendData = System.Text.Encoding.ASCII.GetBytes(DataToSend);
            ws_client.URL = "wss://iot-dev.wahsis.net/gateway/ntf/?session_id=" + session_id;
            wsclient_pro.common.Common.getCresnetID();
        }
        public short PushReceived(int type, string cmd, string device_id, string value)
        {
            PushEvents PE = new PushEvents();
            PE.PushMessage(type, cmd, device_id, value);
            return 1;
        }
        public int connect()
        {
            wrc = ws_client.Connect(); // ket noi toi server
            if (wrc == (int)WebSocketClient.WEBSOCKET_RESULT_CODES.WEBSOCKET_CLIENT_SUCCESS)
            {
                CrestronConsole.Print("Websocket connected \r\n");
            }
            else
            {
                CrestronConsole.PrintLine("Websocket could not connect to server.  Connect return code: " + wrc.ToString());
                //PushReceived((int)wsclient_pro.common.TYPE.WEBSOCKET, "disconnected", "", "");
            }
            return (int)wrc;
        }

        public int ConnectionCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            CrestronConsole.PrintLine("Conneted");
            return (int)error;
        }

        public void reConnect() {
            try
            {
                ws_client = new WebSocketClient();
                init();
                while (true)
                {
                    CrestronConsole.PrintLine("reconneted...");
                    CrestronEnvironment.Sleep(1000);
                    wrc = ws_client.Connect();
                    if (wrc == (int)WebSocketClient.WEBSOCKET_RESULT_CODES.WEBSOCKET_CLIENT_SUCCESS)
                    {
                        CrestronConsole.Print("Websocket reconnected \r\n");
                        break;
                    }
                }
                CrestronEnvironment.Sleep(100);
                AsyncSendAndReceive();
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex reConnect: {0}\r\n", ex.ToString());
            }
            
        }

        public int try_to_connect()
        {
            WebSocketClient.WEBSOCKET_RESULT_CODES result = ws_client.Connect();
            return (int)result;
        }

        public int getConnected()
        {
            if (ws_client.Connected)
                return 1;
            return 0;
        }

        public void Disconnect()
        {
            CrestronConsole.PrintLine("Websocket disconnected. \r\n");
            ws_client.Disconnect();
        }

        public void sendPingMsg()
        {
            try
            {
                string message = "PING";
                CrestronConsole.PrintLine("Ping Message: {0}", message);
                byte[] data_ping = System.Text.Encoding.ASCII.GetBytes(message);
                ws_client.SendAsync(data_ping, (uint)data_ping.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex sendPingMsg: {0}\r\n", ex.ToString());
            }
        }

        public int DisconnectCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error, object obj)
        {
            CrestronConsole.PrintLine("Disconnect");
            return (int)error;
        }

        public int SendCallback(WebSocketClient.WEBSOCKET_RESULT_CODES error)
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

        public int ReceiveCallback(byte[] data, uint datalen, WebSocketClient.WEBSOCKET_PACKET_TYPES opcode, WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            try
            {
                string s = Encoding.UTF8.GetString(data, 0, data.Length);
                CrestronConsole.PrintLine("receive callback: {0}\r\n", s);
                
                if (s.Trim() != "")
                {
                    if (s.Trim() == "PONG") {
                        PushReceived((int)wsclient_pro.common.TYPE.WEBSOCKET, "PONG", "", "");
                        return 0;
                    }
                    JObject obj = JObject.Parse(s);
                    string cm = obj["cm"].ToString();
                    string dt = obj["dt"].ToString();
                    CrestronConsole.PrintLine("cm: " + cm);
                    CrestronConsole.PrintLine("dt: " + dt);
                    if (String.Compare(cm,"switch_on_off") == 0)
                    {
                        CrestronConsole.PrintLine("switch_on_off");
                        switch_on_off(dt);
                    }
                    if (String.Compare(cm, "change_brightness") == 0)
                    {
                        change_brightness(dt);
                    }
                    if (String.Compare(cm, "switch_on_off_group") == 0)
                    {
                        switch_on_off_group(dt);
                    }
                    if (String.Compare(cm, "change_brightness_group") == 0)
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

        public void switch_on_off(string dt)
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
                CrestronConsole.PrintLine("Ex switch_on_off: {0}\r\n", ex.ToString());
            }

        }

        public void switch_on_off_group(string dt)
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
                CrestronConsole.PrintLine("Ex switch_on_off_group: {0}\r\n", ex.ToString());
            }
        }

        public void change_brightness(string dt)
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
                CrestronConsole.PrintLine("Ex change_brightness: {0}\r\n", ex.ToString());
            }
        }

        public void change_brightness_group(string dt)
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
                CrestronConsole.PrintLine("Ex change_brightness_group: {0}\r\n", ex.ToString());
            }
        }

        public void AsyncSendAndReceive()
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