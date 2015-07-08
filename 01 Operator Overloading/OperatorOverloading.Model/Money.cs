﻿using System;
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

        public Money(string input)
        {
            var inputarr = input.Split(' ');
            double temp;

            bool checkNull = double.TryParse(inputarr[0], out temp);
            if (checkNull == false)
            {
                throw new System.ArgumentException(Messages.AmountInvalid);
            }
            //temp = double.MaxValue*0.75;
            this.Amount = temp;

            if (string.IsNullOrWhiteSpace(inputarr[1]) == true)
            {
                throw new System.ArgumentException(Messages.CurrencyEmpty);
            }
            this.Currency = inputarr[1];
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
                    throw new System.ArgumentException(Messages.AmountInvalid);
                }
                _amount = value;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new System.ArgumentException(Messages.CurrencyEmpty);
                }
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
                double newAmount = money1.Amount + money2.Amount;
                if (double.IsPositiveInfinity(newAmount))
                    throw new System.ArgumentException(Messages.AmountOverflow);
                //money3.Currency = money1.Currency;
                //return money3;
                return new Money(newAmount, money1.Currency);
            }
            else
            {
                throw new System.ArgumentException(Messages.CurrencyMismatch);
            }
        }
    }
}