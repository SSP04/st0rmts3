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

            Xml.Load(FILENAME);
            return true;
        }


    }
}
