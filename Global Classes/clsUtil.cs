﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DVLD_DriverAndVehiclesLicenseDepartment.Global_Classes
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    clsUtil.DocumentErrorToEventLog(ex.Message);
                    return false;
                }
            }
            return true;

        }
        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsUtil.DocumentErrorToEventLog(iox.Message);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
        public static void DocumentErrorToEventLog(string ErrorMessage)
        {
            string sourceName = "DVLD";

            if(!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");  
            }

            EventLog.WriteEntry(sourceName, ErrorMessage, EventLogEntryType.Error); 
        }

    }
}
