/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Rectangle
    {
        //Setting the Properties
        public double Height { get; set; }
        public double Width { get; set; }

        //overloading operator +
        public static Rectangle operator +(Rectangle A, Rectangle B)
        {
            //Temporary Object for Storing Results
            Rectangle C = new Rectangle();

            try
            {

                //Validation for input values
                if (double.MinValue <= A.Height && A.Height <= double.MaxValue && double.MinValue <= B.Height && B.Height <= double.MaxValue)
                {
                    C.Height = A.Height + B.Height;
                }
                else
                {
                   // Console.WriteLine("The Value of Arguments passed are not valid");
                }

                if (double.MinValue <= A.Width && A.Width <= double.MaxValue && double.MinValue <= B.Width && B.Width <= double.MaxValue)
                {
                    C.Width = A.Width + B.Width;
                }
                else
                {
                   // Console.WriteLine("The Value of Arguments passed are not valid");
                }

                if (double.IsInfinity(C.Height) || double.IsInfinity(C.Width))
                    throw new System.OverflowException("The result value is beyond range");
            }
            catch (OverflowException)
            {
                //Console.WriteLine("OverflowExceptoin!! The result value is beyond range");
            }
            finally
            {
                C.Height = C.Height;
                C.Width = C.Width;
            }
            return C;
        }

    }
}
*/