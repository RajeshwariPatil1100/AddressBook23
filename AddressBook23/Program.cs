using AddressBook23;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookDay23
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address BOOK Program");
            AddressBook ab = new AddressBook("Rajeshwari", "Patil", "mumbai", "Mumbai", "Maharashtra", "Rajeshwari@11.com", 400023, 9632587412);
            ab.DisplayContacts();
        }
    }
}