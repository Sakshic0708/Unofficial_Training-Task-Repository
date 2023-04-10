using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exam_EmployeeMasterData
{
    internal class Program
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
                    AddEmployee();
                }
                else if (input == "2")
                {
                    DeleteEmployee();
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
        private static void AddEmployee()
        {
            Console.WriteLine("\nPlease enter employee details:");

            // Collect input
            Console.Write("Employee ID: ");
            string employeeId = Console.ReadLine();
            if (IsDuplicateEmployee(employeeId))
            {
                Console.WriteLine($"Employee ID '{employeeId}' already exists. Please try again with a different ID.");
                return;
            }

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Date of Birth (YYYY-MM-DD): ");
            string dobInput = Console.ReadLine();
            if (!DateTime.TryParse(dobInput, out DateTime dob))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                return;
            }

            Console.Write("Gender (F or M): ");
            string genderInput = Console.ReadLine();
            if (!Enum.TryParse<Gender>(genderInput, true, out Gender gender))
            {
                Console.WriteLine("Invalid gender. Please try again.");
                return;
            }

            Console.Write("Designation: ");
            string designation = Console.ReadLine();

            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("State: ");
            string state = Console.ReadLine();

            Console.Write("Postcode: ");
            string postcode = Console.ReadLine();

            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Date of Joining (YYYY-MM-DD): ");
            string dojInput = Console.ReadLine();
            if (!DateTime.TryParse(dojInput, out DateTime doj))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                return;
            }

            Console.Write("Total Experience (in years): ");
            string totalExpInput = Console.ReadLine();
            if (!int.TryParse(totalExpInput, out int totalExp))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.Write("Remarks: ");
            string remarks = Console.ReadLine();

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

            // Calculate total experience
            int expInYears = (DateTime.Now - doj).Days / 365;

            // Create new employee object
            Employee newEmployee = new Employee
            {
                EmployeeId = employeeId,
                Name = name,
                Dob = dob,
                Gender = gender,
                Designation = designation,
                City = city,
                State = state,
                Postcode = postcode,
                Phone = phone,
                Email = email,
                DateOfJoining = doj,
                TotalExperience = expInYears,
                Remarks = remarks,
                Department = department,
                MonthlySalary = salary
            };

            // Add employee to JSON file
            List<Employee> employees = GetAllEmployees();
            employees.Add(newEmployee);
            SaveAllEmployees(employees);

            Console.WriteLine("\nEmployee added successfully!");
        }

        private static bool IsDuplicateEmployee(string employeeId)
        {
            List<Employee> employees = GetAllEmployees();
            return employees.Any(e => e.EmployeeId == employeeId);
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

        class Employee
        {
            public string EmployeeId { get; set; }
            public string Name { get; set; }
            public DateTime Dob { get; set; }
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
        }
    }


}

    //    public class Employee
    //    {
    //        enum department
    //        {
    //            Sales,
    //            Marketing,
    //            Development,
    //            QA,
    //            HR,
    //            SEO
    //        }
    //        public string Name { get; set; }
    //        public DateTime Dob { get; set; }

    //        public string Gender { get; set; }
    //        public string Designation { get; set; }
    //        public string City { get; set; }
    //        public string State { get; set; }
    //        public string PostCode { get; set; }
    //        public string Mobile { get; set; }
    //        public string Email { get; set; }
    //        public DateTime DateOfJoining { get; set; }
    //        public int Experience { get; set; }
    //        public string Remarks { get; set; }
    //        public string Department { get; set; }
    //        public int Salary { get; set; }
    //        public static string GetTenDigitRandomNumbers()
    //        {
    //            Random generator = new Random();
    //            return generator.Next(0, 10000).ToString("D6");
    //        }

    //        private bool NameFormate(string s)
    //        {
    //            Regex regex = new Regex(@"^[A-Z][a-zA-Z\s]*$");
    //            return regex.IsMatch(s);
    //        }
    //        private bool CityState(string s)
    //        {
    //            Regex regex = new Regex(@"^[a-zA-Z]*$");
    //            return regex.IsMatch(s);
    //        }
    //        private bool ZipCode(string s)
    //        {
    //            Regex regex = new Regex(@"^[0-9]{6}$");
    //            return regex.IsMatch(s);
    //        }
    //        private bool MobileFormate(string s)
    //        {
    //            Regex regex = new Regex(@"^[0-9]{10}$");
    //            return regex.IsMatch(s);
    //        }
    //        private bool IsValidEmailAddress(string s)
    //        {
    //            Regex regex = new Regex(@"^([a-zA-Z0-9]+[a-zA-Z0-9\.]*[a-zA-Z0-9]+)@(gmail)\.(com)$");
    //            return regex.IsMatch(s);
    //        }
    //        public override string ToString()
    //        {
    //            return $"Name: {Name},Dob: {Dob},Gender: {Gender},Designation: {Designation},City: {City},State: {State},PostCode: {PostCode},Mobile: {Mobile}, Email: {Email},DateOfJoining: {DateOfJoining},Experience: {Experience}, Remarks:{Remarks},Department:{Department},Salary:{Salary}";
    //        }

    //        public void AddEmployee()
    //        {
    //            bool flag;

    //            do

    //            {
    //                Console.WriteLine("Enter Employee Details:-");
    //                Console.WriteLine("Employee Id:-" + GetTenDigitRandomNumbers());
    //                do
    //                {
    //                    Console.Write("Enter First Name:-");
    //                    Name = Console.ReadLine();
    //                }
    //                while (!NameFormate(Name) || string.IsNullOrEmpty(Name));

    //                Console.Write("Enter your date of birth (dd/mm/yyyy): ");
    //                DateTime Dob = Convert.ToDateTime(Console.ReadLine());

    //                do
    //                {
    //                    Console.Write("Enter Gender:-");
    //                    Gender = Console.ReadLine();
    //                    if (!string.IsNullOrEmpty(Gender))
    //                    {
    //                        if (Gender.ToLower() == "m")
    //                        {
    //                            Console.WriteLine("Male");
    //                        }
    //                        else if (Gender.ToLower() == "f")
    //                        {
    //                            Console.WriteLine("Female");
    //                        }
    //                        else if (Gender != "m" && Gender != "f")
    //                        {
    //                            Console.WriteLine("Only Male Or Female Are Allowed");
    //                        }

    //                    }
    //                }
    //                while (string.IsNullOrEmpty(Gender) || (Gender != "m" && Gender != "f"));

    //                do
    //                {
    //                    Console.Write("Enter Designation:-");
    //                    Designation = Console.ReadLine();
    //                }
    //                while (!NameFormate(Designation) || string.IsNullOrEmpty(Designation));

    //                do
    //                {
    //                    Console.Write("Enter Your City:-");
    //                    City = Console.ReadLine();
    //                }
    //                while (!CityState(City) || string.IsNullOrEmpty(City));

    //                do
    //                {
    //                    Console.Write("Enter Your State:-");
    //                    State = Console.ReadLine();
    //                }
    //                while (!CityState(State) || string.IsNullOrEmpty(State));

    //                do
    //                {
    //                    Console.Write("Enter Your PostCode:-");
    //                    PostCode = Console.ReadLine();
    //                }
    //                while (!ZipCode(PostCode) || string.IsNullOrEmpty(PostCode));

    //                do
    //                {
    //                    Console.Write("Enter Your Mobile Number:-");
    //                    Mobile = Console.ReadLine();
    //                }
    //                while (!MobileFormate(Mobile) || string.IsNullOrEmpty(Mobile));

    //                do
    //                {
    //                    Console.Write("Enter Your Email:-");
    //                    Email = Console.ReadLine();
    //                }
    //                while (!IsValidEmailAddress(Email) || string.IsNullOrEmpty(Email));

    //                Console.Write("Enter your Joining Date(dd/mm/yyyy): ");
    //                DateTime DateOfJoining = Convert.ToDateTime(Console.ReadLine());

                   
    //                Console.Write("Enter Your Experience:-");
    //                Experience = Convert.ToInt32(Console.ReadLine());

    //                do
    //                {
    //                    Console.Write("Enter Remarks:-");
    //                    Remarks = Console.ReadLine();
    //                }
    //                while (string.IsNullOrEmpty(Remarks));

    //                do
    //                {
    //                    Console.WriteLine("Department:-");
    //                    Console.WriteLine("What Department what You Choose:- Type 1-6 Any Number");

    //                    Department = Console.ReadLine();
    //                    try
    //                    {
    //                        department finalDesignation = (department)Convert.ToInt32(Department);
    //                        Console.WriteLine(finalDesignation);
    //                    }
    //                    catch (FormatException)
    //                    {
    //                        Console.WriteLine("Enter Valid Number");
    //                        continue;
    //                    }
    //                }
    //                while (string.IsNullOrEmpty(Department));

    //                Console.Write("Enter Monthly Salary:-");
    //                Salary = Convert.ToInt32(Console.ReadLine());

    //                Console.WriteLine("Add more employees? (Y/N): ");
    //                if (Console.ReadLine().ToUpper() == "Y")
    //                {
    //                    flag = true;
    //                }
    //                else if (Console.ReadLine().ToUpper() == "N")
    //                {
    //                    flag = false;
    //                }
    //                else
    //                {
    //                    flag = false;
    //                }
    //            }
    //            while (flag);
    //        }


    //    }
    //}
