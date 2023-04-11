using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
                    Employee employee = new Employee();
                    employee.DeleteEmployee();
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
        public class Employee
        {

            public int EmployeeId { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string Designation { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public DateTime DateOfJoining { get; set; }
            public int TotalExperience { get; set; }
            public string Remarks { get; set; }
            public string Department { get; set; }
            public double MonthlySalary { get; set; }

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

                Console.WriteLine("\nPlease enter employee details:");

               // Console.Write("Employee Id:-");
               // int EmployeeId = Convert.ToInt32(Console.ReadLine());

                bool isvoid = false;
                while(!isvoid)
                {
                    try
                    {
                        Console.Write("Enter the ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        if (DuplicateID(id)) 
                        {
                            Console.WriteLine("");

                        }
                        else
                        {
                            isvoid = true;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Duplicate Id");

                    }
                } 


                string Name;
                do
                {
                    Console.Write("Enter Your Name: ");
                    Name = Console.ReadLine();
                    if (!isValidName(Name))
                    {
                        Console.WriteLine("Only Alphabets Allowed.");
                    }
                }
                while (!isValidName(Name));

                while (true)
                {
                    try
                    {
                        Console.Write("Enter Date of Birth (dd-MMMM-yyyy): ");
                        string input = Console.ReadLine();
                        DateTime userDate = DateTime.ParseExact(input, "dd-mm-yyyy", CultureInfo.InvariantCulture); // Read and parse user input date in specified format
                        string formattedDate = userDate.ToString("dd-MMMM-yyyy"); // Format user input date

                        Console.WriteLine("Formatted Date: " + formattedDate); // Output formatted date
                        break; // Exit loop if date is valid
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Date Format. Please enter date in the format (dd-MMMM-yyyy).");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Date of Birth. Please try again.");
                    }
                }


                string UserInputGender;
                do
                {
                    Console.WriteLine("Choose Gender - \nEnter F for Female\nEnter M for Male");
                    UserInputGender = Console.ReadLine().ToUpper();
                    switch (UserInputGender)
                    {
                        case "F":
                            Gender = GenderEnum.F.ToString();
                            Console.WriteLine("Gender Selected - " + Gender);
                            break;
                        case "M":
                            Gender = GenderEnum.M.ToString();
                            Console.WriteLine("Gender Selected - " + Gender);
                            break;
                    }

                }
                while (string.IsNullOrEmpty(UserInputGender) || (UserInputGender != "F" && UserInputGender != "M"));


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


                string City;
                do
                {
                    Console.Write("Enter City: ");
                    City = Console.ReadLine();
                    if (!isValidName(City))
                    {
                        Console.WriteLine("Only Alphabets Allowed.");
                    }
                } while (!isValidName(City));

                string State;
                do
                {
                    Console.Write("Enter State: ");
                    State = Console.ReadLine();
                    if (!isValidName(State))
                    {
                        Console.WriteLine("Only Alphabets Allowed.");
                    }
                } while (!isValidName(State));

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

                TimeSpan experienceTimeSpan = DateTime.Now - DateOfJoining;
                int totalExperienceInYears = experienceTimeSpan.Days / 365;
                int totalExperienceInMonths = (experienceTimeSpan.Days % 365) / 30;
                int totalExperienceInDays = (experienceTimeSpan.Days % 365) % 30;

                Console.WriteLine($"Total Experience: {totalExperienceInYears} years, {totalExperienceInMonths} months, and {totalExperienceInDays} days.");

                Console.Write("Remarks: ");
                string Remarks = Console.ReadLine();

               
                while (true)
                {
                    Console.Write("Department (1=Sales, 2=Marketing, 3=Development, 4=QA, 5=HR, 6=SEO): ");
                    int departmentInput = Convert.ToInt32(Console.ReadLine());
                    switch (departmentInput)
                    {
                        case 1:
                            Department = Convert.ToString(Departmentenum.Sales);
                            break;
                        case 2:
                            Department = Convert.ToString(Departmentenum.Marketing);
                            break;
                        case 3:
                            Department = Convert.ToString(Departmentenum.Development);
                            break;
                        case 4:
                            Department = Convert.ToString(Departmentenum.QA);
                            break;
                        case 5:
                            Department = Convert.ToString(Departmentenum.HR);
                            break;
                        case 6:
                            Department = Convert.ToString(Departmentenum.SEO);
                            break;
                        default:
                            Console.WriteLine("Invalid Operation");
                            break;
                    }
                    break;
                }

                do
                {
                    Console.WriteLine("Enter Your Salary:");
                    string salary = Console.ReadLine();

                    try
                    {
                        MonthlySalary = Convert.ToDouble(salary);

                        if (MonthlySalary < 10000 || MonthlySalary > 1000000)
                        {
                            Console.WriteLine("Salary must be between 10000 and 1000000.");
                            continue;
                        }
                      
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid Salary Input.");
                        continue;
                    }
                }
                while (true);


                List<Employee> employeesFromFile;
                string jsonFromFile;
                string Myfile = ConfigurationManager.AppSettings["FilePath"];

                // check if the file exists and read its contents
                if (File.Exists(Myfile))
                {
                    jsonFromFile = File.ReadAllText(Myfile);

                    if (!string.IsNullOrEmpty(jsonFromFile))
                    {
                        if (jsonFromFile.StartsWith("["))
                        {
                            employeesFromFile = JsonConvert.DeserializeObject<List<Employee>>(jsonFromFile);
                        }
                        else
                        {
                            Employee singleEmployee = JsonConvert.DeserializeObject<Employee>(jsonFromFile);
                            employeesFromFile = new List<Employee> { singleEmployee };
                        }
                    }
                    else
                    {
                        employeesFromFile = new List<Employee>();
                    }
                }
                else
                {
                    employeesFromFile = new List<Employee>();
                }

                // create a new Employee object
                Employee newEmployee = new Employee
                {
                    EmployeeId = EmployeeId,
                    Name = Name,
                    DateOfBirth = DateOfBirth,
                    Gender = Gender,
                    Designation = Designation,
                    City = City,
                    State = State,
                    Postcode = Postcode,
                    Phone = Phone,
                    Email = Email,
                    DateOfJoining = DateOfJoining,
                    TotalExperience = totalExperienceInYears,
                    Remarks = Remarks,
                    Department = Department,
                    MonthlySalary = MonthlySalary
                };
                employeesFromFile.Add(newEmployee);

                if (employeesFromFile.Count > 1)
                {
                    var sortedEmployees = employeesFromFile.OrderByDescending(e => e.MonthlySalary);
                    employeesFromFile = sortedEmployees.ToList();
                }

                string json = JsonConvert.SerializeObject(employeesFromFile, Formatting.Indented);

                File.WriteAllText(Myfile, json);

            }

            public static bool DuplicateID(int id)
            {

                
                string filePath = ConfigurationManager.AppSettings["FilePath"];
                List<Employee> employeesFromFile = new List<Employee>();

                try
                {
                    string jsonString = File.ReadAllText(filePath);
                    employeesFromFile = JsonConvert.DeserializeObject<List<Employee>>(jsonString);

                    // Check if the ID already exists in the list
                    bool idExists = employeesFromFile.Any(e => e.EmployeeId == id);
                    if (idExists)
                    {
                        Console.WriteLine("Duplicate ID: this ID is already assigned to another employee.");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }
                catch
                {
                    Console.WriteLine("Error reading employee data from file.");
                    return false;

                }
            }
            public void DeleteEmployee()
            {
                Console.Write("Enter the ID of the employee to be deleted: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string filePath = ConfigurationManager.AppSettings["FilePath"];
                List<Employee> employeesList = new List<Employee>();

                try
                {
                    if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
                    {
                        string jsonString = File.ReadAllText(filePath);
                        employeesList = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }

                Employee employeeToDelete = employeesList.SingleOrDefault(x => x.EmployeeId == id);

                if (employeeToDelete != null)
                {
                    employeesList.Remove(employeeToDelete);

                    try
                    {
                        string jsonConvert = JsonConvert.SerializeObject(employeesList);
                        File.WriteAllText(filePath, jsonConvert);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error writing file: {ex.Message}");
                    }

                    Console.WriteLine($"Employee with ID {id} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Employee with ID {id} was not found.");
                }
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

    }

    enum GenderEnum
    {
        F,
        M
    }

    public enum Departmentenum
    {
        Sales,
        Marketing,
        Development,
        QA,
        HR,
        SEO
    }
    public static class DateExtensions
    {
        public static string DateFormateExt(this DateTime date, string format)
        {
            return date.ToString(format);
        }
    }

}


