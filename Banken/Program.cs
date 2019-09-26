using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Text;


namespace Banken
{
    class Program
    {
        static List<Customer> list = new List<Customer>();

        static void WriteFile(string filename)
        {
            File.WriteAllText(filename, "Hello Customers");
        }

        static void ReadFile(string filepath, string filename)
        {
            if (File.Exists(filename))
            {
                Console.WriteLine(File.ReadAllText(filename));
            }
            
        }
        /// <summary>
        /// Huvud programmet som låter användaren välja olika alternativ
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string filepath = @"C:\test\";
            string filename = @"mybank.txt";

            ReadFile(filepath, filename);
            int choise = 0;
            while (choise != 7)
            {
                choise = SelectMenuItem();
                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Du valde att lägga in en ny användare");
                        AddCustomer();
                        break;
                    case 2:
                        Console.WriteLine("Du vill ta bort en användare");
                        RemoveCustomer();
                        break;
                    case 3:
                        Console.WriteLine("Du vill se alla befintliga användare");
                        ShowCustomer();
                        break;
                    case 7:
                        Console.WriteLine("Du valde att avsluta programmet");

                        WriteFile(filepath, filename);

                        break;
                }
            }
            

            

            Console.ReadLine();
        }

        private static void WriteFile(string filepath, string filename)
        {
            string f = filepath + filename;
            if (File.Exists(f))
            {
                File.Delete(f);
            }

            if (Directory.Exists(filepath) == false)
            {
                Directory.CreateDirectory(filepath);
            }
        }

        static void ShowCustomer()
        {
            foreach (Customer i in list)
            {
                Console.WriteLine("Namn: " + i.Name + " Balance: " + i.Balance);
            }
        }

        static void RemoveCustomer()
        {
            int n = 1;
            foreach (Customer i in list)
            {
                Console.WriteLine(n + " Namn: " + i.Name);
                n += 1;
            }
            Console.WriteLine("Vilken använder vill du ta bort? ");
            int remove = int.Parse(Console.ReadLine());
            list.RemoveAt(remove - 1);

        }

        static void AddCustomer()
        {
            Customer info1 = new Customer(); //Objectet info1 skapas av klassen Customer med hjälp av konstruktorn
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

            return choise;
        }

    }
}
