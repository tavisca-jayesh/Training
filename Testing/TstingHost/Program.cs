using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestingModel;
using TestAttributes;

namespace TestingHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFrom(args[0]);
            string category = "";
            try
            {
                if (args[0] == null)
                    throw new ArgumentException("No assembly to load from");
                Console.WriteLine("Enter The Category");
                category = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(category) || string.IsNullOrEmpty(category))
                    category = "none";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var testIgnoreMethods = new List<string>();
            var testExecuteMethods = new List<string>();
            var testCategoryMethods = new List<string>();
            var testClass = new List<string>();

            foreach (Type type in assembly.GetTypes())
            {
                System.Reflection.MemberInfo info = type;
                foreach (var attribute in info.GetCustomAttributes(false))
                {
                    if (attribute is TestClassAttribute)
                        testClass.Add(info.Name.ToString());
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        foreach (var attr in method.GetCustomAttributes(false))
                        {
                            if (attr is TestIgnore)
                            {
                                testIgnoreMethods.Add(method.ToString());
                                testCategoryMethods.Remove(method.ToString());
                                testExecuteMethods.Remove(method.ToString());
                            }
                            else
                            {
                                if (attr is TestCategoryAttribute && category.Equals("none") == false)
                                {
                                    testCategoryMethods.Add(method.ToString());
                                }
                                if (attr is TestMethodAttribute)
                                {
                                    testExecuteMethods.Add(method.ToString());
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Executable Methods : ");
            foreach (var i in testExecuteMethods)
                Console.WriteLine(i);
            Console.WriteLine("------------------------");
            Console.WriteLine("Ignored Methods : ");
            foreach (var i in testIgnoreMethods)
                Console.WriteLine(i);
            Console.WriteLine("------------------------");
            Console.WriteLine("Category {0} Methods : ", category);
            foreach (var i in testCategoryMethods)
                Console.WriteLine(i);
            Console.WriteLine("------------------------");
            Console.WriteLine("Testable Classes : ");
            foreach (var i in testClass)
                Console.WriteLine(i);
            Console.WriteLine("------------------------");
        }
    }
}
