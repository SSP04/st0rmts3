using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TS3.Executable.InterOp;

namespace TS3.Executable
{
    public class Program
    {
        public static int Main(string[] args)
        {

            TS3Client clnt = new TS3Client();
            clnt.OnConnectStatusChanged += (a, b, c) => Console.WriteLine("Status now: " + b + " Error: " + c);
            if (clnt.Connect())
                Logger.Log("Connected to Teamspeak 3 server");
            else
            {
                Logger.Error("Could not connect to server initially.");
                Environment.Exit(1);
            }

            IRC irc = new IRC(Config.Instance.Nick, Config.Instance.User, Config.Instance.Realname);

            irc.Connect(Config.Instance.IrcServer, Config.Instance.IrcPass, Config.Instance.IrcPort);


            Console.ReadKey(true);

            return 0;
        }
    }
}
