using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;
using Crestron.SimplSharp.Net.Http;
using System.Net.Sockets;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace wsclient_pro
{
    public class HttpServerService {
        HttpServer server;
        
        public HttpServerService() {
            server = new HttpServer();
            server.OnHttpRequest += new OnHttpRequestHandler(process);
        }

        public void startListening(int portNumber)
        {
            try
            {
                server.Port = portNumber;
                server.Open();
                CrestronConsole.PrintLine("start service");
            }
            catch (Exception e)
            {
                ErrorLog.Error("Unable to open http server for http server service (" + e.ToString() + ")");
            }
        }

        void process(object sender, OnHttpRequestArgs e)
        {
            try
            {
                if (!e.Request.HasContentLength)
                {
                    CrestronConsole.PrintLine("Content null");
                    return;
                }
                string content = e.Request.ContentString;
                CrestronConsole.PrintLine("content: " + content);
                string path = e.Request.Path;
                CrestronConsole.PrintLine("path: " + path);
                if (path == "/smart/api/light/")
                {
                    new wsclient_pro.controller.LightController(content, e);
                }
                e.Response.KeepAlive = false;
            }
            catch (Exception ex)
            {
                CrestronConsole.PrintLine("Ex process: {0}\r\n", ex.ToString());
            }

        }
    }
}