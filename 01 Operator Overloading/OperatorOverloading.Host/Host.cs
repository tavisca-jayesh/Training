using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorOverloading.Model;

namespace OperatorOverloading.Host
{
    class Host
    {
        static void Main(string[] args)
        {
            
            Money Money1 = new Money();
            Money Money2 = new Money();
            Money Money3 = new Money();
           
            // Input Salary
            Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
            Money1.Currency = Console.ReadLine();
            Console.WriteLine("Enter a valid Amount ex: 100");
            Money1.Amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
            Money2.Currency = Console.ReadLine();
            Console.WriteLine("Enter a valid Amount ex: 100");
            Money2.Amount = Convert.ToDouble(Console.ReadLine());

            try
            {
                //this statement can throw exception
                Money3 = Money1 + Money2;
                Console.WriteLine("The Currency and Amount is : {0}  {1}", Money3.Currency, Money3.Amount);
            }
            catch (Exception E)
            {
                //Handle the exception in thois section
                Console.WriteLine(E.Message);
            }
            Console.ReadKey();
        }
    }
}