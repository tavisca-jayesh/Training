using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        public double Amount { get; set; }
        public string Currency { get; set; }

        //The operator 
        public static Money operator+(Money money1,Money money2)
        {
            Money money3 = new Money();
         
            if (money1.Currency.Equals(money2.Currency))
            {
                money3.Amount= money1.Amount + money2.Amount;
                money3.Currency = money1.Currency;
                if(double.IsInfinity(money3.Amount) || money3.Amount < 0)
                    throw new System.ArgumentException("The value of Arguments passed is not valid");
                return money3;
            }
            else
            {
               throw new System.Exception("Currency Types do not match");
            }
        }
    }
}
