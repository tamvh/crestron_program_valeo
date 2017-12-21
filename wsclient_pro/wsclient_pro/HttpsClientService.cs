using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Net.Https;
using Newtonsoft.Json.Linq;

namespace wsclient_pro
{
    public class HttpsClientService
    {
        HttpsClient client;
        public HttpsClientService()
        {
            client = new HttpsClient();
            
        }

        public string doGet(string url)
        {
            string res = "";
            try
            {
                
                res = client.Get(url);
                CrestronConsole.PrintLine("response data(get): {0}", res);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("ex doGet: {0}", ex.ToString());
            }

            return res;
        }
        public string doPost(string url, string content)
        {
            string res = "";
            try
            {
                res = client.Post(url, Encoding.ASCII.GetBytes(content));
                CrestronConsole.PrintLine("response data(post): {0}", res);
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("ex doGet: {0}", ex.ToString());
            }
            return res;
        }
    }
}