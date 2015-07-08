using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        //constructor
        public Money(double amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0 || value == double.MaxValue)
                {
                    throw new System.ArgumentException(messages.amountInvalid);
                }
                else
                {
                    _amount = value;
                }
            }
        }

        private string _currency;
        public string Currency
        {
            get
            {
                return _currency;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new System.ArgumentException(messages.currencyEmpty);
                }
                else
                {
                    _currency = value.ToUpper();
                }
            }
        }

        //constructor
        public Money()
        {
            Amount = 0;
            Currency = null;
        }

        //operator overloading
        public static Money operator +(Money money1, Money money2)
        {
            if (string.Equals(money1.Currency, money2.Currency))
            {
                double newAmount;
                newAmount = money1.Amount + money2.Amount;
                if (double.IsPositiveInfinity(newAmount))
                    throw new System.ArgumentException(messages.amountOverflow);
                //money3.Currency = money1.Currency;
                //return money3;
                return new Money(newAmount, money1.Currency);
            }
            else
            {
                throw new System.ArgumentException(messages.currencyMismatch);
            }
        }
    }
}
