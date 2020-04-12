using System;
using System.Linq;
using Challenge4App;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge4Tests
{
    [TestClass]
    public class UnitTest1
    {

        CustomerRepository repo = new CustomerRepository();

        [TestMethod]
        public void CustomerTests()
        {
            Customer newCustomer = new Customer();
            newCustomer.FirstName = "Sam";
            newCustomer.LastName = "Spade";
            newCustomer.Type = Customer.CustomerType.Current;

            repo.AddCustomerToDirectory(newCustomer);

            Console.WriteLine($"This customer's full name is {newCustomer.FullName}." +
                $"Customer's type is {newCustomer.Type}." );


        }

        [TestMethod]
        public void AddCustomerToRepo_GetCorrectBool()
        {
            Customer cust1 = new Customer();
            cust1.FirstName = "Bill";
            cust1.LastName = "Brasky";
            bool wasAdded = repo.AddCustomerToDirectory(cust1);

            
            Assert.AreEqual(wasAdded, true);
        }

        [TestMethod]
        public void RemoveCustomerFromRepo_GetCorrectBool()
        {
            Customer myCustomer = new Customer();
            myCustomer.FirstName = "Tom";
            myCustomer.LastName = "Hammersly";
            repo.AddCustomerToDirectory(myCustomer);


            bool wasRemoved = repo.RemoveCustomerByFullName("Tom Hammersly");

            Assert.AreEqual(wasRemoved, true);
        }

        [TestMethod]
        public void UpdateExistingCustomer_GetCorrectBool()
        {
            Customer newPerson = new Customer();
            newPerson.FirstName = "First";
            newPerson.LastName = "Last";
            repo.AddCustomerToDirectory(newPerson);

            Customer update = new Customer();
            update.FirstName = "Mindy";
            update.LastName = "Lewis";

            bool wasUpdated = repo.UpdateExistingCustomer("First Last", update);
            Assert.AreEqual(wasUpdated, true);

        }

        [TestMethod]
        public void GetCustomersTest_CheckingCountOnList()
        {
            Customer me = new Customer();
            me.FirstName = "Allen";
            me.LastName = "Brisby";
            repo.AddCustomerToDirectory(me);

            int actual = repo.GetCustomers().Count();
            int expected = 1;

            Assert.AreEqual(actual, expected);
        }
    }
}
