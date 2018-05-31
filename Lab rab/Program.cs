using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь с файлами");
            string path = Console.ReadLine();
            //E:\TNSShort
            DirectoryInfo dir = new DirectoryInfo(path);
            List<FileInfo> oldFiles = dir.GetFiles().ToList();

            foreach (FileInfo item in dir.GetFiles())
            {
                Console.WriteLine(item.Extension);
            }

            Console.WriteLine("Выберите одно или несколько расширений");
            string[] extension = Console.ReadLine().Split(' ');

            List<FileInfo> findedFilesWithExtension = oldFiles.Where(w => extension.Contains(w.Extension.Replace(".", ""))).ToList();

            if (oldFiles.Count != 0)
                Console.WriteLine($"Общее количество найденных файлов: {oldFiles.Count}");
            else
            {
                Console.WriteLine("Файлы не найдены");
                return;
            }

            Console.WriteLine("Разрешить работу над файлами? 1 - да, 0 - нет");

            int.TryParse(Console.ReadLine(), out int choice);
            if (choice == 1)
            {
                foreach (FileInfo item in findedFilesWithExtension)
                {
                    if (item.Name.Contains("_"))
                    {
                        Console.Write("Заменить \"_\" на ");
                        string str = item.Name.Replace(".", Console.ReadLine());
                        str = str.Insert(str.IndexOf($"{item.Extension.Replace(".", "")}"), ".");
                        File.Move(Path.Combine(dir.FullName, item.Name), Path.Combine(dir.FullName, str));
                    }
                    else if (item.Name.Contains("-"))
                    {
                        Console.Write("Заменить \"-\" на ");
                        string str = item.Name.Replace(".", Console.ReadLine());
                        str = str.Insert(str.IndexOf($"{item.Extension.Replace(".", "")}"), ".");
                        File.Move(Path.Combine(dir.FullName, item.Name), Path.Combine(dir.FullName, str));
                    }
                    else if (item.Name.Contains("."))
                    {
                        Console.Write("Заменить \".\" на ");
                        string str = item.Name.Replace(".", Console.ReadLine());
                        str = str.Insert(str.IndexOf($"{item.Extension.Replace(".", "")}"), ".");
                        File.Move(Path.Combine(dir.FullName, item.Name), Path.Combine(dir.FullName, str));
                    }
                }
            }





            Console.ReadLine();
        }
    }
}

