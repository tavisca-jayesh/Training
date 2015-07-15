using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading.DBL
{
    public interface ICurrencyConverter
    {
        double GetConversionRate(string source, string target);
    }
}
