using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4App
{
    public class CustomerRepository
    {
        public List<Customer> _customerList = new List<Customer>();
        public Dictionary<string, string> _emails = new Dictionary<string, string>()
        {
            {"Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon." },
            {"Potential", "We currently have the lowest rates on Helicopter Insurance!" },
            {"Past", "It's been a long time since we've heard from you, we want you back." }
        };

        public bool AddCustomerToDirectory(Customer newCustomer)
        {
            int startingCount = _customerList.Count;
            // could add a looping test here that looks for specific titles, and if a new title matches an existing title, skips it and returns a false check.

            _customerList.Add(newCustomer);

            bool wasAdded = (_customerList.Count > startingCount); // should be "true" if something was successfully added to list

            return wasAdded;
        }

        public bool RemoveCustomerByFullName(string name)
        {
            int startingCount = _customerList.Count;
            int index = -1;
            foreach (Customer customer in _customerList)
            {
                if (customer.FullName == name)
                {
                    index = _customerList.IndexOf(customer);
                    // if int index was declared here first, couldn't use it outside of the {}. 
                    // Can never return a negative, since IndexOf will always start at 0.
                }
            }
            if (index != -1)
            {
                _customerList.RemoveAt(index);
            }

            bool wasRemoved = (_customerList.Count < startingCount);
            return wasRemoved;

        }

        public Customer GetCustomerByFullName(string name)
        {
            foreach (Customer customer in _customerList)
            {
                if (customer.FullName == name)
                {
                    return customer;
                }
            }

            return null;
        }

        public bool UpdateExistingCustomer(string name, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByFullName(name);
            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Type = newCustomer.Type;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customer> GetCustomers()
        {
            return _customerList;
        }

        public string GetCustomerEmailByType(string type)
        {
            //Version 1a

            foreach (KeyValuePair<string, string> emailtype in _emails)
            {
                if(emailtype.Key.ToString() == type)
                {
                    return emailtype.Value;
                }
            }
            return null;

        }
        
    }
}
