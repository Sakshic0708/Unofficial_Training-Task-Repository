using System;

namespace Day2_OfficeManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.ViewSchedule();
            employee.ViewCompanyAnnounceMent();
            employee.UpdatePersonalInfo();
         

            Manager manager = new Manager();
            manager.AssignTask();
            manager.ViewSchedule();

            //in meeting we have to use Employee's method
            Meeting meeting = new Meeting();
            meeting.UpdatePersonalInfo();
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public long PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public DateTime HireDte { get; set; }
        public int Salary { get; set; }

        public void ViewSchedule()
        {

        }
        public void ViewCompanyAnnounceMent()
        {

        }
        public void UpdatePersonalInfo()
        {

        }
    }

    public class Manager : Employee
    {
        public int ManagerId { get; set; }

        public void AssignTask()
        {

        }
        public void ViewTeamSchedule()
        {

        }
        public void ViewTeamPerformance()
        {

        }
    }

    public class Department
    {
        public int DepartmentId { get; private set; }
        public string DepartmentName { get; set; }
        public string DepartmentHead { get; set; }

        public void ViewDepartmentBudget()
        {

        }
    }

    public class Meeting : Employee
    {
        public int MeetingId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public void ScheduleMeeting()
        {

        }
        public void CancelMeeting()
        {

        }
        public void InviteAttendes()
        {

        }
    }

    public class Task : Employee
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public string AssignedTo { get; set; }
        public string Status { get; set; }

        public void AssignTask()
        {

        }
        public void ViewTaskDetails()
        {

        }
    }
}
