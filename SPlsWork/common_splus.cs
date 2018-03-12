using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;
using common_lib;

namespace UserModule_COMMON_SPLUS
{
    public class UserModuleClass_COMMON_SPLUS : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        Crestron.Logos.SplusObjects.DigitalOutput OUT1;
        Crestron.Logos.SplusObjects.DigitalOutput OUT2;
        Crestron.Logos.SplusObjects.DigitalOutput OUT3;
        Crestron.Logos.SplusObjects.DigitalOutput OUT4;
        Crestron.Logos.SplusObjects.DigitalOutput OUT5;
        Crestron.Logos.SplusObjects.DigitalOutput OUT6;
        Crestron.Logos.SplusObjects.DigitalOutput OUT7;
        Crestron.Logos.SplusObjects.DigitalOutput OUT8;
        Crestron.Logos.SplusObjects.DigitalOutput OUT9;
        Crestron.Logos.SplusObjects.DigitalOutput OUT10;
        Crestron.Logos.SplusObjects.DigitalOutput OUT11;
        Crestron.Logos.SplusObjects.DigitalOutput OUT12;
        Crestron.Logos.SplusObjects.DigitalOutput OUT13;
        Crestron.Logos.SplusObjects.DigitalOutput OUT14;
        Crestron.Logos.SplusObjects.DigitalOutput OUT15;
        Crestron.Logos.SplusObjects.DigitalOutput OUT16;
        Crestron.Logos.SplusObjects.DigitalInput D_IN1_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN1_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN2_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN2_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN3_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN3_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN4_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN4_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN5_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN5_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN6_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN6_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN7_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN7_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN8_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN8_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN9_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN9_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN10_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN10_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN11_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN11_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN12_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN12_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN13_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN13_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN14_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN14_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN15_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN15_OFF;
        Crestron.Logos.SplusObjects.DigitalInput D_IN16_ON;
        Crestron.Logos.SplusObjects.DigitalInput D_IN16_OFF;
        ushort TIME_PAUSE = 0;
        Crestron.Logos.SplusObjects.DigitalOutput SEND_COMMAND;
        uint DECIMAL_SERIAL = 0;
        Crestron.Logos.SplusObjects.StringInput HEX_SERIAL_INPUT__DOLLAR__;
        __CEvent__ PING_PAUSE;
        __CEvent__ DELAY_ONOFF;
        common_lib.WSClient WS;
        public void _ONPUSHRECEIVED ( object __sender__ /*common_lib.PushEventArgs E */) 
            { 
            PushEventArgs  E  = (PushEventArgs )__sender__;
            uint DEVICE_TYPE = 0;
            
            CrestronString CMD;
            CMD  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString DEVICE_ID;
            DEVICE_ID  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            CrestronString VALUE;
            VALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            try
            {
                SplusExecutionContext __context__ = SplusSimplSharpDelegateThreadStartCode();
                
                __context__.SourceCodeLine = 71;
                try 
                    { 
                    __context__.SourceCodeLine = 73;
                    DEVICE_TYPE = (uint) ( E.device_type ) ; 
                    __context__.SourceCodeLine = 74;
                    CMD  .UpdateValue ( E . cmd  ) ; 
                    __context__.SourceCodeLine = 75;
                    DEVICE_ID  .UpdateValue ( E . device_id  ) ; 
                    __context__.SourceCodeLine = 76;
                    VALUE  .UpdateValue ( E . value  ) ; 
                    __context__.SourceCodeLine = 77;
                    Print( "device type: {0:d}\r\n", (int)DEVICE_TYPE) ; 
                    __context__.SourceCodeLine = 78;
                    Print( "cmd:			{0}\r\n", CMD ) ; 
                    __context__.SourceCodeLine = 79;
                    Print( "device_id: 	{0}\r\n", DEVICE_ID ) ; 
                    __context__.SourceCodeLine = 80;
                    Print( "value:		{0}\r\n", VALUE ) ; 
                    __context__.SourceCodeLine = 81;
                    TIME_PAUSE = (ushort) ( 50 ) ; 
                    __context__.SourceCodeLine = 82;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_TYPE == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 85;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "1"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 86;
                            OUT1  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 87;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 88;
                            OUT1  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 90;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "2"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 91;
                            OUT2  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 92;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 93;
                            OUT2  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 95;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "3"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 96;
                            OUT3  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 97;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 98;
                            OUT3  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 100;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "4"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 101;
                            OUT4  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 102;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 103;
                            OUT4  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 105;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "5"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 106;
                            OUT5  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 107;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 108;
                            OUT5  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 110;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "6"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 111;
                            OUT6  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 112;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 113;
                            OUT6  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 115;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "7"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 116;
                            OUT7  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 117;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 118;
                            OUT7  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 120;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "8"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 121;
                            OUT8  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 122;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 123;
                            OUT8  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 125;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "9"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 126;
                            OUT9  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 127;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 128;
                            OUT9  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 130;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "10"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 131;
                            OUT10  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 132;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 133;
                            OUT10  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 135;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "11"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 136;
                            OUT11  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 137;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 138;
                            OUT11  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 140;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "12"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 141;
                            OUT12  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 142;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 143;
                            OUT12  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 145;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "13"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 146;
                            OUT13  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 147;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 148;
                            OUT13  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 150;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "14"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 151;
                            OUT14  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 152;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 153;
                            OUT14  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 155;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "15"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 156;
                            OUT15  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 157;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 158;
                            OUT15  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        __context__.SourceCodeLine = 160;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_ID == "16"))  ) ) 
                            { 
                            __context__.SourceCodeLine = 161;
                            OUT16  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 162;
                            DELAY_ONOFF . Wait ( (short)( TIME_PAUSE )) ; 
                            __context__.SourceCodeLine = 163;
                            OUT16  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        } 
                    
                    __context__.SourceCodeLine = 167;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (DEVICE_TYPE == 2))  ) ) 
                        { 
                        } 
                    
                    } 
                
                catch (Exception __splus_exception__)
                    { 
                    SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                    
                    __context__.SourceCodeLine = 171;
                    Print( "_onPushReceived exception\r\n") ; 
                    
                    }
                    
                    
                    
                }
                finally { ObjectFinallyHandler(); }
                }
                
            object D_IN1_ON_OnRelease_0 ( Object __EventInfo__ )
            
                { 
                Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
                try
                {
                    SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                    
                    __context__.SourceCodeLine = 176;
                    Print( "ON DEN 1: {0:d}\r\n", (short)D_IN1_ON  .Value) ; 
                    __context__.SourceCodeLine = 177;
                    WS . LightOnoff ( "1", (int)( 1 ), (int)( 100 )) ; 
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        object D_IN1_OFF_OnRelease_1 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 180;
                Print( "OFF DEN 1: {0:d}\r\n", (short)D_IN1_OFF  .Value) ; 
                __context__.SourceCodeLine = 181;
                WS . LightOnoff ( "1", (int)( 0 ), (int)( 0 )) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object D_IN2_ON_OnRelease_2 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 184;
            Print( "ON DEN 2: {0:d}\r\n", (short)D_IN2_ON  .Value) ; 
            __context__.SourceCodeLine = 185;
            WS . LightOnoff ( "2", (int)( 1 ), (int)( 100 )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object D_IN2_OFF_OnRelease_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 188;
        Print( "OFF DEN 1: {0:d}\r\n", (short)D_IN2_OFF  .Value) ; 
        __context__.SourceCodeLine = 189;
        WS . LightOnoff ( "2", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN3_ON_OnRelease_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 192;
        Print( "ON DEN 3: {0:d}\r\n", (short)D_IN3_ON  .Value) ; 
        __context__.SourceCodeLine = 193;
        WS . LightOnoff ( "3", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN3_OFF_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 196;
        Print( "OFF DEN 3: {0:d}\r\n", (short)D_IN3_OFF  .Value) ; 
        __context__.SourceCodeLine = 197;
        WS . LightOnoff ( "3", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN4_ON_OnRelease_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 200;
        Print( "ON DEN 4: {0:d}\r\n", (short)D_IN4_ON  .Value) ; 
        __context__.SourceCodeLine = 201;
        WS . LightOnoff ( "4", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN4_OFF_OnRelease_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 204;
        Print( "OFF DEN 4: {0:d}\r\n", (short)D_IN4_OFF  .Value) ; 
        __context__.SourceCodeLine = 205;
        WS . LightOnoff ( "4", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN5_ON_OnRelease_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 208;
        Print( "ON DEN 5: {0:d}\r\n", (short)D_IN5_ON  .Value) ; 
        __context__.SourceCodeLine = 209;
        WS . LightOnoff ( "5", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN5_OFF_OnRelease_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 212;
        Print( "OFF DEN 5: {0:d}\r\n", (short)D_IN5_OFF  .Value) ; 
        __context__.SourceCodeLine = 213;
        WS . LightOnoff ( "5", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN6_ON_OnRelease_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 216;
        Print( "ON DEN 6: {0:d}\r\n", (short)D_IN6_ON  .Value) ; 
        __context__.SourceCodeLine = 217;
        WS . LightOnoff ( "6", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN6_OFF_OnRelease_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 220;
        Print( "OFF DEN 6: {0:d}\r\n", (short)D_IN6_OFF  .Value) ; 
        __context__.SourceCodeLine = 221;
        WS . LightOnoff ( "6", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN7_ON_OnRelease_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 224;
        Print( "ON DEN 7: {0:d}\r\n", (short)D_IN7_ON  .Value) ; 
        __context__.SourceCodeLine = 225;
        WS . LightOnoff ( "7", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN7_OFF_OnRelease_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 228;
        Print( "OFF DEN 7: {0:d}\r\n", (short)D_IN7_OFF  .Value) ; 
        __context__.SourceCodeLine = 229;
        WS . LightOnoff ( "7", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN8_ON_OnRelease_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 232;
        Print( "ON DEN 8: {0:d}\r\n", (short)D_IN8_ON  .Value) ; 
        __context__.SourceCodeLine = 233;
        WS . LightOnoff ( "8", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN8_OFF_OnRelease_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 236;
        Print( "OFF DEN 8: {0:d}\r\n", (short)D_IN8_OFF  .Value) ; 
        __context__.SourceCodeLine = 237;
        WS . LightOnoff ( "8", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN9_ON_OnRelease_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 240;
        Print( "ON DEN 9: {0:d}\r\n", (short)D_IN9_ON  .Value) ; 
        __context__.SourceCodeLine = 241;
        WS . LightOnoff ( "9", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN9_OFF_OnRelease_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 244;
        Print( "OFF DEN 9: {0:d}\r\n", (short)D_IN9_OFF  .Value) ; 
        __context__.SourceCodeLine = 245;
        WS . LightOnoff ( "9", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN10_ON_OnRelease_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 248;
        Print( "ON DEN 10: {0:d}\r\n", (short)D_IN10_ON  .Value) ; 
        __context__.SourceCodeLine = 249;
        WS . LightOnoff ( "10", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN10_OFF_OnRelease_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 252;
        Print( "OFF DEN 10: {0:d}\r\n", (short)D_IN10_OFF  .Value) ; 
        __context__.SourceCodeLine = 253;
        WS . LightOnoff ( "10", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN11_ON_OnRelease_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 256;
        Print( "ON DEN 11: {0:d}\r\n", (short)D_IN11_ON  .Value) ; 
        __context__.SourceCodeLine = 257;
        WS . LightOnoff ( "11", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN11_OFF_OnRelease_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 260;
        Print( "OFF DEN 11: {0:d}\r\n", (short)D_IN11_OFF  .Value) ; 
        __context__.SourceCodeLine = 261;
        WS . LightOnoff ( "11", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN12_ON_OnRelease_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 264;
        Print( "ON DEN 12: {0:d}\r\n", (short)D_IN12_ON  .Value) ; 
        __context__.SourceCodeLine = 265;
        WS . LightOnoff ( "12", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN12_OFF_OnRelease_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 268;
        Print( "OFF DEN 12: {0:d}\r\n", (short)D_IN12_OFF  .Value) ; 
        __context__.SourceCodeLine = 269;
        WS . LightOnoff ( "12", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN13_ON_OnRelease_24 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 272;
        Print( "ON DEN 13: {0:d}\r\n", (short)D_IN13_ON  .Value) ; 
        __context__.SourceCodeLine = 273;
        WS . LightOnoff ( "13", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN13_OFF_OnRelease_25 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 276;
        Print( "OFF DEN 13: {0:d}\r\n", (short)D_IN13_OFF  .Value) ; 
        __context__.SourceCodeLine = 277;
        WS . LightOnoff ( "13", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN14_ON_OnRelease_26 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 280;
        Print( "ON DEN 14: {0:d}\r\n", (short)D_IN14_ON  .Value) ; 
        __context__.SourceCodeLine = 281;
        WS . LightOnoff ( "14", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN14_OFF_OnRelease_27 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 284;
        Print( "OFF DEN 14: {0:d}\r\n", (short)D_IN14_OFF  .Value) ; 
        __context__.SourceCodeLine = 285;
        WS . LightOnoff ( "14", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN15_ON_OnRelease_28 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 288;
        Print( "ON DEN 15: {0:d}\r\n", (short)D_IN15_ON  .Value) ; 
        __context__.SourceCodeLine = 289;
        WS . LightOnoff ( "15", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN15_OFF_OnRelease_29 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 292;
        Print( "OFF DEN 15: {0:d}\r\n", (short)D_IN15_OFF  .Value) ; 
        __context__.SourceCodeLine = 293;
        WS . LightOnoff ( "15", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN16_ON_OnRelease_30 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 296;
        Print( "ON DEN 16: {0:d}\r\n", (short)D_IN16_ON  .Value) ; 
        __context__.SourceCodeLine = 297;
        WS . LightOnoff ( "16", (int)( 1 ), (int)( 100 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object D_IN16_OFF_OnRelease_31 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 300;
        Print( "OFF DEN 16: {0:d}\r\n", (short)D_IN16_OFF  .Value) ; 
        __context__.SourceCodeLine = 301;
        WS . LightOnoff ( "16", (int)( 0 ), (int)( 0 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEX_SERIAL_INPUT__DOLLAR___OnChange_32 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 305;
        try 
            { 
            __context__.SourceCodeLine = 306;
            Trace( "Serial Number Hex: {0}", HEX_SERIAL_INPUT__DOLLAR__ ) ; 
            __context__.SourceCodeLine = 307;
            DECIMAL_SERIAL = (uint) ( Functions.HextoL( HEX_SERIAL_INPUT__DOLLAR__ ) ) ; 
            __context__.SourceCodeLine = 308;
            Trace( "Serial Number Integer: {0:d}", (short)DECIMAL_SERIAL) ; 
            __context__.SourceCodeLine = 309;
            WS . g_cunit_no  =  ( Functions.LtoA (  (int) ( DECIMAL_SERIAL ) )  )  .ToString() ; 
            __context__.SourceCodeLine = 310;
            WS . initialize_ws ( ) ; 
            __context__.SourceCodeLine = 311;
            WS . connect ( ) ; 
            __context__.SourceCodeLine = 312;
            WS . AsyncSendAndReceive ( ) ; 
            } 
        
        catch (Exception __splus_exception__)
            { 
            SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
            
            __context__.SourceCodeLine = 314;
            Print( "Exception when get crestron serial number") ; 
            
            }
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 321;
        SEND_COMMAND  .Value = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 322;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 323;
        // RegisterEvent( PushEvents , ONPUSHRECEIVED , _ONPUSHRECEIVED ) 
        try { g_criticalSection.Enter(); PushEvents .onPushReceived  += _ONPUSHRECEIVED; } finally { g_criticalSection.Leave(); }
        ; 
        __context__.SourceCodeLine = 324;
        PING_PAUSE . Wait ( (short)( 10000 )) ; 
        __context__.SourceCodeLine = 325;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 326;
            PING_PAUSE . Wait ( (short)( 5000 )) ; 
            __context__.SourceCodeLine = 327;
            WS . ping ( ) ; 
            __context__.SourceCodeLine = 328;
            Print( "ping count: {0:d}\r\n", (short)WS.ping_count) ; 
            __context__.SourceCodeLine = 329;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( WS.ping_count >= 2 ))  ) ) 
                { 
                __context__.SourceCodeLine = 331;
                Print( "reconnect...\r\n") ; 
                __context__.SourceCodeLine = 332;
                WS . initialize_ws ( ) ; 
                __context__.SourceCodeLine = 333;
                WS . try_to_connect ( ) ; 
                __context__.SourceCodeLine = 334;
                WS . AsyncSendAndReceive ( ) ; 
                } 
            
            __context__.SourceCodeLine = 325;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    
    D_IN1_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN1_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN1_ON__DigitalInput__, D_IN1_ON );
    
    D_IN1_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN1_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN1_OFF__DigitalInput__, D_IN1_OFF );
    
    D_IN2_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN2_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN2_ON__DigitalInput__, D_IN2_ON );
    
    D_IN2_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN2_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN2_OFF__DigitalInput__, D_IN2_OFF );
    
    D_IN3_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN3_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN3_ON__DigitalInput__, D_IN3_ON );
    
    D_IN3_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN3_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN3_OFF__DigitalInput__, D_IN3_OFF );
    
    D_IN4_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN4_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN4_ON__DigitalInput__, D_IN4_ON );
    
    D_IN4_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN4_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN4_OFF__DigitalInput__, D_IN4_OFF );
    
    D_IN5_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN5_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN5_ON__DigitalInput__, D_IN5_ON );
    
    D_IN5_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN5_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN5_OFF__DigitalInput__, D_IN5_OFF );
    
    D_IN6_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN6_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN6_ON__DigitalInput__, D_IN6_ON );
    
    D_IN6_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN6_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN6_OFF__DigitalInput__, D_IN6_OFF );
    
    D_IN7_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN7_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN7_ON__DigitalInput__, D_IN7_ON );
    
    D_IN7_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN7_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN7_OFF__DigitalInput__, D_IN7_OFF );
    
    D_IN8_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN8_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN8_ON__DigitalInput__, D_IN8_ON );
    
    D_IN8_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN8_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN8_OFF__DigitalInput__, D_IN8_OFF );
    
    D_IN9_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN9_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN9_ON__DigitalInput__, D_IN9_ON );
    
    D_IN9_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN9_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN9_OFF__DigitalInput__, D_IN9_OFF );
    
    D_IN10_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN10_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN10_ON__DigitalInput__, D_IN10_ON );
    
    D_IN10_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN10_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN10_OFF__DigitalInput__, D_IN10_OFF );
    
    D_IN11_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN11_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN11_ON__DigitalInput__, D_IN11_ON );
    
    D_IN11_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN11_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN11_OFF__DigitalInput__, D_IN11_OFF );
    
    D_IN12_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN12_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN12_ON__DigitalInput__, D_IN12_ON );
    
    D_IN12_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN12_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN12_OFF__DigitalInput__, D_IN12_OFF );
    
    D_IN13_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN13_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN13_ON__DigitalInput__, D_IN13_ON );
    
    D_IN13_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN13_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN13_OFF__DigitalInput__, D_IN13_OFF );
    
    D_IN14_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN14_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN14_ON__DigitalInput__, D_IN14_ON );
    
    D_IN14_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN14_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN14_OFF__DigitalInput__, D_IN14_OFF );
    
    D_IN15_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN15_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN15_ON__DigitalInput__, D_IN15_ON );
    
    D_IN15_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN15_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN15_OFF__DigitalInput__, D_IN15_OFF );
    
    D_IN16_ON = new Crestron.Logos.SplusObjects.DigitalInput( D_IN16_ON__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN16_ON__DigitalInput__, D_IN16_ON );
    
    D_IN16_OFF = new Crestron.Logos.SplusObjects.DigitalInput( D_IN16_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( D_IN16_OFF__DigitalInput__, D_IN16_OFF );
    
    OUT1 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT1__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT1__DigitalOutput__, OUT1 );
    
    OUT2 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT2__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT2__DigitalOutput__, OUT2 );
    
    OUT3 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT3__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT3__DigitalOutput__, OUT3 );
    
    OUT4 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT4__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT4__DigitalOutput__, OUT4 );
    
    OUT5 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT5__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT5__DigitalOutput__, OUT5 );
    
    OUT6 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT6__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT6__DigitalOutput__, OUT6 );
    
    OUT7 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT7__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT7__DigitalOutput__, OUT7 );
    
    OUT8 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT8__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT8__DigitalOutput__, OUT8 );
    
    OUT9 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT9__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT9__DigitalOutput__, OUT9 );
    
    OUT10 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT10__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT10__DigitalOutput__, OUT10 );
    
    OUT11 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT11__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT11__DigitalOutput__, OUT11 );
    
    OUT12 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT12__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT12__DigitalOutput__, OUT12 );
    
    OUT13 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT13__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT13__DigitalOutput__, OUT13 );
    
    OUT14 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT14__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT14__DigitalOutput__, OUT14 );
    
    OUT15 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT15__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT15__DigitalOutput__, OUT15 );
    
    OUT16 = new Crestron.Logos.SplusObjects.DigitalOutput( OUT16__DigitalOutput__, this );
    m_DigitalOutputList.Add( OUT16__DigitalOutput__, OUT16 );
    
    SEND_COMMAND = new Crestron.Logos.SplusObjects.DigitalOutput( SEND_COMMAND__DigitalOutput__, this );
    m_DigitalOutputList.Add( SEND_COMMAND__DigitalOutput__, SEND_COMMAND );
    
    HEX_SERIAL_INPUT__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( HEX_SERIAL_INPUT__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( HEX_SERIAL_INPUT__DOLLAR____AnalogSerialInput__, HEX_SERIAL_INPUT__DOLLAR__ );
    
    
    D_IN1_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN1_ON_OnRelease_0, false ) );
    D_IN1_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN1_OFF_OnRelease_1, false ) );
    D_IN2_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN2_ON_OnRelease_2, false ) );
    D_IN2_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN2_OFF_OnRelease_3, false ) );
    D_IN3_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN3_ON_OnRelease_4, false ) );
    D_IN3_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN3_OFF_OnRelease_5, false ) );
    D_IN4_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN4_ON_OnRelease_6, false ) );
    D_IN4_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN4_OFF_OnRelease_7, false ) );
    D_IN5_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN5_ON_OnRelease_8, false ) );
    D_IN5_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN5_OFF_OnRelease_9, false ) );
    D_IN6_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN6_ON_OnRelease_10, false ) );
    D_IN6_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN6_OFF_OnRelease_11, false ) );
    D_IN7_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN7_ON_OnRelease_12, false ) );
    D_IN7_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN7_OFF_OnRelease_13, false ) );
    D_IN8_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN8_ON_OnRelease_14, false ) );
    D_IN8_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN8_OFF_OnRelease_15, false ) );
    D_IN9_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN9_ON_OnRelease_16, false ) );
    D_IN9_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN9_OFF_OnRelease_17, false ) );
    D_IN10_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN10_ON_OnRelease_18, false ) );
    D_IN10_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN10_OFF_OnRelease_19, false ) );
    D_IN11_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN11_ON_OnRelease_20, false ) );
    D_IN11_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN11_OFF_OnRelease_21, false ) );
    D_IN12_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN12_ON_OnRelease_22, false ) );
    D_IN12_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN12_OFF_OnRelease_23, false ) );
    D_IN13_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN13_ON_OnRelease_24, false ) );
    D_IN13_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN13_OFF_OnRelease_25, false ) );
    D_IN14_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN14_ON_OnRelease_26, false ) );
    D_IN14_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN14_OFF_OnRelease_27, false ) );
    D_IN15_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN15_ON_OnRelease_28, false ) );
    D_IN15_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN15_OFF_OnRelease_29, false ) );
    D_IN16_ON.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN16_ON_OnRelease_30, false ) );
    D_IN16_OFF.OnDigitalRelease.Add( new InputChangeHandlerWrapper( D_IN16_OFF_OnRelease_31, false ) );
    HEX_SERIAL_INPUT__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( HEX_SERIAL_INPUT__DOLLAR___OnChange_32, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    PING_PAUSE  = new __CEvent__();
    DELAY_ONOFF  = new __CEvent__();
    WS  = new common_lib.WSClient();
    
    
}

public UserModuleClass_COMMON_SPLUS ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint OUT1__DigitalOutput__ = 0;
const uint OUT2__DigitalOutput__ = 1;
const uint OUT3__DigitalOutput__ = 2;
const uint OUT4__DigitalOutput__ = 3;
const uint OUT5__DigitalOutput__ = 4;
const uint OUT6__DigitalOutput__ = 5;
const uint OUT7__DigitalOutput__ = 6;
const uint OUT8__DigitalOutput__ = 7;
const uint OUT9__DigitalOutput__ = 8;
const uint OUT10__DigitalOutput__ = 9;
const uint OUT11__DigitalOutput__ = 10;
const uint OUT12__DigitalOutput__ = 11;
const uint OUT13__DigitalOutput__ = 12;
const uint OUT14__DigitalOutput__ = 13;
const uint OUT15__DigitalOutput__ = 14;
const uint OUT16__DigitalOutput__ = 15;
const uint D_IN1_ON__DigitalInput__ = 0;
const uint D_IN1_OFF__DigitalInput__ = 1;
const uint D_IN2_ON__DigitalInput__ = 2;
const uint D_IN2_OFF__DigitalInput__ = 3;
const uint D_IN3_ON__DigitalInput__ = 4;
const uint D_IN3_OFF__DigitalInput__ = 5;
const uint D_IN4_ON__DigitalInput__ = 6;
const uint D_IN4_OFF__DigitalInput__ = 7;
const uint D_IN5_ON__DigitalInput__ = 8;
const uint D_IN5_OFF__DigitalInput__ = 9;
const uint D_IN6_ON__DigitalInput__ = 10;
const uint D_IN6_OFF__DigitalInput__ = 11;
const uint D_IN7_ON__DigitalInput__ = 12;
const uint D_IN7_OFF__DigitalInput__ = 13;
const uint D_IN8_ON__DigitalInput__ = 14;
const uint D_IN8_OFF__DigitalInput__ = 15;
const uint D_IN9_ON__DigitalInput__ = 16;
const uint D_IN9_OFF__DigitalInput__ = 17;
const uint D_IN10_ON__DigitalInput__ = 18;
const uint D_IN10_OFF__DigitalInput__ = 19;
const uint D_IN11_ON__DigitalInput__ = 20;
const uint D_IN11_OFF__DigitalInput__ = 21;
const uint D_IN12_ON__DigitalInput__ = 22;
const uint D_IN12_OFF__DigitalInput__ = 23;
const uint D_IN13_ON__DigitalInput__ = 24;
const uint D_IN13_OFF__DigitalInput__ = 25;
const uint D_IN14_ON__DigitalInput__ = 26;
const uint D_IN14_OFF__DigitalInput__ = 27;
const uint D_IN15_ON__DigitalInput__ = 28;
const uint D_IN15_OFF__DigitalInput__ = 29;
const uint D_IN16_ON__DigitalInput__ = 30;
const uint D_IN16_OFF__DigitalInput__ = 31;
const uint SEND_COMMAND__DigitalOutput__ = 16;
const uint HEX_SERIAL_INPUT__DOLLAR____AnalogSerialInput__ = 0;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
