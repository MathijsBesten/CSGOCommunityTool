using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGOCommunityTool.functions
{
    class ProfileSaver_ProfileReader
    {
        public static string fullFilePath { get; set; }

        public static int profileMaker(string steamID) // first time if there is no user logged in ever
        {
            string MydocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string CSGOSaveFolder = "CSGOCommunityTool";
            string saveFileName = "userdetails.txt";
            string fullFolderPath = MydocumentsPath + "\\" + CSGOSaveFolder;
            string fullFilePath = fullFolderPath + "\\" + saveFileName;
            int result;
            if (!System.IO.Directory.Exists(fullFolderPath))
            {
                System.IO.Directory.CreateDirectory(MydocumentsPath + "\\" + CSGOSaveFolder);
                File.Create(fullFilePath);
                StreamWriter file = new StreamWriter(fullFilePath);
                file.WriteLine(steamID);
                file.Close();
                return 1; // folder and file has been made and user logged in
            }
            else
            {
                if (!File.Exists(fullFilePath))
                {
                    File.Create(fullFilePath);
                    StreamWriter file = new StreamWriter(fullFilePath);
                    file.WriteLine(steamID);
                    file.Close();
                    return 1; // file had been made and user logged in
                }
                else
                {
                    var saveToFile = checkForSteamIDInFile(steamID);
                    return 1; // steamID has been checked and steamID is in file
                }
            }
            return 0; // not posible, this for the future
        }


        public static int checkForSteamIDInFile(string steamID) // funtion to check if there is a steamID in the user file
        {
            string MydocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string CSGOSaveFolder = "CSGOCommunityTool";
            string saveFileName = "userdetails.txt";
            string fullFolderPath = MydocumentsPath + "\\" + CSGOSaveFolder;
            string fullFilePath = fullFolderPath + "\\" + saveFileName;
            if (!File.Exists(fullFilePath))
            {
                int makeFile = profileMaker(steamID);
                return 3; // the userfile was not found, but it has been made - user correcly logged in
            }
            else
            {
                string userdetails = File.ReadAllText(fullFilePath);
                if (userdetails.Length == 17)
                {
                    bool steamIDsAreTheSame = userdetails == steamID;
                    if (!steamIDsAreTheSame)
                    {
                        StreamWriter file = new StreamWriter(fullFilePath);
                        file.WriteLine(steamID);
                        file.Close();
                        return 1; // a other user was still in the file - user correctly logged in
                    }
                    else
                    {
                        return 2; // the old and the new id are the same, no changes made - user correctly logged in
                    }
                }
                else
                {
                    StreamWriter file = new StreamWriter(fullFilePath);
                    file.WriteLine(steamID);
                    file.Close();
                    return 3; // there was nobody logged in - user correctly logged in 
                }
            }
            return 0; // something fucked up :(
        }
        public static void logoutProfile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CSGOCommunityTool" + "\\" +  "userdetails.txt";
            File.WriteAllText(path, "");
        }
    }
}
