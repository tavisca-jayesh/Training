using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace OperatorOverloading.DBL
{
    class APIFetchFile
    {
        public static string GetJSON()
        {
            string filePath = ConfigurationManager.AppSettings["Path"];
            if (File.Exists(filePath) == false)
            {
                throw new SystemException("File not found exception");
            }
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
