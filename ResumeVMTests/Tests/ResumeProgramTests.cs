using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ResumeVMTests.Library;

namespace ResumeVMTests
{
    [TestClass]
    public class ResumeProgramTests
    {
        /// <summary>
        /// Тест на пустые значения, ожидается ошибка
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSearcherEmpty_Exception()
        {
            bool actual = ResumeProgramCheckLibrary.CheckCreateResume("", "", "", "", "", "", "", "");
        }

        /// <summary>
        /// Тест на то, что все введено правильно
        /// </summary>
        [TestMethod]
        public void TestSearcher_True()
        {
            bool actual = ResumeProgramCheckLibrary.CheckCreateResume("Николай", "Николаев", "Николаевич", "Ул. Пушкина д.3", "+78200553535",
                "mail@gmail.com", "Екатеринбург", "Женат");
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Тест на номер телефона, ожидается ошибка
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestPhoneNumber_Exception()
        {
            bool actual = ResumeProgramCheckLibrary.CheckCreateResume("Николай", "Николаев", "Николаевич", "Ул. Пушкина д.3", "+28200553535",
                "mail@gmail.com", "Екатеринбург", "Женат");
        }

        /// <summary>
        /// Тест на электронную почту, ожидается ошибка
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEmail_Exception()
        {
            bool actual = ResumeProgramCheckLibrary.CheckCreateResume("Николай", "Николаев", "Николаевич", "Ул. Пушкина д.3", "+78200553535",
                "mail", "Екатеринбург", "Женат");
        }
    
        /// <summary>
        /// Тест на числовые значения в полях где их быть не должно, ожидается ошибка
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDigit_Exception()
        {
            bool actual = ResumeProgramCheckLibrary.CheckCreateResume("Николай1", "Николаев", "Николаевич", "Ул. Пушкина д.3", "+78200553535",
                "mail@gmail.com", "Екатеринбур2г", "Женат3");
        }
    }
}
