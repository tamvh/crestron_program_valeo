using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace wsclient_pro
{
    public class PushEventArgs : EventArgs
    {
        public int type { get; set; }
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string value { get; set; }

        public PushEventArgs()
        {
        }

        public PushEventArgs(int type, string cmd, string device_id, string value)
        {
            this.type = type;
            this.cmd = cmd;
            this.device_id = device_id;
            this.value = value;
        }
    }
}