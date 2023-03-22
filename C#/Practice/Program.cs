using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int originNum = 20;
            originNum = 15;
            char FirstCharacter = 'S';
            const int value = 10;
            String name = "chauhan sakshi ";
            String FatherName = "Pravinbhai";
            String FullName = name + FatherName;
            double pointValue = 1.99;
            Console.WriteLine("Hello World");
            Console.WriteLine("I am Learning C#");
            Console.WriteLine(2 + 2);
            Console.WriteLine(a * b);
            Console.WriteLine(name);
            Console.WriteLine(FirstCharacter);
            Console.WriteLine(pointValue);
            Console.WriteLine(originNum);
            Console.WriteLine(value);
            Console.WriteLine("hello " + name);
            Console.WriteLine(FullName);
            //ReadLine
            Console.WriteLine("Enter Your Name");
            String Name = Console.ReadLine();
            Console.WriteLine("Name is:"+ Name);

            //Readline Int
            Console.WriteLine("Enter Age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Age is:" + age);

            var first = Math.Max(5, 10);
        }
    }

}
