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
            double amountVar;
            string currencyVar;
            try
            {
                // Input
                Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
                currencyVar = Console.ReadLine();
                Console.WriteLine("Enter a valid Amount ex: 100");
                double.TryParse(Console.ReadLine(), out amountVar);

                //calling constructor
                Money money1 = new Money(amountVar, currencyVar);

                // Input
                Console.WriteLine("Enter a valid Curreny type ex: USD,INR");
                currencyVar = Console.ReadLine();
                Console.WriteLine("Enter a valid Amount ex: 100");
                double.TryParse(Console.ReadLine(), out amountVar);

                //calling constructor
                Money money2 = new Money(amountVar, currencyVar);

                //this statement can throw exception
                Money money3 = money1 + money2;
                Console.WriteLine("The Currency and Amount is : {0}  {1}", money3.Currency, money3.Amount);
            }
            catch (Exception e)
            {
                //Handle the exception in this section
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}