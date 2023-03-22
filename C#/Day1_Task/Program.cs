using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day1_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Enter TaskName Would You Like Check");
            string checkTask = Console.ReadLine();
            switch (checkTask)
            {
                case "PositiveNegative":

                    Console.WriteLine("Check Whether Number Is Positive Or Negative:-");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Input an integer : ");
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number > 0)
                    {
                        Console.WriteLine("This Number is Positive");
                    }
                    else if(number < 0)
                    {
                        Console.WriteLine("This Number is Negative");
                    }
                    else
                    {
                        Console.WriteLine("This Number is Zero");
                    }
                    break;

                case "PrintDayOfWeek":
                    Console.WriteLine(" enter week number and print day of week");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Enter Week Of Day");
                    int WeekDay = Convert.ToInt32(Console.ReadLine());
                    switch (WeekDay)
                    {
                        case 1:
                            Console.WriteLine("Moday");
                            break;
                        case 2:
                            Console.WriteLine("Tuesday");
                            break;
                        case 3:
                            Console.WriteLine("Wednesday");
                            break;
                        case 4:
                            Console.WriteLine("Thursday");
                            break;
                        case 5:
                            Console.WriteLine("Friday");
                            break;
                        case 6:
                            Console.WriteLine("Saturday");
                            break;
                        case 7:
                            Console.WriteLine("sunday");
                            break;
                        default:
                            Console.WriteLine("Sorry!! WeekDays is 7");
                            break;
                    }
                    break;

                case "MinMaxNumber":
                    Console.WriteLine("Minimum or Maximum find in 2 Input Values");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("Enter First Number");
                    int Firstnumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Second Number");
                    int Secondnumber = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("What Number is Find? Maximum Or Minimum");
                    String MinMax = Console.ReadLine();
                    switch (MinMax)
                    {
                        case "Maximum":
  
                           //if(Firstnumber > Secondnumber)
                           // {
                           //     Console.WriteLine(Firstnumber);
                           // }
                           //else if(Firstnumber < Secondnumber)
                           // {
                           //     Console.WriteLine(Secondnumber);
                           // }
                           Console.WriteLine(Math.Max(Firstnumber, Secondnumber));
                            break;
                        case "Minimum":
                            //if (Firstnumber < Secondnumber)
                            //{
                            //    Console.WriteLine(Firstnumber);
                            //}
                            //else if (Firstnumber > Secondnumber)
                            //{
                            //    Console.WriteLine(Secondnumber);
                            //}
                            Console.WriteLine(Math.Min(Firstnumber, Secondnumber));
                            break;
                    }
                    break;
                case "Temperature":
                    Console.WriteLine("Accept a temperature in centigrade and display a suitable message:");
                    Console.WriteLine("--------------------------------------------------------------------");

                    Console.WriteLine("Input Day Temperature ");
                    int temp = Convert.ToInt32(Console.ReadLine());
                    if (temp <= 0)
                        Console.WriteLine("Freezing weather");
                    else if (temp <= 10)
                        Console.WriteLine("Very Cold weather");
                    else if (temp <= 20)
                        Console.WriteLine("Cold weather");
                    else if (temp <= 30)
                        Console.WriteLine("Normal in Temperature");
                    else if (temp <= 40)
                        Console.WriteLine("Hot");
                    else
                        Console.WriteLine("Very Hot");
                    break;

                case "Calculator":
                    Console.WriteLine(" create calculator using switch...case");
                    Console.WriteLine("---------------------------------------------");
                    float number1;
                    float number2;
                    string operand;
                    float answer;
                    Console.Write("Please enter the first integer: ");
                    number1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Please enter an operand (+, -, /, *): ");
                    operand = Console.ReadLine();

                    Console.Write("Please enter the second integer: ");
                    number2 = Convert.ToInt32(Console.ReadLine());

                    switch (operand)
                    {

                        case "+":
                            answer = number1 + number2;
                            Console.WriteLine(number1 + " " + operand + " " + number2 + " = " + answer);
                            Console.ReadLine();
                            break;

                        case "-":
                            answer = number1 - number2;
                            Console.WriteLine(number1 + " " + operand + " " + number2 + " = " + answer);
                            Console.ReadLine();
                            break;

                        case "*":
                            answer = number1 * number2;
                            Console.WriteLine(number1 + " " + operand + " " + number2 + " = " + answer);
                            Console.ReadLine();
                            break;

                        case "/":
                            answer = number1 / number2;
                            Console.WriteLine(number1 + " " + operand + " " + number2 + " = " + answer);
                            Console.ReadLine();
                            break;

                        default:
                            answer = 0;
                            Console.WriteLine("Only (+, -, /, *) Operand Allowed",answer);
                            break;
                    }
                  
                    break;

                    default:
                    Console.WriteLine("Sorry!! This Type of Task is Not Allocated");
                    break;
            }
        
        }  
    }
}

