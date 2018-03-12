using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace common_lib
{
    public class PushEventArgs : EventArgs
    {
        public int device_type { get; set; }
        public string cmd { get; set; }
        public string device_id { get; set; }
        public string value { get; set; }

        public PushEventArgs()
        {
        }

        public PushEventArgs(int device_type, string cmd, string device_id, string value)
        {
            this.device_type    = device_type;
            this.cmd            = cmd;
            this.device_id      = device_id;
            this.value          = value;
        }
    }
}