using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Task
{
    internal class Common_Methods
    {
        public static void GetName()
        {
            Console.WriteLine("------- Write Name 5 Times -------");
            for(int i = 0; i < 5; i++) 
            {
                Console.WriteLine("Sakshi Chauhan");
            }
        }
        public static void EvenNumbers()
        {
            Console.WriteLine("------- even numbers greater than 0 and less than 50. (do not print 2,12,22,32,42) -------");
            for (int i = 1; i <= 50; i++)
            {
                if (i % 2 == 0)
                {
                    if (i % 10 == 2)
                    {
                        continue;
                    }
                    string Print = string.Concat(i,",");
                    Console.Write(Print);
                }
            }
        }
        public static void NegativeElementInArray() 
        {
           
            Console.WriteLine("\n------- Count Negative Elements in Array -------");
            Console.WriteLine("How Many Elements You want in Array");
            int Elements = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[Elements];
            for (int i = 0; i < Elements; i++)
            {
                Console.Write("Element[" + (i + 1) + "]: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Elements in array are: ");
            for (int i = 0; i < Elements; i++)
            {
                Console.Write("{0}  ", arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    var NegativeCount = arr.Where(n => n < 0);
                    Console.WriteLine("\nNegative Element Count: " + NegativeCount.Count());
                  
                }
            }

        }
        public static void MaximumMinimum()
        {
            Console.WriteLine("\n------- find Maximum and Minimum Element in Array -------");
            Console.WriteLine("How Many Elements You want in Array");
            int Elements = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[Elements];
            for (int i = 0; i < Elements; i++)
            {
                Console.Write("Element[" + (i + 1) + "]: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Minimum number is " + arr.Min());
            Console.WriteLine("Maximum number is " + arr.Max());
        }
        public static void CountEvenOdd()
        {
            int odd_count = 0;
            int even_count = 0;
            Console.WriteLine("\n------- Count Even and Odd Elements in array  -------");
            Console.WriteLine("How Many Elements You want in Array");
            int Elements = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[Elements];
            for (int i = 0; i < Elements; i++)
            {
                Console.Write("Element[" + (i + 1) + "]: ");
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    even_count++;
                }
                else
                    odd_count++;
            }
            Console.WriteLine("Number of Even Elements:" + even_count);
            Console.WriteLine("Number of Odd Elements:" + odd_count);

        }
        public static void Print(int num1)
        {
            Console.WriteLine("\n--------print int, string and int, string value -------");
            int Number = num1;
            Console.WriteLine(Number);
        }
        public static void Print(string Name, int num1)
        {
            string name = Name;
            Console.WriteLine(name);
            int Number = num1;
            Console.WriteLine(Number);
        }
        public static void Print(string Name)
        {
            string name = Name;
            Console.WriteLine(name);
        }
        public static void AdditionTask(int number1,int number2) 
        {
            Console.WriteLine("\n------- sum of two integer value, three integer value and three double values -------");
            int sum = number1+ number2;
            Console.WriteLine(sum);
        }
        public static void AdditionTask(int number1, int number2, int number3)
        {
            int sum = number1 + number2 + number3;
            Console.WriteLine(sum);
        }
        public static void AdditionTask(double number1, double number2, double number3)
        {
            double sum = number1 + number2 + number3;
            Console.WriteLine(sum);
        }

    }
}
