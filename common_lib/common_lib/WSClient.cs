using System;
using System.Text;
using System.Linq;
using Crestron.SimplSharp;
using Crestron.SimplSharp.CrestronWebSocketClient;
using Crestron.SimplSharp.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace common_lib
{
    public delegate void PushEventHandler(PushEventArgs e);
    public class WSClient
    {
        private WebSocketClient ws_client = null;
        private WebSocketClient.WEBSOCKET_RESULT_CODES ret;
        public string g_cunit_no;
        public int ping_count;
        public long g_company_id;
        public byte[] sendData = null;
        public byte[] receiveData = null;

        public short PushReceived(int type, string cmd, string device_id, string value)
        {
            PushEvents _event = new PushEvents();
            _event.PushMessage(type, cmd, device_id, value);
            return 1;
        }
        
        public WSClient() { 
        }

        public void initialize_ws() {
            try
            {
                ws_client = new WebSocketClient();
                ws_client.Port = 443;
                ws_client.SSL = true;
                ws_client.SendCallBack = SendCallback;
                ws_client.ReceiveCallBack = ReceiveCallback;
                ws_client.ConnectionCallBack = ConnectionCallBack;
                ws_client.DisconnectCallBack = DisconnectCallBack;
                sendData = System.Text.Encoding.ASCII.GetBytes(g_cunit_no);
                ws_client.URL = CommonUtil.WS_URL + "session_id=" + g_cunit_no;
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("[WSClient.initialize_ws] exception : {0}", ex.ToString());
            }
        }

        public int connect()
        {
            try
            {
                ret = ws_client.Connect();
                if (ret == (int)WebSocketClient.WEBSOCKET_RESULT_CODES.WEBSOCKET_CLIENT_SUCCESS)
                {
                    CrestronConsole.Print("[WSClient.connect] websocket connected");
                }
                else
                {
                    CrestronConsole.PrintLine("[WSClient.connect] websocket could not connect, err: {0}" + ret.ToString());
                }
            }
            catch (Exception ex) {
                CrestronConsole.PrintLine("[WSClient.connect] exception : {0}", ex.ToString());
            }
            
            return (int)ret;
        }

        public int try_to_connect()
        {
            try
            {
                ret = ws_client.Connect();
                if (ping_count >= 2)
                {
                    ping_count = 2;
                }
            }
            catch (Exception ex) {
                CrestronConsole.PrintLine("[WSClient.try_to_connect] exception : {0}", ex.ToString());
            }
            return (int)ret;
        }

        public void ping()
        {
            try
            {
                string message = CommonUtil.FormatPing(g_cunit_no);
                CrestronConsole.PrintLine("[WSClient.ping] ping msg: {0}", message);
                byte[] data_ping = System.Text.Encoding.ASCII.GetBytes(message);
                ws_client.SendAsync(data_ping, (uint)data_ping.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
                ping_count += 1;
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("[WSClient.ping] exception: {0}\r\n", ex.ToString());
            }
        }

        public int ReceiveCallback(byte[] data, uint datalen, 
            WebSocketClient.WEBSOCKET_PACKET_TYPES opcode,
            WebSocketClient.WEBSOCKET_RESULT_CODES error) 
        {
            try
            {
                string data_rcv = Encoding.UTF8.GetString(data, 0, data.Length);
                CrestronConsole.PrintLine("[WSClient.ReceiveCallback] data rcv: {0}", data_rcv);

                if (data_rcv.Trim() != "")
                {
                    JObject obj = JObject.Parse(data_rcv);
                    int msg_type = int.Parse(obj["msg_type"].ToString());
                    string dt = obj["dt"].ToString();
                    switch (msg_type)
                    {
                        case (int)CommonUtil.MSG_TYPE.MSG_PONG:
                            CrestronConsole.PrintLine("[WSClient.ReceiveCallback] rcv PONG");
                            ping_count = 0;
                            break;
                        case (int)CommonUtil.MSG_TYPE.MSG_LIGHT_SWITCH_ONOFF:
                            CrestronConsole.PrintLine("[WSClient.ReceiveCallback] rcv SWITCH ON/OFF");
                            switch_on_off(dt);
                            break;
                        case (int)CommonUtil.MSG_TYPE.MSG_LIGHT_CHANGE_BRIGHTNESS:
                            change_brightness(dt);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex) {
                CrestronConsole.PrintLine("[WSClient.ReceiveCallback] exception : {0}", ex.ToString());
            }
            return 0;
        }

        public void switch_on_off(string dt) {
            long company_id   = 0;
            string light_code   = "";
            string light_onoff  = "";
            int is_dim          = -1;
            try
            {
                JObject obj_dt  = JObject.Parse(dt);
                company_id      = Convert.ToInt64(obj_dt["company_id"].ToString().Trim());
                g_company_id    = company_id;
                light_code      = obj_dt["light_code"].ToString();
                light_onoff     = obj_dt["light_onoff"].ToString();
                is_dim          = Convert.ToInt16(obj_dt["is_dim"].ToString().Trim());
                if (is_dim == 0)
                {
                    //den onoff
                    PushReceived((int)CommonUtil.DEVICE_TYPE.LIGHT_ONOFF, "switch_on_off", light_code, light_onoff);
                }
                else { 
                    //den dim
                    PushReceived((int)CommonUtil.DEVICE_TYPE.LIGHT_DIM, "switch_on_off", light_code, light_onoff);
                }
            }
            catch (Exception ex) {
                CrestronConsole.PrintLine("[WSClient.switch_on_off] exception : {0}", ex.ToString());
            }
        }

        public void change_brightness(string dt) {
            long company_id = 0;
            string light_code = "";
            string brightness = "";
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                company_id = Convert.ToInt64(obj_dt["company_id"].ToString().Trim());
                g_company_id = company_id;
                light_code = obj_dt["light_code"].ToString();
                brightness = obj_dt["brightness"].ToString();
                PushReceived((int)CommonUtil.DEVICE_TYPE.LIGHT_DIM, "change_brightness", light_code, brightness);
            }
            catch (Exception ex) 
            {
                CrestronConsole.PrintLine("[WSClient.change_brightness] exception : {0}", ex.ToString());
            }
        }

        public int SendCallback(WebSocketClient.WEBSOCKET_RESULT_CODES error)
        {
            CrestronConsole.PrintLine("[WSClient.SendCallback] err: {0}" + (int)error);
            return (int)error;
        }

        public int ConnectionCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error) {
            CrestronConsole.PrintLine("[WSClient.ConnectionCallBack] err: {0}" + error);
            return (int)error;
        }

        public int DisconnectCallBack(WebSocketClient.WEBSOCKET_RESULT_CODES error, object obj)
        {
            CrestronConsole.PrintLine("[WSClient.DisconnectCallBack] err: {0}" + (int)error);
            return (int)error;
        }

        public void AsyncSendAndReceive()
        {
            try
            {
                ws_client.SendAsync(sendData, (uint)sendData.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("[WSClient.AsyncSendAndReceive] exeption {0}", ex.ToString());
            }
        }

        public void LightOnoff(string light_code, int on_off, int brightness) {
            try 
            {
                string data = CommonUtil.FormatMsgLightOnOff(g_company_id, light_code, on_off, brightness);
                CrestronConsole.PrintLine("data light onoff: {0}", data);
                byte[] data_byte = System.Text.Encoding.ASCII.GetBytes(data);
                ws_client.SendAsync(data_byte, (uint)data_byte.Length, WebSocketClient.WEBSOCKET_PACKET_TYPES.LWS_WS_OPCODE_07__TEXT_FRAME, WebSocketClient.WEBSOCKET_PACKET_SEGMENT_CONTROL.WEBSOCKET_CLIENT_PACKET_END);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("[WSClient.LightOnoff] exeption {0}", ex.ToString());
            }
        }
    }
}