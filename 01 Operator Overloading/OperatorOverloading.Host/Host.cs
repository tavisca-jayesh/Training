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
            
            Money money1 = new Money();
            Money money2 = new Money();
            Money money3 = new Money();
           
            // Input Salary
            Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
            money1.Currency = Console.ReadLine();
            Console.WriteLine("Enter a valid Amount ex: 100");
            money1.Amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
            money2.Currency = Console.ReadLine();
            Console.WriteLine("Enter a valid Amount ex: 100");
            money2.Amount = Convert.ToDouble(Console.ReadLine());

            money1.Amount = double.MaxValue;
            try
            {
                //this statement can throw exception
                money3 = money1 + money2;
                Console.WriteLine("The Currency and Amount is : {0}  {1}", money3.Currency, money3.Amount);
            }
            catch (Exception e)
            {
                //Handle the exception in thois section
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}