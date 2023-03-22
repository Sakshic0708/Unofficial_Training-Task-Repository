using System;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] nameone = { "sakshi", "chuahan" };
            //string[] nametwo = { "abc", "def" };
            //string[] namethree = { "xyz", "pqr" };
            //string[] namefour = { "mno", "ghi" };
            string[,] name = { { "sakshi", "chuahan" }, { "abc", "def" }, { "xyz", "pqr" }, { "mno","ghi"} };

            for (string i = 0; i < name.GetLength(0); i++)
            {
                for (string j = 0; j < name.GetLength(1); j++)
                {
                    Console.WriteLine(name[i, j] + " ");
                }
            }
        }
    }
}