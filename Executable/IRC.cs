using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Net.Irc;

namespace TS3.Executable
{
    public class IRC
    {
        IrcClient client = null;

        public IrcClient Client
        {
            get
            {
                return client;
            }
        }

        public IRC(string nick, string user, string real)
        {
            client = new IrcClient();
            client.Nick = nick;
            client.Ident = user;
            client.Realname = real;
        }

        public bool Connect(string server, string pass, ushort port)
        {
            if (client == null)
                return false;
            if (client.Client.Connected)
            {
                client.Disconnect("Connect method called without a graceful disconnect...");
            }

            client.Host = server;
            client.Password = pass;
            client.Port = port > 0 ? port : 6667;
            client.Start();
            return false;

        }
    }
}
