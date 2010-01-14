using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace TS3.Executable
{
    public class Config
    {
        public static string FILENAME = "config.xml";
        public static Config Instance = new Config();

        private XmlDocument Xml = new XmlDocument();

        public static XmlDocument XML
        {
            get
            {
                return Instance.Xml;
            }
        }

        #region Specially Loaded Items

        public string Nick = null;
        public string User = null;
        public string Realname = null;

        public string IrcServer = null;
        public ushort IrcPort = 0;
        public string IrcPass = null;

        #endregion


        private Config()
        {

            if (!Load())
                Environment.Exit(1);
        }

        public bool Load()
        {
            if (!File.Exists(FILENAME))
            {
                Logger.Error(@"No log file found, please place {0} in the application directory ""{1}""", FILENAME, Environment.CurrentDirectory);
                return false;
            }

            try
            {

                Xml.Load(FILENAME);

                Nick = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/Nick").InnerText;
                User = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/User").InnerText;
                Realname = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/RealName").InnerText;

                IrcServer = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Host").InnerText;
                IrcPort = ushort.Parse(Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Port").InnerText);
                IrcPass = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Pass").InnerText;

            }

            catch (Exception e)
            {
                Logger.Error(e, "Cannot continue without a properly loaded configuration file.");
                Environment.Exit(1);
            }

            return true;
        }


    }
}
