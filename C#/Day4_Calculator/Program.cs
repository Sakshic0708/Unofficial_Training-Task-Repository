using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Write a program that calculate add, subtract, multiply and division. Accept two number from the users and then using appropriate function calculate them and shows output to the user.");
            Console.WriteLine("---------------------------------------------------------------------------");
     
                Console.WriteLine("Enter the Action");
                Console.WriteLine("Addition:- +");
                Console.WriteLine("Division:- -");
                Console.WriteLine("Multiplication:- *");
                Console.WriteLine("Division:- /");

                Console.Write("Please enter an operand (+, -, /, *): ");
                string Operand = Console.ReadLine();

                Console.WriteLine("Enter First Number:");
                var Number1 = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter Second Number:");
                var Number2 = Convert.ToDecimal(Console.ReadLine());
                switch (Operand)
                {
                    case "+":
                        Addition(Number1 ,Number2);
                        break;
                    case "-":
                        Substraction(Number1 ,Number2);
                        break;
                    case "*":
                        Multiplication(Number1, Number2);
                        break;
                    case "/":       
                        Division(Number1, Number2);
                        break;  
                default:
                        Console.WriteLine("Invalid Operator");
                        break;
                } 
        }
        public static void Addition(decimal Number1,decimal Number2)
        {
            decimal Add = Decimal.Add(Number1, Number2);
            Console.WriteLine("Addition of"+ " "+ Number1+ " "+ "And" + " "+Number2 +" "+"="+" "+Add);
        }
        public static void Substraction(decimal Number1, decimal Number2)
        {
            decimal substract = Decimal.Subtract(Number1, Number2);
            Console.WriteLine("Substraction of" + " " + Number1 + " " + "And" + " " + Number2 + " " + "=" + " " + substract);
        }
        public static void Multiplication(decimal Number1, decimal Number2)
        {
            decimal Multiply = Decimal.Multiply(Number1, Number2);
            Console.WriteLine("Multiplication of" + " " + Number1 + " " + "And" + " " + Number2 + " " + "=" + " " + Multiply);
        }
        public static void Division(decimal Number1, decimal Number2)
        {
            decimal division = Decimal.Divide(Number1, Number2);
            Console.WriteLine("Division of" + " " + Number1 + " " + "And" + " " + Number2 + " " + "=" + " " + division);
        }
    }
}
