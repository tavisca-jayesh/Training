using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAttributes;

namespace TestingModel
{
    [TestClassAttribute]
    class TestClass2
    {
        [TestMethodAttribute]
        [TestCategory("Functions")]
        public void TestFunction4()
        {

        }

        [TestMethodAttribute]
        public void TestFunction5()
        {

        }

        [TestMethodAttribute]
        [TestCategory("Functions")]
        public void TestFunction6()
        {

        }
    }
}
