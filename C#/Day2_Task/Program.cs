using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day2_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                Console.WriteLine("Here is My Day 2 Practicals Of C#");
                Console.WriteLine("--------------------------------------");
                Common_Methods.GetName();
                Common_Methods.EvenNumbers();
                Common_Methods.NegativeElementInArray();
                Common_Methods.MaximumMinimum();
                Common_Methods.CountEvenOdd();
                Common_Methods.Print(78);
                Common_Methods.Print("sakshi", 22);
                Common_Methods.Print("Hello");
                Common_Methods.AdditionTask(23, 50);
                Common_Methods.AdditionTask(52, 40, 67);
                Common_Methods.AdditionTask(5.2, 4.9, 6.7);
               
            }
			catch (Exception)
			{
                Console.WriteLine("Something Went Wrong");
            }
        }
    }
}
