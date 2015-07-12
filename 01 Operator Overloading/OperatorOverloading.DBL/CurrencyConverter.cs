using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.DBL
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public double GetConversionRate(string source, string target)
        {
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target) || source.Length != 3 || target.Length != 3)
            {
                throw new System.Exception(Messages.CurrencyInvalid);
            }
            //API Fetch
            string json = APIFetchFile.GetJSON();
            //JSON Parse
            Dictionary<string, double> conversionFactor = JSONParser.ParseJSON(json);
            target = target.ToUpper();
            if (conversionFactor.ContainsKey(target))
            {
                double amount = conversionFactor[target];
                return amount;
            }

            throw new System.Exception(Messages.CurrencyNotFound);
        }

    }
}
 