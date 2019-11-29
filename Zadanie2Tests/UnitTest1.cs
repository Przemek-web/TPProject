﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;

namespace Zadanie2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestJSON()
        {
            C c = new C(DateTime.Today, 14.32F, "tekstC", null);
            B b = new B(DateTime.Today, 5.0F, "tekstB", c);
            A a = new A(DateTime.Today, 3.14F, "tekstA", b);
            c.A = a;
            SerializationJSON serializationJSON = new SerializationJSON();
            serializationJSON.SerializeJsonA(a, "A.json");
            serializationJSON.SerializeJsonB(b, "B.json");
            serializationJSON.SerializeJsonC(c, "C.json");

            DeserializationJSON deserializationJSON = new DeserializationJSON();
            A a_new = deserializationJSON.DeserializeJsonA("A.json");
            B b_new = deserializationJSON.DeserializeJsonB("B.json");
            C c_new = deserializationJSON.DeserializeJsonC("C.json");

            Assert.IsNotNull(a_new);
            Assert.IsNotNull(b_new);
            Assert.IsNotNull(c_new);
            Assert.AreEqual(a.DateTimeA, a_new.DateTimeA);
            Assert.AreEqual(b.Fb1, b_new.Fb1);
            Assert.AreEqual(c.Sc1, c_new.Sc1);
            Assert.AreEqual(a.Sa1, c.A.Sa1);
            Assert.IsTrue(a == c.A);
          

                




        }

        [TestMethod]
        public void TestCSV()
        {
            C c_a = new C(new DateTime(2019,2,3,1,1,1) , 14.32F, "tekstC", null);
            B b_a = new B(new DateTime(2019, 2, 3,1,1,1), 5.0F, "tekstB", c_a);
            A a_a = new A(new DateTime(2019, 2, 3, 1, 1, 1), 3.14F, "tekstA", b_a);
            c_a.A = a_a;

            SerializationCSV.SerializeA(a_a, "Atest.csv");

            C c_b = new C(new DateTime(2019, 2, 3, 1, 1, 1), 14.32F, "tekstC", null);
            B b_b = new B(new DateTime(2019, 2, 3, 1, 1, 1), 5.0F, "tekstB", c_b);
            A a_b = new A(new DateTime(2019, 2, 3, 1, 1, 1), 3.14F, "tekstA", b_b);
            c_b.A = a_b;
            SerializationCSV.SerializeB(b_b, "Btest.csv");


            C c_c = new C(new DateTime(2019, 2, 3, 1, 1, 1), 14.32F, "tekstC", null);
            B b_c = new B(new DateTime(2019, 2, 3, 1, 1, 1), 5.0F, "tekstB", c_c);
            A a_c = new A(new DateTime(2019, 2, 3, 1, 1, 1), 3.14F, "tekstA", b_c);
            c_c.A = a_c;
            SerializationCSV.SerializeC(c_c, "Ctest.csv");

            A newa = DeserializationCSV.DeserializeA("Atest.csv");
            B newb = DeserializationCSV.DeserializeB("Btest.csv");
            C newc = DeserializationCSV.DeserializeC("Ctest.csv");
            Assert.IsNotNull(newa);
            Assert.IsNotNull(newb);
            Assert.IsNotNull(newc);


            Assert.IsTrue(newa == newa.B.C.A);
            Assert.IsTrue(newb == newb.C.A.B);
            Assert.IsTrue(newc == newc.A.B.C);
            Assert.IsTrue(newc.Equals(newc.A.B.C));


            Assert.AreEqual(newa.Fa1, a_a.Fa1);
            Assert.AreEqual(newa.Sa1, a_a.Sa1);
            Assert.AreEqual(newa.DateTimeA.Date, a_a.DateTimeA.Date);

        }



    }
}