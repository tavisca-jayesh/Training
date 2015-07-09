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
            try
            {
                // Input and calling constructor
                Console.WriteLine(Messages.InputMessage);
                var money1 = new Money(Console.ReadLine());

                // Input and calling constructor
                Console.WriteLine(Messages.InputMessage);
                var money2 = new Money(Console.ReadLine());

                //this statement can throw exception
                var money3 = money1 + money2;
                Console.WriteLine("The Amount and Currency is : {1} {0}", money3.Currency, money3.Amount);
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