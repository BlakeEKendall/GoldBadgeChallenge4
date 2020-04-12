using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge4App.Customer;

namespace Challenge4App
{
    public class ProgramUI
    {
        private readonly CustomerRepository _repo = new CustomerRepository();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        private void SeedMenu()
        {
            Customer billF = new Customer(
                "Bill",
                "Foster",
                Customer.CustomerType.Past);
            Customer sarahM = new Customer(
                "Sarah",
                "Montgomery",
                Customer.CustomerType.Current);
            Customer lukeS = new Customer(
                "Luke",
                "Skywalker",
                Customer.CustomerType.Past);
            Customer vicF = new Customer(
                "Victor",
                "Fries",
                Customer.CustomerType.Potential);
            Customer abbyN = new Customer(
                "Abigail",
                "Normal",
                Customer.CustomerType.Current);

            _repo.AddCustomerToDirectory(billF);
            _repo.AddCustomerToDirectory(sarahM);
            _repo.AddCustomerToDirectory(lukeS);
            _repo.AddCustomerToDirectory(vicF);
            _repo.AddCustomerToDirectory(abbyN);


        }

        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome Administrator to your Komodo Insurance customer directory!\n" +
                    "Please enter the number of the option you'd like to select:\n" +
                    "1. Create new customer\n" +
                    "2. Read all customers\n" +
                    "3. Update existing customer\n" +
                    "4. Delete customer\n" +
                    "5. Show all customers in Order\n" +
                    "6. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateNewCustomer();
                        break;
                    case "2":
                        ReadAllCustomers();
                        break;
                    case "3":
                        UpdateACustomer();
                        break;
                    case "4":
                        DeleteACustomer();
                        break;
                    case "5":
                        GetAlphabeticalCustomerList();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }

            }

        }

        public void CreateNewCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter customer's first name:");
            string name1 = Console.ReadLine();
            Console.WriteLine("\nEnter customer's last name:");
            string name2 = Console.ReadLine();
            
            Console.WriteLine("\nChoose an option for customer's type:\n" +
                "1. Current\n" +
                "2. Potential\n" +
                "3. Past");
            string typeChoice = Console.ReadLine();
            CustomerType type;

            switch (typeChoice)
            {
                case "1":
                    type = CustomerType.Current;
                    break;
                case "2":
                    type = CustomerType.Potential;
                    break;
                case "3":
                    type = CustomerType.Past;
                    break;
                default:
                    type = CustomerType.Unknown;
                    break;
            }

            Customer newCustomer = new Customer(name1, name2, type);

            bool itemWasAdded = _repo.AddCustomerToDirectory(newCustomer);
            if (itemWasAdded)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void ReadAllCustomers()
        {
            Console.Clear();

            List<Customer> cList = _repo.GetCustomers();

            Console.WriteLine("FirstName |   LastName   |  Type   |   Email  ");
            foreach (Customer customer in cList)
            {
                string eValue = _repo.GetCustomerEmailByType(customer.Type.ToString());
                Console.WriteLine($"{customer.FirstName,-12} {customer.LastName,-13} {customer.Type,-12} {eValue,-10}");

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void UpdateACustomer()
        {
            Console.WriteLine("What is the full name of the customer to be updated?");
            string oldName = Console.ReadLine();
            Console.WriteLine("Enter the customer's new first name:");
            string new1 = Console.ReadLine();
            Console.WriteLine("Enter the customer's new last name:");
            string new2 = Console.ReadLine();
            Console.WriteLine("\nChoose a new option for customer's type:\n" +
                "1. Current\n" +
                "2. Potential\n" +
                "3. Past");
            string typeChoice = Console.ReadLine();
            CustomerType newType;

            switch (typeChoice)
            {
                case "1":
                    newType = CustomerType.Current;
                    break;
                case "2":
                    newType = CustomerType.Potential;
                    break;
                case "3":
                    newType = CustomerType.Past;
                    break;
                default:
                    newType = CustomerType.Unknown;
                    break;
            }

            Customer updatedCustomer = new Customer(new1, new2, newType);
            bool wasUpdated = _repo.UpdateExistingCustomer(oldName, updatedCustomer);
            if (wasUpdated)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }

        public void DeleteACustomer()
        {
            Console.WriteLine("Enter the full name of the customer you want to delete:");
            string customerToDelete = Console.ReadLine();
            bool wasRemoved = _repo.RemoveCustomerByFullName(customerToDelete);
            if (wasRemoved)
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error, please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        public void GetAlphabeticalCustomerList()
        {
            Console.Clear();

            List<Customer> cList = _repo.GetCustomers();
            
            Console.WriteLine("FirstName |  LastName  |  Type  |   Email  ");
            
            foreach (Customer customer in cList.OrderBy(x => x.FirstName))
            {
                
                string eValue = _repo.GetCustomerEmailByType(customer.Type.ToString());
                Console.WriteLine($"{customer.FirstName,-10} {customer.LastName,-12} {customer.Type,-10} {eValue,20}");

            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
