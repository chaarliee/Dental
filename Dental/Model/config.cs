using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dental.Model
{
    class config
    {
    }

    public static class Config
    {
        public static string ConnectionString = "Server=DESKTOP-TSBJPEA;Database=Dental;Trusted_Connection=True;";

        public static string Email_Sender = ""; // Your email address
        public static string Email_Password = ""; // Your password
        public static string Email_SMTP = "smtp.gmail.com"; // Your email host
        public static int Email_PORT = 587; // Your email port

       

        public static readonly string Semaphore_ApiKey = "60f5af431b616274d01ed76f2ad0b335";


        public static string moviderAPI = "2j3qNxcaWmsdknYVD9uipWwM_kBL_b";
        public static string moviderSecret = "ra-rmRjry-gSa9VU5eUFcUE1n2N_C_";
        public static string moviderApp = "Dental App";
    }
}
