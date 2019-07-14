using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FWServiceWin7
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Check site = new Check();
            string url = "http://www.google.ru/robots.txt";
            //site.testSite(url);
            bool state = DBClass.CheckName();
            bool ff = site.testSite(url);
            if (state == false)
            {


            }
            if (ff == false)
            {


            }
            


        }

        protected override void OnStop()
        {
        }
    }
 


}

