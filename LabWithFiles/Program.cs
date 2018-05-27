using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Games\Counter-Strike 1.6";

            List<string> AllFormats = new List<string>();
            List<string> FilesWithSimbols = new List<string>();
            string symbols = "";
            string symbols1 = "";
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo item in dir.GetFiles())
            {
                if (ContainsSymbol(item.Name.Remove(item.Name.Length - 4)))
                {
                    FilesWithSimbols.Add(item.Name.Remove(item.Name.Length - 4));
                }
                if (!AllFormats.Contains(item.Extension))
                {
                    Console.Write(item.Extension + " | ");
                    AllFormats.Add(item.Extension);
                }
            }
            Console.WriteLine();
            List<string> ListFormatov = new List<string>();
            Console.WriteLine();
            string format = " ";
            //do
            //{
            //    Console.Write("С каким форматом будем работать? (Можно выбрать несколько) (Введите Enter для выхода): ");
            //    format = Console.ReadLine();
            //    if (AllFormats.Contains(format))
            //        ListFormatov.Add('.'+format);
            //}
            //while (!string.IsNullOrEmpty(format));


            //foreach (FileInfo item in dir.GetFiles())
            //{
            //    //if (ListFormatov.Contains(item.Extension))
            //    //{
            //        Console.Write("{0,-17}{1}", "Полный путь ", "->"); Console.WriteLine(item.DirectoryName);
            //        Console.Write("{0,-17}{1}", "Размер ", "->"); Console.WriteLine(item.Length);
            //        Console.Write("{0,-17}{1}", "Имя ", "->"); Console.WriteLine(item.Name);
            //        //Console.WriteLine(item.FullName);
            //        Console.Write("{0,-17}{1}", "Дата создания ", "->"); Console.WriteLine(item.CreationTime);
            //        Console.WriteLine("--------------------------------------------------");
            //    //}
            //}

            foreach (string item in FilesWithSimbols)
            {
                foreach (char i in item)
                {
                    if ((!(i >= 48 && i <= 57)) && (!(i >= 65 && i <= 90)) && (!(i >= 97 && i <= 122)))
                        symbols += i;
                }
                Console.WriteLine(item);
            }
            foreach (char item in symbols)
            {
                if (!symbols1.Contains(item))
                    symbols1 += item;
            }
            Console.Write("В наименованиях присутствовали символы: ");
            foreach (char item in symbols1)
            {
                Console.Write("<" + item + "> заменить на "); string a = Console.ReadLine();
                foreach (FileInfo i in dir.GetFiles())
                {
                    if(item == 32)
                    {
                        foreach (char it in i.Name)
                        {
                            if (it >= 128 && it <= 175 || it >= 224 && it <= 241)
                                break;
                        }
                    }
                    i.Name.Replace(item, a[0]);
                    i.MoveTo(@"C:\i.Name");
                }
            }
        }
            static bool ContainsSymbol(string s)
            {

                foreach (char item in s)
                {
                    if ((!(item >= 48 && item <= 57)) && (!(item >= 65 && item <= 90)) && (!(item >= 97 && item <= 122)))
                    {
                        return true;
                    }
                    //int q = 0;
                    //if(!(item >= 48 && item <= 57))
                    //{
                    //    ++q;
                    //}
                    //if(!(item >= 65 && item <= 90))
                    //{
                    //    ++q;
                    //}
                    //if (!(item >= 97 && item <= 122))
                    //{
                    //    ++q;
                    //}
                    //if (q == 3)
                    //{
                    //    return true;
                    //}
                }
                return false;
            }


        }

    }
