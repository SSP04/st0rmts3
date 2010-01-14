using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TS3.Executable
{
    public class Program
    {
        public static int Main(string[] args)
        {

            IRC irc = new IRC(Config.Instance.Nick, Config.Instance.User, Config.Instance.Realname);

            irc.Connect(Config.Instance.IrcServer, Config.Instance.IrcPass, Config.Instance.IrcPort);

            

            return 0;
        }
    }
}
