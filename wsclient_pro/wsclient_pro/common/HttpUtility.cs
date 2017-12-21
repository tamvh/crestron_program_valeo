using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Newtonsoft.Json.Linq;

namespace wsclient_pro
{
    public class HttpUtility
    {
        static HttpUtility()
        { 
            
        }

        public static string FormatResponse(int err, string msg, JObject dt)
        {
            string res = "";
            JObject obj = new JObject();
            obj["err"] = err;
            obj["msg"] = msg;
            obj["dt"] = dt.ToString();
            res = obj.ToString();
            return res;
        }

        public static string FormatResponse(int err, string msg)
        {
            string res = "";
            JObject obj = new JObject();
            obj["err"] = err;
            obj["msg"] = msg;
            res = obj.ToString();
            return res;
        }
    }
}