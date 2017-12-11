using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;
using System.Data.Entity;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subTypeQuery = from t in Assembly.GetExecutingAssembly().GetTypes()
                               where IsSubClassOf(t, typeof(DbContext))
                               select t;

            foreach (var type in subTypeQuery)
            {
                Console.WriteLine(type);
                string s = "";
            }
        }
        static bool IsSubClassOf(Type type, Type baseType)
        {
            var b = type.BaseType;
            while (b != null)
            {
                if (b.Equals(baseType))
                {
                    return true;
                }
                b = b.BaseType;
            }
            return false;
        }
    }
}
