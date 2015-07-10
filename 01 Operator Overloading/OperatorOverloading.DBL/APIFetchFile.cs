using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OperatorOverloading.DBL
{
    class APIFetchFile
    {
        public static string getJSON()
        {
            string path = "C:/Users/jyeola/Desktop/conversion_rates.txt";
            if(File.Exists(path)==false)
            {
                throw new SystemException("File not found exception");
            }
            return System.IO.File.ReadAllText(path);
        }
    }
}
