using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4App
{
    
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = $"{FirstName} {LastName}";

                return fullName;
            }
        }
        public enum CustomerType { Current = 1, Potential, Past, Unknown}
        public CustomerType Type { get; set; }
        //public List<string> Emails = new List<string>
        //{
        //    "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.",
        //    "We currently have the lowest rates on Helicopter Insurance!",
        //    "It's been a long time since we've heard from you, we want you back."
        //};

        //public Dictionary<string, string> Emails = new Dictionary<string, string>
        //{
        //    { "Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon." },
        //    { "Potential", "We currently have the lowest rates on Helicopter Insurance!" },
        //    { "Past", "It's been a long time since we've heard from you, we want you back." }
            
        //};

        public Customer() { }

        public Customer(string firstName, string lastName, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }


    }
    
}
