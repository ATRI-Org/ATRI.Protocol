using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
#if DEBUG
public static class Program
{
    public static UdpClient udpClient;
    public static void Main()
    {
        udpClient = new UdpClient();
        udpClient.Connect(IPAddress.Parse("192.168.1.105"), 5566);
    }
    public static void SendMsg(byte[] data)
    {
        udpClient.SendAsync(data, data.Length);
    }
}
#endif



namespace System
{
    public class Logger
    {
      
       private class Out
        {
            private static bool islog = true;
            public enum LoggerType
            {
                INFO,
                ERROR,
                WARNING,
                DEBUG,
            }
            private static Stream s_Stream = Console.OpenStandardOutput();
            private static void Write(byte[] bytes)
            {
#if DEBUG
                Program.SendMsg(bytes);
#endif

                if (islog)
                {
                    s_Stream.Write(bytes, 0, bytes.Length);
                    s_Stream.Flush();
                }
                
            }
            public static void WriteLine_<T>(T t,LoggerType type)  
            {
                
                    StackTrace trace = new StackTrace();
                    string header = string.Empty;
                    string data;
                    string typea;
                    if (t == null)
                    {
                        data = "null";
                        typea = "null";
                    }
                    else
                    {
                        data = t.ToString();
                        typea = t.GetType().ToString();
                    }

                    switch (type)
                    {
                        case LoggerType.INFO:
                            header = "\u001b[96;1mINFO\u001b[0m";
                            break;
                        case LoggerType.ERROR:
                            header = "\u001b[31;1mERROR\u001b[0m";
                            break;
                        case LoggerType.WARNING:
                            header = "\u001b[96;1mWARN\u001b[0m";
                            break;
                    }
                    Write(Encoding.Unicode.GetBytes($"{System.DateTime.Now.ToString("G")}\u001b[0m {header}: " + data + "\0" + "\n"));
                
               
            }
            public static void Write_<T>(T t,LoggerType type)
            {
                Task.Run(() =>
                {
                    string data;
                    string typea;
                    if (t == null)
                    {
                        data = "null";
                        typea = "null";
                    }
                    else
                    {
                        data = t.ToString();
                        typea = t.GetType().ToString();
                    }
                    StackTrace trace = new StackTrace();
                    string header = string.Empty;
                    switch (type)
                    {
                        case LoggerType.INFO:
                            header = "\u001b[96;1mINFO\u001b[0m";
                            break;
                        case LoggerType.ERROR:
                            header = "\u001b[31;1mERROR\u001b[0m";
                            break;
                        case LoggerType.WARNING:
                            header = "\u001b[34;1mWARN\u001b[0m";
                            break;
                    }
                    Write(Encoding.Unicode.GetBytes($"{System.DateTime.Now.ToString("G")}\u001b[0m {header}: " + data + "\0"));
                });
                
            }
        }


        public static void INFO<T>(T value)
        {
             Out.WriteLine_(value,Out.LoggerType.INFO);
        }
        public static void INFO()
        {
            Out.WriteLine_("\n",Out.LoggerType.INFO);
        }
        public static void INFO_Write<T> (T value)
        {
             Out.Write_(value, Out.LoggerType.INFO);
        }
        public static void ERROR<T> (T value)
        {
            Out.WriteLine_ (value, Out.LoggerType.ERROR);
        }
        public static void ERROR()
        {
            Out.WriteLine_("\n", Out.LoggerType.ERROR);
        }
        public static void ERROR_Write<T> (T value)
        {
            Out.Write_(value, Out.LoggerType.ERROR);
        }
        public static void WARN<T> (T value)
        {
            Out.WriteLine_ (value, Out.LoggerType.WARNING);
        }
        public static void WARN_Write<T> (T value)
        {
            Out.Write_ (value, Out.LoggerType.WARNING);
        }

    }
}
