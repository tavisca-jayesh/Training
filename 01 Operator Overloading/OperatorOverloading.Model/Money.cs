using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.Model
{
    public class Money
    {
        //Double Parameter constructor
        public Money(double amount, string currency)
        {
            if (double.IsInfinity(amount))
            {
                throw new System.ArgumentException(Messages.AmountOverflow);
            }
            this.Amount = amount;
            this.Currency = currency;
        }

        //Single Parameter Constructor
        public Money(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new System.ArgumentException(Messages.NullInput);
            }

            var inputarr = input.Split(' ');
            double amount;

            //setting Amount
            bool checkNull = double.TryParse(inputarr[0], out amount);
            if (checkNull == false)
            {
                throw new System.ArgumentException(Messages.AmountInvalid);
            }
            this.Amount = amount;

            //setting currency
            if (string.IsNullOrWhiteSpace(inputarr[1]) == true)
            {
                throw new System.ArgumentException(Messages.CurrencyEmpty);
            }
            this.Currency = inputarr[1];
        }

        //property amount
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
                    throw new System.ArgumentException(Messages.AmountInvalid);
                }
                _amount = value;
            }
        }

        //property currency
        private string _currency;
        public string Currency
        {
            get
            {
                return _currency;
            }
            private set
            {
                _currency = value;
            }
        }

        //operator overloading
        public static Money operator +(Money money1, Money money2)
        {
            if (money1 == null || money2 == null)
            {
                throw new System.ArgumentNullException(Messages.ArgumentNull);
            }
            if (string.Equals(money1.Currency, money2.Currency, StringComparison.OrdinalIgnoreCase))
            {
                return new Money(money1.Amount + money2.Amount, money1.Currency);
            }
            else
            {
                throw new System.ArgumentException(Messages.CurrencyMismatch);
            }
        }
    }
}