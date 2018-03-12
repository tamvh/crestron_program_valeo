namespace common_lib;
        // class declarations
         class CommonUtil;
         class DEVICE_TYPE;
         class MSG_TYPE;
         class WSClient;
         class HTTPClient;
         class HTTPSClient;
         class PushEvents;
         class PushEventArgs;
     class CommonUtil 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION FormatPing ( STRING cunit_no );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING WSS_URL[];
        static STRING WS_URL[];
        static STRING HTTP_SERVER_URL[];
        static STRING HTTPS_SERVER_URL[];

        // class properties
    };

    static class DEVICE_TYPE // enum
    {
        static SIGNED_LONG_INTEGER WEBSOCKET;
        static SIGNED_LONG_INTEGER LIGHT_ONOFF;
        static SIGNED_LONG_INTEGER LIGHT_DIM;
    };

    static class MSG_TYPE // enum
    {
        static SIGNED_LONG_INTEGER MSG_REQUEST;
        static SIGNED_LONG_INTEGER MSG_PING;
        static SIGNED_LONG_INTEGER MSG_RESPONSE;
        static SIGNED_LONG_INTEGER MSG_PONG;
        static SIGNED_LONG_INTEGER MSG_LIGHT_SWITCH_ONOFF;
        static SIGNED_LONG_INTEGER MSG_LIGHT_CHANGE_BRIGHTNESS;
        static SIGNED_LONG_INTEGER MSG_LIGHT_SWITCH_ONOFF_GROUP;
    };

     class WSClient 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_INTEGER_FUNCTION PushReceived ( SIGNED_LONG_INTEGER type , STRING cmd , STRING device_id , STRING value );
        FUNCTION initialize_ws ();
        SIGNED_LONG_INTEGER_FUNCTION connect ();
        SIGNED_LONG_INTEGER_FUNCTION try_to_connect ();
        FUNCTION ping ();
        FUNCTION switch_on_off ( STRING dt );
        FUNCTION AsyncSendAndReceive ();
        FUNCTION LightOnoff ( STRING light_code , SIGNED_LONG_INTEGER on_off , SIGNED_LONG_INTEGER brightness );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING g_cunit_no[];
        SIGNED_LONG_INTEGER ping_count;

        // class properties
    };

     class HTTPClient 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class HTTPSClient 
    {
        // class delegates

        // class events

        // class functions
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
        FUNCTION PushMessage ( SIGNED_LONG_INTEGER device_type , STRING cmd , STRING device_id , STRING value );
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
        SIGNED_LONG_INTEGER device_type;
        STRING cmd[];
        STRING device_id[];
        STRING value[];
    };

