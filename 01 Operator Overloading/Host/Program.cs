using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating objects 
            Rectangle A = new Rectangle();
            Rectangle B = new Rectangle();
            Rectangle C = new Rectangle();

            //setting values
            A.Height = double.MaxValue; 
            A.Width = double.MaxValue;

            B.Height = double.MaxValue;
            B.Width = double.MaxValue;

            C.Height = 0;
            C.Width = 0;

            //overloading binary operator +
            C = A + B;

            Console.WriteLine("Height of C : {0}", C.Height);
            Console.WriteLine("Weight of C : {0}", C.Width);
            Console.ReadKey();

        }
    }

    


}
