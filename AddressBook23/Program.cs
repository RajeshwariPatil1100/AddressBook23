using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Wellcome to Address Book program");
            AddressBook add = new AddressBook();
            int choice, choice2;
            string BookName = "MyBook";
            Console.WriteLine("What whould you like to do?\n1.Work on Default AddressBook\n2.Create new AddressBook");
            Console.WriteLine("Enter your Choice");
            choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    add.AddAddressBook(BookName);
                    break;
                case 2:
                    Console.WriteLine("Enter Name of new address Book");
                    BookName = Console.ReadLine();
                    add.AddAddressBook(BookName);
                    break;
            }
            do
            {
                Console.WriteLine("Working On {0} AddressBook", BookName);
                Console.WriteLine("choice an option \n1.AddContact\n2.Edit Contact\n3.DeleteContact\n4.ViewContact\n" +
                    "5.View All COntact\n6.Add New AddressBook\n7.Swich addressBook" +
                    "\n8.Find person from city/state\n9.Get person count in city/state\n10.Get person sort by alphabetically" +
                    "\n11.Get person sort by City/State/Zip\n12.Read and write file\n0.Exit");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter FirstName");
                        string FirstName = Console.ReadLine();
                        Console.WriteLine("Enter LastName");
                        string LastName = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        string Address = Console.ReadLine();
                        Console.WriteLine("Enter City");
                        string City = Console.ReadLine();
                        Console.WriteLine("Enter State");
                        string State = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        string Email = Console.ReadLine();
                        Console.WriteLine("Enter Zip");
                        int Zip = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter PhoneNumber");
                        long PhoneNumber = Convert.ToInt64(Console.ReadLine());
                        add.CreateContact(FirstName, LastName, Address, City, State, Email, Zip, PhoneNumber, BookName);
                        break;
                    case 2:
                        Console.WriteLine("Enter First Nmae Of Contact To edit");
                        string nameToedit = Console.ReadLine();
                        add.EditContact(nameToedit, BookName);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Nmae Of Contact To delete");
                        string nameTodelete = Console.ReadLine();
                        add.DeleteContact(nameTodelete, BookName);
                        break;
                    case 4:
                        Console.WriteLine("Enter First Nmae Of Contact To view");
                        string nameToview = Console.ReadLine();
                        add.ViewContact(nameToview, BookName);
                        break;
                    case 5:

                        add.ViewContact(BookName);
                        break;
                    case 6:
                        Console.WriteLine("Enter First Nmae for New Address book");
                        string newaddressbook = Console.ReadLine();
                        add.AddAddressBook(newaddressbook);
                        Console.WriteLine("Would you like to switch To " + newaddressbook);
                        Console.WriteLine("1.yes\n2.No");
                        int c = Convert.ToInt32(Console.ReadLine());
                        if (c == 1)
                        {
                            BookName = newaddressbook;
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Name Of AddressBook From Below List");
                        foreach (KeyValuePair<string, AddressBook> item in add.GetaddressBook())
                        {
                            Console.WriteLine(item.Key);
                        }
                        while (true)
                        {
                            BookName = Console.ReadLine();
                            if (add.GetaddressBook().ContainsKey(BookName))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such AddressBook found. Try Again.");
                            }
                        }
                        break;
                    case 8:
                        Console.WriteLine("Would you like to " + "\n1.Search from city\n2.Search from state  ");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter city");
                                string CityName = Console.ReadLine();
                                add.FindPersonFromCity(CityName, BookName);
                                break;
                            case 2:
                                Console.WriteLine("Enter state ");
                                string StateName = Console.ReadLine();
                                add.FindPersonFromState(StateName, BookName);
                                break;
                        }
                        break;
                    case 9:
                        Console.WriteLine("Would you like to " + "\n1.person count in city\n2.person count in state  ");
                        int check = Convert.ToInt32(Console.ReadLine());
                        switch (check)
                        {
                            case 1:
                                Console.WriteLine("Enter city name to find count of person ");
                                string CityName = Console.ReadLine();
                                add.GetPersonCountByCity(CityName, BookName);
                                break;
                            case 2:
                                Console.WriteLine("Enter city name to find count of person ");
                                string StateName = Console.ReadLine();
                                add.GetPersonCountByState(StateName, BookName);
                                break;
                        }
                        break;
                    case 10:
                        add.SortByName(BookName);
                        break;
                    case 11:
                        Console.WriteLine("Would you like to " + "\n1.Sort person by city\n2.Sort person by state\n3.Sort person by ZipCode  ");
                        int checkc = Convert.ToInt32(Console.ReadLine());
                        switch (checkc)
                        {
                            case 1:
                                add.SortByCity(BookName);
                                break;
                            case 2:
                                add.SortByState(BookName);
                                break;
                            case 3:
                                add.SortByZip(BookName);
                                break;
                        }
                        break;
                    case 12:
                        Console.WriteLine("1.Write person contact in file\n2.Read Address book file");
                        int op = Convert.ToInt32(Console.ReadLine());
                        switch (op)
                        {
                            case 1:
                                add.WritePersonContact(BookName);
                                break;
                            case 2:
                                add.ReadAddressBook();
                                break;
                        }
                        break;

                }

            } while (choice != 0);
        }
    }
}