using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;
namespace Application.Tests
{
    [TestClass]
    public class ApplicationOpTests
    {
        [TestMethod]
        public void testAddMethod()
        {
            Student s = new Student();
            s.ID=24;
            s.Name="TestStudent";
            s.BirthDate = new DateTime(2011, 11, 10);
            s.Address = "Cluj";
            MySQLDBManager manager = new MySQLDBManager();
            manager.AddStudent(s);
            Student s1=manager.SelectStudent(s);
            Console.WriteLine("args1: {0} args2: {1} arg3: {2} arg 4: {3}", s.ID, s.Name,s.BirthDate,s.Address);
            Console.WriteLine();
            Console.WriteLine("args1: {0} args2: {1} arg3: {2} arg 4: {3}", s1.ID, s1.Name, s1.BirthDate, s1.Address);
            Assert.AreEqual(s.ID, s1.ID);
            Assert.AreEqual(s.Name, s1.Name);
            Assert.AreEqual(s.BirthDate, s1.BirthDate);
            Assert.AreEqual(s.Address, s1.Address);
        }
    }
}
