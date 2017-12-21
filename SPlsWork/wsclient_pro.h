namespace wsclient_pro.model;
        // class declarations
         class LightModel;
     class LightModel 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION update_data_light_switch_on_off ( STRING dt );
        STRING_FUNCTION update_data_light_change_brightness ( STRING dt );
        STRING_FUNCTION update_data_light_switch_on_off_group ( STRING dt );
        STRING_FUNCTION update_data_light_change_brightness_group ( STRING dt );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace wsclient_pro.common;
        // class declarations
         class GatewayInfor;
         class XmlFile;
     class GatewayInfor 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION getVersion ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class XmlFile 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION write ( STRING data );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace wsclient_pro;
        // class declarations
         class HttpServerService;
         class PushEvents;
         class HttpUtility;
         class WSClientService;
         class Database;
         class HttpClientService;
         class WebSocketClientService;
         class PushEventArgs;
         class HttpsClientService;
     class HttpServerService 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION startListening ( SIGNED_LONG_INTEGER portNumber );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PushEvents 
    {
        // class delegates

        // class events
        static EventHandler onPushReceived ( PushEventArgs e );

        // class functions
        FUNCTION PushMessage ( SIGNED_LONG_INTEGER type , STRING cmd , STRING device_id , STRING value );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class HttpUtility 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION FormatResponse ( SIGNED_LONG_INTEGER err , STRING msg );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class WSClientService 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION getLocalIP ();
        FUNCTION init ();
        SIGNED_INTEGER_FUNCTION PushReceived ( SIGNED_LONG_INTEGER type , STRING cmd , STRING device_id , STRING value );
        SIGNED_LONG_INTEGER_FUNCTION connect ();
        FUNCTION reConnect ();
        SIGNED_LONG_INTEGER_FUNCTION try_to_connect ();
        SIGNED_LONG_INTEGER_FUNCTION getConnected ();
        FUNCTION Disconnect ();
        FUNCTION sendPingMsg ();
        FUNCTION switch_on_off ( STRING dt );
        FUNCTION switch_on_off_group ( STRING dt );
        FUNCTION change_brightness ( STRING dt );
        FUNCTION change_brightness_group ( STRING dt );
        FUNCTION AsyncSendAndReceive ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING Access_Code[];
        SIGNED_LONG_INTEGER countPingConnectServer;

        // class properties
    };

     class Database 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION connect ( STRING userid , STRING password , STRING server , STRING database );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING databasename[];

        // class properties
    };

     class HttpClientService 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION doGet ( STRING url );
        STRING_FUNCTION doPost ( STRING url , STRING content );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class WebSocketClientService 
    {
        // class delegates

        // class events

        // class functions
        static SIGNED_INTEGER_FUNCTION PushReceived ( SIGNED_LONG_INTEGER type , STRING cmd , STRING device_id , STRING value );
        static FUNCTION init_ws ();
        static SIGNED_LONG_INTEGER_FUNCTION connect ();
        static SIGNED_LONG_INTEGER_FUNCTION try_to_connect ();
        static SIGNED_LONG_INTEGER_FUNCTION getConnected ();
        static FUNCTION Disconnect ();
        static FUNCTION sendPingMsg ();
        static FUNCTION switch_on_off ( STRING dt );
        static FUNCTION switch_on_off_group ( STRING dt );
        static FUNCTION change_brightness ( STRING dt );
        static FUNCTION change_brightness_group ( STRING dt );
        static FUNCTION AsyncSendAndReceive ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class PushEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER type;
        STRING cmd[];
        STRING device_id[];
        STRING value[];
    };

     class HttpsClientService 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION doGet ( STRING url );
        STRING_FUNCTION doPost ( STRING url , STRING content );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

namespace wsclient_pro.controller;
        // class declarations
         class LightController;

