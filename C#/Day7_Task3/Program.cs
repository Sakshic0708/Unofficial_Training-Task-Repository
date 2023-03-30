using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day7_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            admission.Admission();
        }
    }
    public class admission
    {
        private static object id;

        public static void Admission()
        {

            Hashtable newAdmission = new Hashtable();
            bool flag;
            do
            {
                Console.WriteLine("Enter Student Details:-");

                ArrayList studentList = new ArrayList();
                {
                    Console.WriteLine("Enter Name");
                    var name = studentList.Add(Console.ReadLine());

                    Console.WriteLine("Enter ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    newAdmission.Add(id, studentList);

                    Console.WriteLine("Enter Phone Number");
                    studentList.Add(Convert.ToInt64(Console.ReadLine()));

                    Console.WriteLine("Enter Age");
                    int age = Convert.ToInt32(Console.ReadLine());
                    studentList.Add(age);

                    Console.WriteLine("To Continue Press Y");
                    Console.WriteLine("To Exit Press N");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        flag = true;
                    }
                    else if (Console.ReadLine().ToUpper() == "N")
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            while (flag);

            foreach (DictionaryEntry show in newAdmission)
            {
                ArrayList studentList = (ArrayList)show.Value;

                Console.WriteLine("Name is:" + studentList[0]);
                Console.WriteLine("Phone Number is:" + studentList[1]);
                Console.WriteLine("Age is:" + studentList[2]);
                Console.WriteLine("\n");
            }

            Console.WriteLine("Total Elements: {0}", newAdmission.Count);

            Console.WriteLine("Enter a Id Which You have Removing:-");
            int RemoveId = Convert.ToInt32(Console.ReadLine());

            newAdmission.Remove(RemoveId);
  
            Console.WriteLine("After Removing an Elements: {0}", newAdmission.Count);
            foreach (DictionaryEntry show in newAdmission)
            {
                ArrayList studentList = (ArrayList)show.Value;

                Console.WriteLine("Name is:" + studentList[0]);
                Console.WriteLine("Phone Number is:" + studentList[1]);
                Console.WriteLine("Age is:" + studentList[2]);
                Console.WriteLine("\n");
           
            }
            foreach (DictionaryEntry show in newAdmission)
            {
                ArrayList studentList = (ArrayList)show.Value;

                Console.WriteLine("Best Award Goes To:-");
                string awardname = Console.ReadLine();
                Console.WriteLine("Best Award Goes to:-" +  awardname);

            }
           
        }

    }

}
