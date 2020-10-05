using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpZip
{
    class Program
    {
        public static void Zipfiles(List<string> filepathlist, string zipnamepath)
        {
            try
            {
                using (var zip = ZipFile.Open(zipnamepath, ZipArchiveMode.Create))
                {

                    foreach (string filepath in filepathlist)
                    {
                        string filename = Path.GetFileName(filepath);
                        zip.CreateEntryFromFile(filepath, filename);
                    }
                }
                Console.WriteLine(" [+] Packed compressed file to {0} succeeded", zipnamepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" [-] Failed with error info: {0}", ex.Message);
            }

        }

        public static void CreateFromDirectory(string sourceDirectoryName, string destinationArchiveFileName)
        {
            try
            {
                ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);
                Console.WriteLine(" [+] Packed compressed directory to {0} succeeded", destinationArchiveFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" [-] Failed with error info: {0}", ex.Message);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Author: Uknow");
            Console.WriteLine("https://github.com/uknowsec/SharpZip");
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SharpZip.exe C:\\somefolder C:\\someotherfolder\\somefile.zip");
                Console.WriteLine("Usage: SharpZip.exe C:\\someotherfolder\\somefile.zip C:\\someotherfolder\\a.jpg C:\\someotherfolder\\b.jpg ...");
            }
            else
            {
                if (!Path.HasExtension(args[0]))
                {
                    Console.WriteLine(" [+] Packed compressed directory");
                    CreateFromDirectory(args[0], args[1]);
                }
                else
                {
                    Console.WriteLine(" [+] Packed compressed file");
                    List<string> list = new List<string>();
                    for (int i = 1; i < args.Length; i++)
                    {
                        list.Add(args[i]);
                    }
                    Zipfiles(list, args[0]);
                }
            }

           

        }
    }
}
