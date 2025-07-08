using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DVLD_BusinessLayer;
using static System.Windows.Forms.LinkLabel;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes
{
    public static class clsGlobal
    {
        public static clsUser LoggedInUser;
        public static bool SaveUsernameAndPassowrd(string UserName, string Password)
        {
            string[] credentials = { UserName, Password };
            try
            {
                File.WriteAllLines("Credentials.txt", credentials);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool GetUserNameAndPassword(ref string UserName, ref string Password)
        {
            if(File.Exists("Credentials.txt"))
            {
                var lines = File.ReadAllLines("Credentials.txt");
                UserName = lines.ElementAtOrDefault(0);
                Password = lines.ElementAtOrDefault(1);
                return true;
            }
            return false;
        }
        public static void DeleteSavedCredentials()
        {
            if (File.Exists("Credentials.txt"))
            {
                try
                {
                    File.Delete("Credentials.txt");
                }
                catch (Exception ex)
                {
                }
            } 
        }
    }
}
