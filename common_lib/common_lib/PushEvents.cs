using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crestron.SimplSharp;

namespace common_lib
{
    public class PushEvents
    {
        private static CCriticalSection myCriticalSection = new CCriticalSection();
        private static CMutex myMutex = new CMutex();
        public static event PushEventHandler onPushReceived;

        public void PushMessage(int device_type, string cmd, string device_id, string value)
        {
            PushEvents.onPushReceived(new PushEventArgs(device_type, cmd, device_id, value));
        }
    }
}