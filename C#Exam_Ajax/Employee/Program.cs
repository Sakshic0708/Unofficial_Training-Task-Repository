using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EmployeeManagement
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee Management System!");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Delete employee");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();
                if (input == "1")
                {
                   Employee employee = new Employee();
                    employee.AddEmployee();
                }
                else if (input == "2")
                {
                }
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            Console.WriteLine("Thank you for using Employee Management System!");
        }
        class Employee
        {
            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Gender Gender { get; set; }
            public string Designation { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public DateTime DateOfJoining { get; set; }
            public int TotalExperience { get; set; }
            public string Remarks { get; set; }
            public Department Department { get; set; }
            public decimal MonthlySalary { get; set; }
            public override string ToString()
            {
                return $"EmployeeId:{EmployeeId},Name: {Name},DateOfBirth: {DateOfBirth},Gender: {Gender},Designation: {Designation},City: {City},State: {State},PostCode: {Postcode},Phone: {Phone}, Email: {Email},DateOfJoining: {DateOfJoining},TotalExperience: {TotalExperience}, Remarks:{Remarks},Department:{Department},MonthlySalary:{MonthlySalary}";
            }
            private bool ZipCode(string s)
            {
                Regex regex = new Regex(@"^[0-9]{6}$");
                return regex.IsMatch(s);
            }
            private bool MobileFormate(string s)
            {
                Regex regex = new Regex(@"^[0-9]{10}$");
                return regex.IsMatch(s);
            }

            public void AddEmployee()
            {
                List<Employee> employees = new List<Employee>();
                Console.WriteLine("\nPlease enter employee details:");

                Console.Write("Employee Id:-");
                int EmployeeId = Convert.ToInt32(Console.ReadLine());

                string Name;
                do
                {
                    Console.Write("Enter Your Name: ");
                    Name = Console.ReadLine();
                    if (!isValidName(Name))
                    {
                        Console.WriteLine("Only Alphabets Allowed.");
                    }
                } while (!isValidName(Name));

                Console.Write("Enter your date of birth: ");
                DateTime DateOfBirth = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Gender (F or M): ");
                string genderInput = Console.ReadLine();
                if (!Enum.TryParse<Gender>(genderInput, true, out Gender gender))
                {
                    Console.WriteLine("Invalid gender. Please try again.");
                    return;
                }

                string Designation;
                do
                {
                    Console.Write("Enter designation: ");
                    Designation = Console.ReadLine();
                    if (!isValidName(Designation))
                    {
                        Console.WriteLine("Only Alphabets Allowed.");
                    }
                } while (!isValidName(Designation));

                Console.Write("City: ");
                string City = Console.ReadLine();

                Console.Write("State: ");
                string State = Console.ReadLine();

                do
                {
                    Console.Write("Enter Your PostCode:-");
                    Postcode = Console.ReadLine();
                }
                while (!ZipCode(Postcode) || string.IsNullOrEmpty(Postcode));
                do
                {
                    Console.Write("Enter Your Mobile Number:-");
                    Phone = Console.ReadLine();
                }
                while (!MobileFormate(Phone) || string.IsNullOrEmpty(Phone));

                string Email;
                do
                {
                    Console.Write("Email: ");
                    Email = Console.ReadLine();
                    if (!IsValidEmail(Email))
                    {
                        Console.WriteLine("Invalid email. Please try again.");
                    }
                } while (!IsValidEmail(Email));

                Console.Write("Date of Joining: ");
                string dojInput = Console.ReadLine();
                if (!DateTime.TryParse(dojInput, out DateTime DateOfJoining))
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                    return;
                }

                Console.Write("Total Experience (in years): ");
                int experienceInYears = (DateTime.Now - DateOfJoining).Days / 365;
                Console.WriteLine(experienceInYears);

                Console.Write("Remarks: ");
                string Remarks = Console.ReadLine();

                Console.Write("Department (1=Sales, 2=Marketing, 3=Development, 4=QA, 5=HR, 6=SEO): ");
                string departmentInput = Console.ReadLine();
                if (!Enum.TryParse<Department>(departmentInput, out Department department))
                {
                    Console.WriteLine("Invalid department. Please try again.");
                    return;
                }

                Console.Write("Monthly Salary: ");
                string salaryInput = Console.ReadLine();
                if (!decimal.TryParse(salaryInput, out decimal salary))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    return;
                }



                string jsonFromFile = File.ReadAllText("Employee_10-04-2023.json");

                // Deserialize JSON data into list of Employee objects
                List<Employee> employeesFromFile = JsonConvert.DeserializeObject<List<Employee>>(jsonFromFile);

                Employee newEmployee = new Employee
                {
                    EmployeeId = EmployeeId,
                    Name = Name,
                    DateOfBirth = DateOfBirth,
                    Gender = gender,
                    Designation = Designation,
                    City = City,
                    State = State,
                    Postcode = Postcode,
                    Phone = Phone,
                    Email = Email,
                    DateOfJoining = DateOfJoining,
                    TotalExperience = experienceInYears,
                    Remarks = Remarks,
                    Department = department,
                    MonthlySalary = salary
                };
                employees.Add(newEmployee);

                employeesFromFile.Add(newEmployee);

                string json = JsonConvert.SerializeObject(employeesFromFile, Formatting.Indented);

                File.WriteAllText("Employee_10-04-2023.json", json);


            }
            
        }
       


        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                var regex = new Regex(@"^([a-zA-Z0-9]+[a-zA-Z0-9\.]*[a-zA-Z0-9]+)@(gmail)\.(com)$");
                return regex.IsMatch(email);
            }
            catch (FormatException)
            {
                return false;
            }
        }
        static bool isValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            try
            {
                var regex = new Regex(@"^[a-zA-Z\s]*$");
                return regex.IsMatch(name);
            }
            catch (FormatException)
            {
                return false;
            }
        }
       


        enum Gender
        {
            F,
            M
        }

        enum Department
        {
            Sales = 1,
            Marketing,
            Development,
            QA,
            HR,
            SEO
        }

       
    }
}

