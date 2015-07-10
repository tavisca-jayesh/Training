using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.DBL
{
    class JSONParser
    {
        public static string[] parseJSON(string json)
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
            string[] currencywiseSplit = initialSplit[2].Split(',');
            if(currencywiseSplit.Length == 0)
                throw new SystemException(Messages.InvalidJsonFormat);
            return currencywiseSplit;
        }
    }
}
