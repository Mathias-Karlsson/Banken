using System;
using System.Collections.Generic;

namespace Banken
{
    class Program
    {
        static List<Customer> list = new List<Customer>();
        static void Main(string[] args)
        {
            
            foreach (Customer i in list)
            {
                Console.WriteLine("Namn: " + i.Name + " Balance: " + i.Balance);
            }

            Console.ReadLine();
        }
        static void AddCustomer()
        {
            Customer info1 = new Customer();
            info1.Name = Console.ReadLine();
            info1.Balance = int.Parse(Console.ReadLine());
            list.Add(info1);
        }
        static int SelectMenuItem()
        {
            Console.WriteLine("Välkommen till banken!");

            Console.WriteLine("Ange vilket av följande alternativ du önskar göra");

            Console.WriteLine("1 : Lägga till en användare");
            Console.WriteLine("2 : Ta bort en användare");
            Console.WriteLine("3 : Visa alla befintliga användare");
            Console.WriteLine("4 : Visa saldo för en användare");
            Console.WriteLine("5 : Gör en insättning för en användare");
            Console.WriteLine("6 : Gör ett uttag för en användare");
            Console.WriteLine("7 : Avsluta programmet");

            Console.WriteLine("Ange ditt val: ");
            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    Console.WriteLine("Du valde att lägga in en ny användare");
                    break;
                case 2:
                    Console.WriteLine("Du vill ta bort en användare");
                    break;
                case 3:
                    Console.WriteLine("Du vill se alla befintliga användare");
                    break;
                case 7:
                    Console.WriteLine("Du valde att avsluta programmet");
                    break;
            }

            return choise;
        }
    }
}
