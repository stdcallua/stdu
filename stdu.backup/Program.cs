using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace stdu.backup
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Backup(args[0]);
            }
            
        }

        private static void Backup(string value)
        {
            if (File.Exists(value))
            {
                FileInfo fileInfo = new FileInfo(value);
                String newFileName = String.Empty;
                String sufix = String.Empty;
                int index = 0;
                while (true)
                {

                    String newName = Path.GetFileNameWithoutExtension(value) + "_" + DateTime.Today.ToShortDateString() + sufix + fileInfo.Extension;
                    newFileName = Path.Combine(fileInfo.DirectoryName, newName);
                    if (!File.Exists(newFileName)) break;
                    sufix = "(" + index.ToString() + ")";
                    index++;
                }
                File.Move(value, newFileName);
            }
            else
            {
                DirectoryInfo dirInfo = new DirectoryInfo(value);
                if (dirInfo.Exists)
                {
                    String newDirName = String.Empty;
                    String sufix = String.Empty;
                    int index = 0;
                    while (true)
                    {
                        String newName = dirInfo.Name + "_" + DateTime.Today.ToShortDateString() + sufix;
                        newDirName = Path.Combine(dirInfo.Parent.FullName, newName);
                        if (!Directory.Exists(newDirName)) break;
                        sufix = "(" + index.ToString() + ")";
                        index++;
                    }
                    Directory.Move(value, newDirName);
                }
            }
        }
    }

}
