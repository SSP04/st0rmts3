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



        public string Nick
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/Nick").InnerText.Trim(); }
        }
        public string User
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/User").InnerText.Trim(); }
        }
        public string Realname
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Bot/RealName").InnerText.Trim(); }
        }

        public string IrcServer 
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Host").InnerText.Trim(); }
        }
        public ushort IrcPort
        {
            get { return ushort.Parse(Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Port").InnerText.Trim()); }
        }
        public string IrcPass
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Server/Pass").InnerText.Trim(); }
        }

        public string TS3Nick
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/Nick").InnerText.Trim(); }
        }
        public string TS3Host
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/Host").InnerText.Trim(); }
        }
        public ushort TS3Port
        {
            get { return ushort.Parse(Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/Port").InnerText.Trim()); }
        }
        public string TS3Pass
        {
            get { return Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/Pass").InnerText.Trim(); }
        }


        public string TS3Identity
        {
            get
            {
                string result = null;
                return (String.IsNullOrEmpty(result = Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/IdentityString").InnerText.Trim()) ? null : result);
            }
            set
            {
                Xml.DocumentElement.SelectSingleNode("/TS3Bot/Client/IdentityString").InnerText = value;
                Save();
            }
        }

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
            

            }

            catch (Exception e)
            {
                Logger.Error(e, "Cannot continue without a properly loaded configuration file.");
                Environment.Exit(1);
            }

            return true;
        }

        /// <summary>
        /// Saves the XML. Automatically called when properties are modified.
        /// </summary>
        public void Save()
        {
            Xml.Save(FILENAME);
            Logger.Log("Configuration file saved.");
        }


    }
}
