using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Net.Http;
using Newtonsoft.Json.Linq;


namespace wsclient_pro.controller
{
    public class LightController
    {
        wsclient_pro.model.LightModel lightModel;
        public LightController(string data, OnHttpRequestArgs e) {
            string res_content = "";
            try
            {
                lightModel = new wsclient_pro.model.LightModel();
                JObject obj_content = JObject.Parse(data);
                string cm = obj_content["cm"].ToString();
                string dt = obj_content["dt"].ToString();
                switch (cm)
                {
                    case "switch_on_off":
                        res_content = switch_on_off(dt);
                        break;
                    case "change_brightness":
                        res_content = change_brightness(dt);
                        break;
                    case "switch_on_off_group":
                        res_content = switch_on_off_group(dt);
                        break;
                    case "change_brightness_group":
                        res_content = change_brightness_group(dt);
                        break;
                }
                
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex light_controller: {0}\r\n", ex.ToString());
                e.Response.ContentString = HttpUtility.FormatResponse(-1, "unknown");
                return;
            }
            e.Response.ContentString = res_content;
        }
        public static short PushReceived(int type, string cmd, string device_id, string value)
        {
            PushEvents PE = new PushEvents();
            PE.PushMessage(type, cmd, device_id, value);
            return 1;
        }

        public string switch_on_off_group(string dt)
        {
            string update_result = "";
            string content = "";
            string list_light_code;
            string light_onoff;
            string company_id;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                JObject obj_light = JObject.Parse(obj_dt["light"].ToString());
                JObject obj_company = JObject.Parse(obj_dt["company"].ToString());
                list_light_code = obj_light["list_light_code"].ToString();
                string[] arr_light_code = list_light_code.Split(',');
                int on_off = int.Parse(obj_light["on_off"].ToString());
                if (on_off == 0)
                {
                    light_onoff = "0";
                }
                else
                {
                    light_onoff = "65535";
                }
                company_id = obj_company["company_id"].ToString();
                for (int i = 0; i < arr_light_code.Length; i++)
                {
                    string light_code = arr_light_code[i];
                    PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "switch_on_off", light_code, light_onoff);
                }
                update_result = lightModel.update_data_light_switch_on_off_group(dt);
                CrestronConsole.PrintLine("update result: {0}", update_result);
                JObject job_update_result = JObject.Parse(update_result);
                if (int.Parse(job_update_result["err"].ToString()) == 0)
                {
                    content = HttpUtility.FormatResponse(0, "switch onoff group success");
                }
                else
                {
                    content = HttpUtility.FormatResponse(-1, "unknown");
                }
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex ReceiveCallback: {0}\r\n", ex.ToString());
                return HttpUtility.FormatResponse(-1, "unknown");
            }

            return content;
        }

        public string change_brightness_group(string dt)
        {
            string content = "";

            return content;
        }

        public string change_brightness(string dt)
        {
            string update_result = "";
            string content = "";
            string light_code;
            string light_onoff;
            string company_id;
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                JObject obj_light = JObject.Parse(obj_dt["light"].ToString());
                JObject obj_company = JObject.Parse(obj_dt["company"].ToString());
                light_code = obj_light["light_code"].ToString();
                int brightness = int.Parse(obj_light["brightness"].ToString());
                light_onoff = (brightness * (65535 / 100)) + "";
                company_id = obj_company["company_id"].ToString();
                PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "change_brightness", light_code, light_onoff);
                update_result = lightModel.update_data_light_change_brightness(dt);
                CrestronConsole.PrintLine("update result: {0}", update_result);
                JObject job_update_result = JObject.Parse(update_result);
                if (int.Parse(job_update_result["err"].ToString()) == 0)
                {
                    content = HttpUtility.FormatResponse(0, "change brightness success");
                }
                else
                {
                    content = HttpUtility.FormatResponse(-1, "unknown");
                }
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex change_brightness: {0}\r\n", ex.ToString());
                return HttpUtility.FormatResponse(-1, "unknown");
            }

            return content;
        }

        public string switch_on_off(string dt)
        {
            string content = "";
            string light_code;
            string light_onoff;
            string company_id;
            string update_result = "";
            try
            {
                JObject obj_dt = JObject.Parse(dt);
                JObject obj_light = JObject.Parse(obj_dt["light"].ToString());
                JObject obj_company = JObject.Parse(obj_dt["company"].ToString());
                light_code = obj_light["light_code"].ToString();
                int on_off = int.Parse(obj_light["on_off"].ToString());
                if (on_off == 0)
                {
                    light_onoff = "0";
                }
                else
                {
                    light_onoff = "65535";
                }
                company_id = obj_company["company_id"].ToString();
                PushReceived((int)wsclient_pro.common.TYPE.LIGHT, "switch_on_off", light_code, light_onoff);
                update_result = lightModel.update_data_light_switch_on_off(dt);
                CrestronConsole.PrintLine("update result: {0}", update_result);
                JObject job_update_result = JObject.Parse(update_result);
                if (int.Parse(job_update_result["err"].ToString()) == 0)
                {
                    content = HttpUtility.FormatResponse(0, "switch onoff success");
                }
                else {
                    content = HttpUtility.FormatResponse(-1, "unknown");
                }
                
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex switch_on_off: {0}\r\n", ex.ToString());
                return HttpUtility.FormatResponse(-1, "unknown");
            }

            return content;
        }
    }
}