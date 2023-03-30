using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_One_Two
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task1.TaskOne();
            Task2.TaskTwo();
        }
    }
    public class Task1
    {
        public static void TaskOne()
        {
            Console.WriteLine("  Write a C# Sharp program to create a new list from a given list of integers where each integer value is added to 2 and the result value is multiplied by 5.");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("How Many List Element You Want in Array?");
            int UserInput = Convert.ToInt32(Console.ReadLine());
            List<int> originalList = new List<int>();
            for (int i = 0; i < UserInput; i++)
            {
                Console.WriteLine("Enter List {0}'s:", i + 1);
                originalList.Add(Convert.ToInt32(Console.ReadLine()));
            }
            Console.WriteLine("List Elements Are:-");
            foreach (int i in originalList)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Requirments of Task");
            List<int> requiredList = test(new List<int>(originalList));
            foreach (int i in requiredList)
            {
                Console.WriteLine(i);
            }
        }
        public static List<int> test(List<int> nums)
        {
            IEnumerable<int> e = nums.Select(x => 5 * (x + 2));
            return e.ToList();
        }
    }
    public class Task2
    {
        public static void TaskTwo()
        {
            var Number = new int[] { 1, 2, 4, 6, 7, 8, 9, 10, 12, 17, 19, 20, 21, 24, 25, 30 };

            string[] groups = GroupPageNumbers(Number);

            Console.WriteLine("Original: {0}", BuildList(Number.Select(p => p.ToString())));
            Console.WriteLine("Grouped:  {0}", BuildList(groups));
        }
        static string[] GroupPageNumbers(int[] Number)
        {
            var groups = new List<string>();

            for (int i = 0; i < Number.Length; i++)
            {
                int start = Number[i];
                while (i < Number.Length - 1 && Number[i + 1] == Number[i] + 1)
                {
                    i++;
                }
                groups.Add(FormatGroup(start, Number[i]));
            }

            return groups.ToArray();
        }

        static string FormatGroup(int start, int end)
        {
            return start == end ? start.ToString() : string.Format("{0}-{1}", start, end);
        }

        static string BuildList(IEnumerable<string> items)
        {
            return string.Join(", ", items.ToArray());
        }
    }
}
