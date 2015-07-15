using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.DBL
{
    class GetConversionRates
    {
        public static Dictionary<string, double> ParseJSON(string json)
        {
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrEmpty(json))
            {
                throw new System.Exception(Messages.ArgumentNull);
            }

            string[] initialSplit = json.Split('{');

            if (initialSplit.Length != 3)
                throw new System.Exception(Messages.InvalidJsonFormat);

            //since we do not need the data before second '{' 
            initialSplit[0] = "";
            initialSplit[1] = "";

            initialSplit = initialSplit[2].Split('}');
            if (initialSplit.Length != 3)
                throw new System.Exception(Messages.InvalidJsonFormat);
            initialSplit[1] = "";
            initialSplit[2] = "";

            string[] currencywiseSplit = initialSplit[0].Split(',');
            if (currencywiseSplit.Length == 0)
                throw new SystemException(Messages.InvalidJsonFormat);
            var rates = new Dictionary<string, double>();
            foreach (string rate in currencywiseSplit)
            {
                string[] convertRate = rate.Split(':');
                if (convertRate.Length != 2)
                    throw new System.Exception(Messages.InvalidJsonFormat);

                double amount;
                if (double.TryParse(convertRate[1], out amount) == false || amount < 0 || double.IsPositiveInfinity(amount) || amount == double.MaxValue)
                    throw new System.Exception(Messages.RateInvalid);

                convertRate[0] = convertRate[0].Trim();
                convertRate[0] = convertRate[0].Remove(0, 4);
                convertRate[0] = convertRate[0].Remove(convertRate[0].Length - 1, 1);
                convertRate[1] = convertRate[1].Trim();
                rates.Add(convertRate[0], amount);
            }
            return rates;
        }
    }
}
