using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;

namespace Banken
{
    class Customer
    {
        public string Name { get; set; }
        public int Balance { get; set; }

        public Customer()
        {
        }

        public void SetCustomerByString(string row)
        {
            string[] items = row.Split(',');
            this.Name = items.First();
            this.Balance = int.Parse(items.Last());

        }


        public string ShowCustomer { get { return "Namn: " + Name + " Balance: " + Balance + " kr"; } }
    }
}
