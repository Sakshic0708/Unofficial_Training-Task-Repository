using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_MatrimonialSystem_Shaadi.com_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Partners partners = new Partners();
            partners.SearchPartner();

            Photograph photograph = new Photograph();
            photograph.savePartner();

        }
    }
    public class Partners
    {
        public int partnerId { get; set; }
        public string partnerName { get; set; }
        public long partnerMobile { get; set; }
        public string partnerEmail { get; set; }
        public string partnerAddress { get; set; }

        public void SearchPartner() { }
        public void savePartner() { }
    }

    class Registration
    {
        private int registrationId { get; set; }
        private string registrationName { get; set; }
        private string registrationType { get; set; }

        private void AddRegistration() { }
        private void EditRegistration() { }
    }

    public class ContactProfile : Partners
    {
        public int contactId { get; set; }
        public int contactName { get; set; }

        public void SaveContantProfile() { }
        public void DeleteContantProfile() { }
    }
    public class Photograph : Partners
    {
        public int photographId { get; set; }
        public int photographName { get; set; }

        public void AddPhotograph() { }
        public void SavePhotograph() { }

    }
}
