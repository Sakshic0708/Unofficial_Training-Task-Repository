using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Day3_Task
{
    internal class Common_Methods
    {
        public static void CreateFile()
        {
            Console.WriteLine("1. Write a program in C# Sharp to create a file and add some text.");
            Console.WriteLine("--------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task1.txt";
            try
            {
                if (File.Exists(MyFile))
                {
                    File.Delete(MyFile);
                }
                File.WriteAllText(MyFile, "Here Is My File created.(Task 1)");
                if (File.Exists(MyFile))
                {
                    Console.WriteLine("File is created.");
                }
                else
                {
                    Console.WriteLine("File is not created.");
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void CreateReadWriteFile()
        {
            Console.WriteLine("2. Write a program in C# Sharp to create a file with text and read the file.");
            Console.WriteLine("--------------------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task2.txt";
            try
            {
                if (File.Exists(MyFile))
                {
                    File.Delete(MyFile);
                }
                using (StreamWriter fileStr = File.CreateText(MyFile))
                {
                    fileStr.WriteLine("Sakshi Chauhan");
                    fileStr.WriteLine("I am From Ahmedabad");
                    fileStr.WriteLine("Favorite Color :- Blue");
                    fileStr.WriteLine("Favorite Food :- Panipuri");
                }
                using (StreamReader ReadFile = File.OpenText(MyFile))
                {
                    string text = "";
                    Console.WriteLine("My Second Task Content:- ");
                    while ((text = ReadFile.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                    }
                    Console.WriteLine("");
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void ArrayOfStringsinFile()
        {
            Console.WriteLine("3. Write a program in C# Sharp to create a file and write an array of strings to the file.");
            Console.WriteLine("------------------------------------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task3.txt";
            string[] arrayLine;
            int NumberOfLine, i;
            try
            {
                if (File.Exists(MyFile))
                {
                    File.Delete(MyFile);
                }
                Console.WriteLine("Number of Lines to Write in File");
                NumberOfLine = Convert.ToInt32(Console.ReadLine());
                arrayLine = new string[NumberOfLine];
                for (i = 0; i < NumberOfLine; i++)
                {
                    Console.Write("Line[" + (i + 1) + "]: ");
                    arrayLine[i] = Console.ReadLine();
                }
                System.IO.File.WriteAllLines(MyFile, arrayLine);
                using (StreamReader read = File.OpenText(MyFile))
                {
                    string text = "";
                    Console.Write("\n The content of the file is  :\n", NumberOfLine);
                    Console.Write("----------------------------------\n");
                    while ((text = read.ReadLine()) != null)
                    {
                        Console.WriteLine(" {0} ", text);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void AppendText()
        {
            Console.WriteLine("4. Write a program in C# Sharp to append some text to an existing file.");
            Console.WriteLine("--------------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task3.txt";
            try
            {
                using (StreamReader readfile = File.OpenText(MyFile))
                {
                    string Text = "";
                    Console.WriteLine("------>Here is the content of the file : ");
                    while ((Text = readfile.ReadLine()) != null)
                    {
                        Console.WriteLine(Text);
                    }
                    Console.WriteLine("");
                }
                using (StreamWriter readfile = File.AppendText(MyFile))
                {
                    readfile.WriteLine("This is Extra Line");

                }
                using (StreamReader FinalRead = File.OpenText(MyFile))
                {
                    string text = "";
                    Console.WriteLine(" ------>Here is the content of the file after appending the text : ");
                    while ((text = FinalRead.ReadLine()) != null)
                    {
                        Console.WriteLine(text);
                    }
                }
            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }
        }

        public static void ReadFirstLine()
        {
            Console.WriteLine("5.Write a program in C# Sharp to read the first line from a file.");
            Console.WriteLine("------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task3.txt";
            try
            {
                using (StreamReader readfile = File.OpenText(MyFile))
                {
                    string Text = "";
                    Console.WriteLine("------>Here is the content of the file : ");
                    while ((Text = readfile.ReadLine()) != null)
                    {
                        Console.WriteLine(Text);
                    }
                    Console.Write("------> The content of the first line of the file is :\n");
                    if (File.Exists(MyFile))
                    {
                        string[] lines = File.ReadAllLines(MyFile);
                        Console.Write(lines[0]);
                    }
                    Console.WriteLine();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void CountNumberofLines()
        {
            Console.WriteLine("6.Write a program in C# Sharp to count the number of lines in a file.");
            Console.WriteLine("------------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Task3.txt";
            int count;
            try
            {
                using (StreamReader sr = File.OpenText(MyFile))
                {
                    string s = "";
                    count = 0;
                    Console.WriteLine("------>Here is the content of the file: ");
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                        count++;
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("Count Number Of Lines is:{1}",MyFile, count);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void ExceptionHandle()
        {
            Console.WriteLine("7. Throw a Simple Exception and handle it.");
            Console.WriteLine("----------------------------------------------");
            try
            {
                int result;
                Console.WriteLine("Enter First Number");
                int Firstnumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Second Number");
                int Secondnumber = Convert.ToInt32(Console.ReadLine());
                result = Firstnumber / Secondnumber;
                Console.WriteLine("Division: Value is {0}", result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.");
            }

        }

        public static void DivideByZeroException()
        {
            Console.WriteLine("8. Create a program to ask the user for two numbers and display their division. Errors must be trapped using \"try..catch\".(Hint here used DivideByZeroException)");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            try
            {
                int result;
                Console.WriteLine("Enter First Number");
                int Firstnumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Second Number");
                int Secondnumber = Convert.ToInt32(Console.ReadLine());
                result = Firstnumber / Secondnumber;
                Console.WriteLine("Division: Value is {0}", result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Division of {0} by zero.");
            }
        }

        public static void DateFormate()
        {
            Console.WriteLine(" C# Create one extension method called DateFormate() which returns today's date in user given date format.(means user will pass date format the function will return date in that format).");
            Console.WriteLine("-------------------------------------------------------------------");
            DateTime today = DateTime.Today;
            string format = "yyyy/mm/dd"; // Example format
            string formattedDate = today.DateFormateExt(format);

            Console.WriteLine(formattedDate); // Output: 2023-03-24
        }

        public static void ArgumentNullException()
        {
            Console.WriteLine("10. Throw ArgumentNullException and handle it.");
            Console.WriteLine("-------------------------------------------------");
            string name = null;

            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name), "Name cannot be null.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message); 
            }

        }

        public static void EncryptedFormatEmail()
        {
            Console.WriteLine("11.Write a Program in C# to Create one File and store User Email Address in encrypted format. Also read that file and retrieve its original format.");
            Console.WriteLine("-----------------------------------------------------------------------------");
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\EncryptedEmail.txt";
            try
            {
                if (File.Exists(MyFile))
                {
                    File.Delete(MyFile);
                }
                var email = "Chauhan.sakshi0708@gmail.com";
                var encryptedString = EncryptedString(email);

                var OriginalEmail = DecryptedString(encryptedString);

                // Write the encrypted and decrypted strings to the file
                using (StreamWriter writer = new StreamWriter(MyFile))
                {
                    writer.WriteLine("Encrypted String: " + encryptedString);
                }

                // Read the file and display its contents
                using (StreamReader reader = new StreamReader(MyFile))
                {
                    Console.WriteLine("File Contents:");
                    Console.WriteLine("--------------");
                    Console.WriteLine("Original Email:"+OriginalEmail);
                 
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static string EncryptedString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
        private static string DecryptedString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch(FormatException fe)
            {
                decrypted = " ";
            }
            return decrypted;
        }
        public static void PasswordConfiguration()
        {
            string configvalue1 = ConfigurationManager.AppSettings["password"];
            var encryptedPass = EncryptedString(configvalue1);
            string MyFile = @"D:\Sakshi Chauhan\C#\Day3_Task\Password.txt";

            if (File.Exists(MyFile))
            {
                File.Delete(MyFile);
            }


            using (StreamWriter writer = new StreamWriter(MyFile))
            {

                writer.WriteLine(encryptedPass);
            }

        }
    }
    public static class DateExtensions
    {
        public static string DateFormateExt(this DateTime date, string format)
        {
            return date.ToString(format);
        }
    }
}
