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
            if (this == null)
            {
                throw new NullReferenceException();
            }
            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target) || source.Length != 3 || target.Length != 3)
            {
                throw new System.Exception(Messages.CurrencyInvalid);
            }
            //API Fetch
            string json = APIFetchFile.getJSON();
            //JSON Parse
            string[] conversionStrings = JSONParser.parseJSON(json);

            //Calculate Conversion Rate    
            foreach (string i in conversionStrings)
            {
                if (i.Contains(target.ToUpper()))
                {
                    string[] convertRate = i.Split(':');
                    double amount;
                    if (double.TryParse(convertRate[1], out amount) == false || amount <0 || double.IsPositiveInfinity(amount) || amount == double.MaxValue)
                        throw new System.Exception(Messages.RateInvalid);

                    return Convert.ToDouble(convertRate[1]);
                }
            }
            throw new System.Exception(Messages.CurrencyNotFound);
        }

    }
}
