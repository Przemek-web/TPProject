using System;
using System.IO;
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
               classC c = new classC(DateTime.Today, 14.32F, "tekstC", null);
               classB b = new classB(DateTime.Today, 5.0F, "tekstB", c);
               classA a = new classA(DateTime.Today, 3.14F, "tekstA", b);
               c.aRef = a;
               SerializationJSON serializationJSON = new SerializationJSON();
               serializationJSON.SerializeJsonA(a, "A.json");
               serializationJSON.SerializeJsonB(b, "B.json");
               serializationJSON.SerializeJsonC(c, "C.json");

               DeserializationJSON deserializationJSON = new DeserializationJSON();
               classA a_new = deserializationJSON.DeserializeJsonA("A.json");
               classB b_new = deserializationJSON.DeserializeJsonB("B.json");
               classC c_new = deserializationJSON.DeserializeJsonC("C.json");

               Assert.IsNotNull(a_new);
               Assert.IsNotNull(b_new);
               Assert.IsNotNull(c_new);
               Assert.AreEqual(a.dateTime, a_new.dateTime);
               Assert.AreEqual(b.name, b_new.name);
               Assert.AreEqual(c.number, c_new.number);
               Assert.AreEqual(a.dateTime, c.aRef.dateTime);
               Assert.IsTrue(a == c.aRef);






       
        }

        [TestMethod]
        public void TestCSV()
        {
              classC c_a = new classC(new DateTime(2019,2,3,1,1,0) , 14.32F, "tekstC", null);
              classB b_a = new classB(new DateTime(2019, 2, 3,1,1,0), 5.0F, "tekstB", c_a);
              classA a_a = new classA(new DateTime(2019, 2, 3, 1, 1, 0), 3.14F, "tekstA", b_a);
              c_a.aRef = a_a;


              FormatterCSV formatterCSVA = new FormatterCSV();

              using (FileStream stream = File.Open("A.csv", FileMode.OpenOrCreate))
              {
                  formatterCSVA.Serialize(stream, a_a);
              }



              classC c_b = new classC(new DateTime(2019, 2, 3, 1, 1, 0), 14.32F, "tekstC", null);
              classB b_b = new classB(new DateTime(2019, 2, 3, 1, 1, 0), 5.0F, "tekstB", c_b);
              classA a_b = new classA(new DateTime(2019, 2, 3, 1, 1, 0), 3.14F, "tekstA", b_b);
              c_b.aRef = a_b;

              FormatterCSV formatterCSVB = new FormatterCSV();

              using (FileStream stream = File.Open("B.csv", FileMode.OpenOrCreate))
              {
                  formatterCSVB.Serialize(stream, b_b);
              }


                classC c_c = new classC(new DateTime(2019, 2, 3, 1, 1, 0), 14.32F, "tekstC", null);
                classB b_c = new classB(new DateTime(2019, 2, 3, 1, 1, 0), 5.0F, "tekstB", c_c);
                classA a_c = new classA(new DateTime(2019, 2, 3, 1, 1, 0), 3.14F, "tekstA", b_c);
                c_c.aRef = a_c;

              FormatterCSV formatterCSVC = new FormatterCSV();

              using (FileStream stream = File.Open("C.csv", FileMode.OpenOrCreate))
              {
                  formatterCSVC.Serialize(stream, c_c);
              }

               classA newa;

               using (FileStream stream = File.Open("A.csv", FileMode.Open))
              {
                  newa = (classA)formatterCSVC.Deserialize(stream);
              }


               classB newb;


              using (FileStream stream = File.Open("B.csv", FileMode.Open))
              {
                  newb = (classB)formatterCSVB.Deserialize(stream);
              }


              classC newc;

              using (FileStream stream = File.Open("C.csv", FileMode.Open))
              {
                  newc = (classC)formatterCSVC.Deserialize(stream);
              }
              Assert.IsNotNull(newa);
                Assert.IsNotNull(newb);
                Assert.IsNotNull(newc);


                Assert.IsTrue(newa == newa.bRef.cRef.aRef);
                Assert.IsTrue(newb == newb.cRef.aRef.bRef);
                Assert.IsTrue(newc == newc.aRef.bRef.cRef);
                Assert.IsTrue(newc.Equals(newc.aRef.bRef.cRef));


                Assert.AreEqual(newa.number, a_a.number);
                Assert.AreEqual(newa.name, a_a.name);
                Assert.AreEqual(newa.dateTime, a_a.dateTime); 

          }



      

               
        
    }
}
