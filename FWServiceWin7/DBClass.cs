using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace FWServiceWin7
{
    class DBClass
    {
        public static bool CheckName()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var path = Path.GetDirectoryName(currentAssembly.Location);
            string settingspath = path + "\\Settings.xml";
            if (File.Exists(settingspath))
            {
                Settings.Load();
            }
             var NPCname = Environment.MachineName;
             MySqlConnection conn = GetDBConnection();
            try
            {
                conn.Open();
                string Serial = BaseBoardSerial();
                string getDB = "Select * from BaseBoard where Serial =" + Serial;
                MySqlCommand comand = new MySqlCommand(getDB, conn);
                string Check = comand.ExecuteScalar().ToString();
                conn.Close();
                string empty = "";
                if (Check == empty)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }



        public static MySqlConnection
          GetDBConnection(string host, int port, string database, string username, string password)
        {
           
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }

        public static MySqlConnection GetDBConnection()
        {
            //Декодируем пасс
            string input = Settings.settings.ConnPassword;
            byte[] buffer = Convert.FromBase64String(input);
            string pass = Encoding.ASCII.GetString(buffer);
            //Декодируем пасс

            string host = Settings.settings.ConnDNS;
            int port = Settings.settings.ConnPort;
            string database = Settings.settings.ConnDB;
            string username = Settings.settings.ConnUser;
            string password = pass;
            return GetDBConnection(host, port, database, username, password);
        }

        private static string BaseBoardSerial()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardSerial = "";
          
            foreach (ManagementObject mo in moc)
            {
                motherBoardSerial = (string)mo["SerialNumber"];
                

            }
            return motherBoardSerial;
            

        }


        private static string BaseBoardDescription()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardDescription = "";

            foreach (ManagementObject mo in moc)
            {
                motherBoardDescription = (string)mo["Description"];


            }
            return motherBoardDescription;
        }

        private static string BaseBoardStatus()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardStatus = "";

            foreach (ManagementObject mo in moc)
            {
                motherBoardStatus = (string)mo["Status"];


            }
            return motherBoardStatus;
        }

        private static string BaseBoardProduct()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardProduct = "";

            foreach (ManagementObject mo in moc)
            {
                motherBoardProduct = (string)mo["Product"];


            }
            return motherBoardProduct;
        }

        private static string BaseBoardManufacturer()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardManufacturer = "";

            foreach (ManagementObject mo in moc)
            {
                motherBoardManufacturer = (string)mo["Manufacturer"];


            }
            return motherBoardManufacturer;
        }

        private static string BaseBoardVersion()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection moc = mos.Get();
            string motherBoardVersion = "";

            foreach (ManagementObject mo in moc)
            {
                motherBoardVersion = (string)mo["Version"];


            }
            return motherBoardVersion;
        }

        public void OcsXML()
        {
            string path = @"C:\Service";
            string cParaps = "/xml = \"C:\\Service\"";
            string cPath = @"C:\Program Files\OCS Inventory Agent";
            string filename = Path.Combine(cPath, "OCSInventory.exe");
            if
                (Directory.Exists(path))
            { 
            var proc = System.Diagnostics.Process.Start(filename, cParaps);
            proc.WaitForExit();
            }
            


        }





        public static string GetOCSid()
        {

        }



    }





      





 }
