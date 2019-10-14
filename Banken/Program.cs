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

        static void ReadFileOld(string filepath, string filename)
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
                    case 4:
                        Console.WriteLine("Du vill see en persons saldo");
                        ShowBalance();
                        break;
                    case 5:
                        Console.WriteLine("Du vill göra en insättning för en person");
                        AddBalance();
                        break;
                    case 6:
                        Console.WriteLine("Du vill ta ut pengar från en person");
                        RemoveBalance();
                        break;
                    case 7:
                        Console.WriteLine("Du valde att avsluta programmet");

                        WriteFile(filepath, filename); //WriteFile skriver ner alla ändringar i en filename och skickar det till filepath

                        break;
                    default:
                        Console.WriteLine("Du gjorde ett felaktigt val"); //När man svarar med något annat som är inte 1 till 7
                        break;
                }
            }
            

            

            Console.ReadLine();
        }

        /// <summary>
        /// WriteFile skriver ner ändringar som har gjorts i list
        /// </summary>
        /// <param name="args"></param>
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

            string appendText = "";
            foreach (Customer item in list)
            {
                appendText += item.GetCustomerInfoString() + Environment.NewLine;
            }
            File.AppendAllText(f, appendText);
        }

        /// <summary>
        /// ReadFile läser in alla namn som har lagts in i banken och lägger de i en file
        /// </summary>
        /// <param name="args"></param>
        private static void ReadFile(string filepath, string filename)
        {
            string f = filepath + filename; //Objectet f letar efter filepath och filename för vars Customer kommer ligga i
            if (File.Exists(f))
            {
                string[] rows = File.ReadAllLines(f);
                foreach (string row in rows)
                {
                    Customer customer = new Customer();
                    customer.SetCustomerByString(row);
                    list.Add(customer);
                }
            }
        }

        /// <summary>
        /// ShowCustomer visar alla Customer tillsammans med Balance i list i nummer ordning
        /// </summary>
        /// <param name="args"></param>
        static void ShowCustomer()
        {
            foreach (Customer i in list)
            {
                Console.WriteLine("Namn: " + i.Name + " Balance: " + i.Balance); 
            }
        }

        /// <summary>
        /// RemoveCustomer används för att ta bort en Customer som finns i list
        /// </summary>
        /// <param name="args"></param>
        static void RemoveCustomer()
        {
            int n = 1;
            foreach (Customer i in list)
            {
                Console.WriteLine(n + " Namn: " + i.Name);
                n += 1;
            }
            Console.WriteLine("Vilken använder vill du ta bort? ");
            int remove = 0;
            try
            {
                remove = int.Parse(Console.ReadLine()); //Objectet remove används för att ta bort en användare från list i Customer som hade skrivits ut av WriteLine 
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            list.RemoveAt(remove - 1);

        }

        /// <summary>
        /// AddCustomer används för att lägga in en ny Customer och Balance till list
        /// </summary>
        /// <param name="args"></param>
        static void AddCustomer()
        {
            Customer info1 = new Customer(); //Objectet info1 skapas av klassen Customer med hjälp av konstruktorn
            try
            {
                info1.Name = Console.ReadLine(); //Instansen info1
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            try
            {
                info1.Balance = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            list.Add(info1);
        }

        /// <summary>
        /// ShowBalance används för att se hur mycket en Customer har i Balance
        /// </summary>
        /// <param name="args"></param>
        static void ShowBalance()
        {
            int n = 1;
            foreach (Customer i in list)
            {
                Console.WriteLine(n + " Namn: " + i.Name);
                n += 1;
            }
            Console.WriteLine("Vilken använder vill du see? ");
            int show = 0;
            try
            {
                show = int.Parse(Console.ReadLine()); //Objectet show frågar efter någon i klassen Customer
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            Console.WriteLine(list[show].ShowCustomer);
        }

        /// <summary>
        /// AddBalance används för att lägga in Balance till en Customer som finns i list
        /// </summary>
        /// <param name="args"></param>
        static void AddBalance()
        {
            int n = 1;
            foreach (Customer i in list)
            {
                Console.WriteLine(n + " Namn: " + i.Name);
                n += 1;
            }
            Console.WriteLine("Vilken använder ska du sätta pengar i? ");
            int customer = 0;
            try
            {
                customer = int.Parse(Console.ReadLine()); //Objectet customer vill veta vilken i klassen Customer ska få pengar
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            Console.WriteLine("Hur mycket ska du ge? ");
            int money = 0;
            try
            {
                money = int.Parse(Console.ReadLine()); //Objectet money frågar hur mycket pengar du ska ge till personen i klassen Customer
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            list[customer].Balance += money;

        }

        /// <summary>
        /// RemoveBalance används för att ta bort Balance från en Customer som finns i list
        /// </summary>
        /// <param name="args"></param>
        static void RemoveBalance()
        {
            int n = 1;
            foreach (Customer i in list)
            {
                Console.WriteLine(n + " Namn: " + i.Name);
                n += 1;
            }
            Console.WriteLine("Vilken använder ska du ta pengar ifrån? ");
            int customer = 0;
            try
            {
                customer = int.Parse(Console.ReadLine()); //Objectet customer vill veta vilken i klassen Customer som ska förlora pengar
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            Console.WriteLine("Hur mycket ska du ta? ");
            int money = 0;
            try
            {
                money = int.Parse(Console.ReadLine()); //Objectet money frågar hur mycket du ska ta ifrån personen i klassen Customer
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod");
            }
            list[customer].Balance -= money;
        }

        /// <summary>
        /// SelectMenuItem är vad du välja att göra i banken med 1 till 7
        /// </summary>
        /// <param name="args"></param>
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
            int choise = 0;
            try
            {
                choise = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ett fel uppstod!");
            }
            return choise;
        }

    }
}
