using System;
using DVLD_BusinessLayer;
using Microsoft.Win32;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes
{
    public static class clsGlobal
    {
        public static clsUser LoggedInUser;
        public static bool SaveUsernameAndPassowrd(string UserName, string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_LoginCredentials";
            try
            {
                Registry.SetValue(keyPath, "UserName", UserName, RegistryValueKind.String);
                Registry.SetValue(keyPath, "Password", Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                clsUtil.DocumentErrorToEventLog(ex.Message);
                return false;
            }
        }
        public static bool GetUserName(ref string UserName)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_LoginCredentials";

            try
            {
                string UsernameValue, PasswordValue;
                UsernameValue = Registry.GetValue(keyPath, "UserName", null) as string;

                if(UsernameValue != null)
                {
                    UserName = UsernameValue;
                    return true;
                } else
                    return false;
               
            }
            catch (Exception ex)
            {
                clsUtil.DocumentErrorToEventLog(ex.Message);
                return false;
            }
            
        }
        public static void DeleteSavedCredentials()
        {
            string keyPath = @"SOFTWARE\DVLD_LoginCredentials";

            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue("UserName");
                            key.DeleteValue("Password");


                            Console.WriteLine("Successfully deleted value  from registry key ");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                clsUtil.DocumentErrorToEventLog("UnauthorizedAccessException");
            }
            catch (Exception ex)
            {
                clsUtil.DocumentErrorToEventLog(ex.Message);
            }
        }
    }
}
