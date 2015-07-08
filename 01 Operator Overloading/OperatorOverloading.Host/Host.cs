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
            string inputString;
            
            try
            {
                // Input
                Console.WriteLine(Messages2.InputMessage);
                inputString = Console.ReadLine();
               // Console.WriteLine("Enter a valid Amount ex: 100");
                
                //calling constructor
                Money money1 = new Money(inputString);

                // Input
                Console.WriteLine(,Messages2.InputMessage);
                inputString = Console.ReadLine();
                
                //calling constructor
                Money money2 = new Money(inputString);

                //this statement can throw exception
                Money money3 = money1 + money2;
                Console.WriteLine("The Amount and Currency is : {1}  {0}", money3.Currency, money3.Amount);
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