using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int i = 0;
                do
                {
                    Console.WriteLine("Enter Task Number Would You Like To Check:");
                    int CheckTask = Convert.ToInt32(Console.ReadLine());
                    switch (CheckTask)
                    {
                        case 1:
                            Common_Methods.CreateFile();
                            break;
                        case 2:
                            Common_Methods.CreateReadWriteFile();
                            break;
                        case 3:
                            Common_Methods.ArrayOfStringsinFile();
                            break;
                        case 4:
                            Common_Methods.AppendText();
                            break;
                        case 5:
                            Common_Methods.ReadFirstLine();
                            break;
                        case 6:
                            Common_Methods.CountNumberofLines();
                            break;
                        case 7:
                            Common_Methods.ExceptionHandle();
                            break;
                        case 8:
                            Common_Methods.DivideByZeroException();
                            break;
                        case 9:
                            Common_Methods.DateFormate();
                            break;
                        case 10:
                            Common_Methods.ArgumentNullException();
                            break;
                        case 11:
                            Common_Methods.EncryptedFormatEmail();
                            break;
                        case 12:
                            Common_Methods.PasswordConfiguration();
                            break;
                        default:
                            Console.WriteLine("Only 12 Task Provided");
                            break;
                    }
                    Console.WriteLine("Yes Or No");
                    var input = Console.ReadLine();
                    if (input == "yes")
                    {
                        i = 0;
                    }
                    else if (input == "no")
                    {
                        i = 15;
                    }
                }

                while (i < 14);
            }
            catch (Exception)
            {
                Console.WriteLine("Something Went Wrong");
            }

        }
    }
}

