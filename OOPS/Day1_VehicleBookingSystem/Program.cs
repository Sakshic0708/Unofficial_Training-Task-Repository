
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_VehicleBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            user.register();

            var loggeduser = new User();
            loggeduser.Login();

        }
    }
    public class User
    {
        public void register()
        {

        }
        public void Login()
        {

        }
    }
    public class newCustomer
    {
        public int id;
        public string name;
        public DateTime dob;
        public long Mobileno;
        public void Add()
        {

        }
        public void Show()
        {

        }
    }

    public class RegisteredUser
    {
        public int id;
        public void show()
        {

        }
        public void Update()
        {

        }
        public void edit()
        {

        }
    }

    public class SearchCab
    {
        public int Cabid;
        public string CabType;
        public string CabModel;

        public void select()
        {

        }
        public void showCab()
        {

        }
    }

    public class Booking
    {
        public int bookingid;
        public string pickUpCity;
        public string location;
        public string destinationCity;
        public string dropLocation;
        public driverinfo driverinfo { get; set; }

        public void ShowBooking()
        {

        }
        public void AddBooking()
        {

        }
        public void UpdateBooking()
        {

        }
    }
    public class driverinfo
    {
        public string name;
        public string description;
    }

    public class Payment
    {
        public int Paymentid;
        public int charges;

        public void ShowPayment()
        {

        }
        public void pay()
        {

        }
    }
}
