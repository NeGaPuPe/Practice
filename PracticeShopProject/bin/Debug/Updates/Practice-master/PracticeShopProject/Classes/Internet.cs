using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShopProject.Classes
{
    public class Internet
    {
        public static bool ok()
        {
            try
            {
                Dns.GetHostEntry("github.com");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
