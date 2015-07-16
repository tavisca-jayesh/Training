using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAttributes;

namespace TestingModel
{
    [TestClassAttribute]
    class TestClass3
    {
        [TestIgnore]
        [TestMethodAttribute]
        public void TestFunction1()
        {

        }

        [TestMethodAttribute]
        [TestCategoryAttribute("Functions")]
        public void TestFunction2()
        {

        }

        public void TestFunction3()
        {

        }

    }
}
