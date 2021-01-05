using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Labb3.UtilityTools
{
    public static class SReader
    {
        public static void GenerateFile()
        {
            //Skapar en mapp + txt fil
            string filePath = (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logotypes\\");
            string file1 = "LogoDungeonsOfDaggorath.txt";
            string file2 = "LogoStore.txt";
            string pathAndFile = string.Concat(filePath, file1, file2);

            if (!Directory.Exists(filePath))//Om mapp inte finns körs denna
            {
                Directory.CreateDirectory(filePath); //Skapar en mapp
                var saveFile = File.Create(pathAndFile);
                saveFile.Close();
            }

            if (Directory.Exists(filePath) && new FileInfo(@"Logotypes\LogoDungeonsOfDaggorath.txt").Length == 0)
            {
                var saveFile = File.Create(pathAndFile);
                saveFile.Close();
            }
        }

    }
}
