using System;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

namespace FWServiceWin7
{
   public class Settings
    {
        public Settings() { }
        [XmlElement("SMTPServerFrom", typeof(string))]
        public string smtpServerFrom = "";

        [XmlElement("SMTPServerPort", typeof(int))]
        public int smtpServerPort = 25;

        [XmlElement("ConnDNS", typeof(string))]
        public string ConnDNS = "";

        [XmlElement("ConnPort", typeof(int))]
        public int ConnPort = 3306 ;

        [XmlElement("ConnDB", typeof(string))]
        public string ConnDB = "";

        [XmlElement("ConnUser", typeof(string))]
        public string ConnUser = "";

        [XmlElement("ConnPassword", typeof(string))]
        public string ConnPassword = "";

        [XmlElement("SMTPServerPassword", typeof(string))]
        public string smtpServerPassword = "";

        [XmlElement("SMTPServerTo1", typeof(string))]
        public string smtpServerTo1 = "";

        [XmlElement("SMTPServerTo2", typeof(string))]
        public string smtpServerTo2 = "";




        public static Settings settings = new Settings();
        public static void Load()
        {
            try
            {
                TextReader reader = new StreamReader("Settings.xml");
                System.Xml.Serialization.XmlSerializer xml = new XmlSerializer(typeof(Settings));
                settings = (Settings)xml.Deserialize(reader);
                reader.Close();
            }
            catch { }
        }

        public void Save()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            Directory.SetCurrentDirectory(Path.GetDirectoryName(currentAssembly.Location));
            try
            {
                TextWriter writer = new StreamWriter("Settings.xml");
                System.Xml.Serialization.XmlSerializer xml = new XmlSerializer(typeof(Settings));
                xml.Serialize(writer, settings);
                writer.Close();
            }
            catch { }
        }

    }
}
