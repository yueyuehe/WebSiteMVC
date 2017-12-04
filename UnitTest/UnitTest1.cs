using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var type = Type.GetType("UnitTest.EFTest");

            Console.WriteLine(type.ToString());

        }
    }
}
