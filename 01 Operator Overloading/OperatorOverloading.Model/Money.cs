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
         
            if (!string.IsNullOrEmpty(money1.Currency) && !string.IsNullOrEmpty(money2.Currency) && string.Equals(money1.Currency.ToUpper(),money2.Currency.ToUpper()))
            {
                if (money1.Amount < 0 || money2.Amount < 0 || money1.Amount >= double.MaxValue || money2.Amount >= double.MaxValue)
                {
                    throw new System.ArgumentException("The value of Amount passed is not valid");
                }
                else
                {
                    Money money3 = new Money();
                    money3.Amount = money1.Amount + money2.Amount;
                    if (money3.Amount > double.MaxValue  || money3.Amount < 0)
                      throw new System.ArgumentException("The value of Arguments passed is not valid");
                    money3.Currency = money1.Currency.ToUpper();
                    return money3;
                }
            }
            else
            {
                throw new System.ArgumentException("The currency types do not match");
            }
        }
    }
}
