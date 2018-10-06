using System;
using System.IO;
using System.Xml;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputFileSystemInfo();
            //WorkWithDrives();
            //WorkWithDirectories();
            //WorkWithFiles();
            //WorkWithXml();
        }

        private static void OutputFileSystemInfo()
        {
            Console.WriteLine($"Path.PathSeparator: {Path.PathSeparator}");
            Console.WriteLine($"Path.DirectorySeparatorChar: {Path.DirectorySeparatorChar}");
            Console.WriteLine($"Directory.GetCurrentDirectory(): {Directory.GetCurrentDirectory()}");
            Console.WriteLine($"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
            Console.WriteLine($"Environment.SystemDirectory: {Environment.SystemDirectory}");
            Console.WriteLine($"Path.GetTempPath(): {Path.GetTempPath()}");
            Console.WriteLine($"GetFolderPath(SpecialFolder):");
            Console.WriteLine($"\tSystem: {Environment.GetFolderPath(Environment.SpecialFolder.System)}");
            Console.WriteLine($"\tApplicationData: {Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}");
            Console.WriteLine($"\tMy Documents: {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
            Console.WriteLine($"\tPersonal: {Environment.GetFolderPath(Environment.SpecialFolder.Personal)}");
        }

        private static void WorkWithDrives()
        {
            Console.WriteLine("|--------------------------------|------------|---------|--------------------|--------------------|");
            Console.WriteLine("| Name                           | Type       | Format  | Size               | Free space         |");
            Console.WriteLine("|--------------------------------|------------|---------|--------------------|--------------------|");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"| {drive.Name,-30} | {drive.DriveType,-10} | {drive.DriveFormat,-7} | {drive.TotalSize,18:N0} | {drive.AvailableFreeSpace,18:N0} |");
                }
            }
            Console.WriteLine("|--------------------------------|------------|---------|--------------------|--------------------|");
        }

        private static void WorkWithDirectories()
        {
            // define a custom directory path
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var customFolder = new string[]
            {
                userFolder, "Code", "Chapter09", "MyNewFolder"
            };
            string dir = Path.Combine(customFolder);

            Console.WriteLine($"Working with {dir}");

            // check if it exists
            Console.WriteLine($"Does it exist? {Directory.Exists(dir)}");

            // create directory
            Console.WriteLine("Creating it...");
            Directory.CreateDirectory(dir);
            Console.WriteLine($"Does it exist? {Directory.Exists(dir)}");

            Console.Write("Confirm the directory exists, and then press ENTER: ");
            Console.ReadLine();

            // delete directory
            Console.WriteLine("Deleting it...");
            Directory.Delete(dir, recursive: true);
            Console.WriteLine($"Does it exist? {Directory.Exists(dir)}");
        }

        private static void WorkWithFiles()
        {
            // define a custom directory path
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var customFolder = new string[]
            {
                userFolder, "Code", "Chapter09", "OutputFiles"
            };

            string dir = Path.Combine(customFolder);
            Directory.CreateDirectory(dir);

            // define file paths
            string textFile = Path.Combine(dir, "Dummy.txt");
            string backupFile = Path.Combine(dir, "Dummy.bak");

            Console.WriteLine($"Working with: {textFile}");

            // check if a file exists
            Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close(); // close file and release resources

            Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

            // copy the file, and overwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

            Console.WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

            Console.Write("Confirm the files exist, and then press ENTER: ");
            Console.ReadLine();

            // delete file
            File.Delete(textFile);

            Console.WriteLine($"Does it exist? {File.Exists(textFile)}");

            // read from the test file backup
            Console.WriteLine($"Reading contents of {backupFile}:");
            StreamReader textReader = File.OpenText(backupFile);
            Console.WriteLine(textReader.ReadToEnd());
            textReader.Close();
        }

        // define an array of college teams
        static string[] teams = new string[] { "Hawkeyes", "Buckeyes", "Hoosiers", "Spartans", "Fighting Illini", "Wolverines", "Nittany Lions", "Scarlet Knights", "Terrapins", "Golden Gophers", "Badgers", "Cornhuskers", "Wildcats", "Boilermakers" };

        private static void WorkWithXml()
        {
            // define a custom directory path
            string userFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            var customFolder = new string[]
            {
                userFolder, "Code", "Chapter09", "OutputFiles"
            };
            string dir = Path.Combine(customFolder);

            // define a file to write to
            string xmlFile = Path.Combine(dir, "streams.xml");

            // create a file stream
            using (FileStream xmlFileStream = File.Create(xmlFile))
            {
                // wrap the file stream in an XML writer helper
                // and automatically indent nested elements
                using (XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true }))
                {
                    // write the XML declaration
                    xml.WriteStartDocument();

                    // write a root element
                    xml.WriteStartElement("teams");

                    // enumerate the strings writing each one to the stream
                    foreach(var item in teams)
                    {
                        xml.WriteElementString("team", item);
                    }

                    // write the close root element
                    xml.WriteEndElement();

                    // close helper and stream
                    xml.Close();
                    xmlFileStream.Close();
                }
            }

            // output all the contents of the file to the Console
            Console.WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes.");
            Console.WriteLine(File.ReadAllText(xmlFile));
        }
    }
}
