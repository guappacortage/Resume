using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResumeVMTests.Library;
using ResumeVMTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResumeVMTests
{
    [TestClass]
    public class ResumeVMTests
    {
        /// <summary>
        /// Тест на ввод логина, которого нет в БД
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckLogin_Exception()
        {
            bool actual = ResumeVMLibrary.CheckAuth("tor","222");
        }
        /// <summary>
        /// Тест на ввод пустой строки в поле логина
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckEmptyLogin_Exception()
        {
            bool actual = ResumeVMLibrary.CheckAuth("", "222");
        }
        /// <summary>
        /// Тест на ввод пустой строки в поле пароля
        /// </summary>

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckEmptyPassword_Exception()
        {
            bool actual = ResumeVMLibrary.CheckAuth("forech", "");
        }
        /// <summary>
        /// Тест на ввод неправильного пароля в поле пароля
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckPassword_Exception()
        {
            bool actual = ResumeVMLibrary.CheckAuth("forech", "111");
        }
        /// <summary>
        /// Тест на ввод логина и пароля
        /// </summary>
        [TestMethod]
        public void CheckPasswordAndLogin_True()
        {
            bool actual = ResumeVMLibrary.CheckAuth("forech", "222");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления соискателя в БД
        /// </summary>
        [TestMethod]
        public void CheckAddSearcher_True()
        {
            DateTime date = new DateTime(2010, 10, 5);
            bool actual = ResumeVMLibrary.CheckCreateSearcher("Андрей", "Андреев", "Андреевич", "Ул. Пушкина д.3", "+7505608127", "rabota@gmail.com","Екатеринбург",
                date,"Женат",123,123,"Отсутствуют","Мужской","Не служил");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления дополнительной информации в БД
        /// </summary>
        [TestMethod]
        public void CheckAddAdditionalInfo_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddNewAdditionalInfo(searcherID, "Персональные данные", "Отсутствует");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения дополнительной информации в БД
        /// </summary>
        [TestMethod]
        public void CheckEditAdditionalInfo_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditAdditionalInfo(searcherID, "Новые персональные данные","Есть");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления дополнительной информации в БД
        /// </summary>
        [TestMethod]
        public void CheckAddCourses_True()
        {
            Core db = new Core();
            List<string> list = new List<string> {"Курс"};
            DateTime date = new DateTime(2010, 10, 5);
            List<DateTime> datelist = new List<DateTime> { date };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddUserCourse(searcherID,list, datelist);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения дополнительной информации в БД
        /// </summary>
        [TestMethod]
        public void CheckEditCourses_True()
        {
            Core db = new Core();
            List<string> list = new List<string> { "Не курс" };
            DateTime date = new DateTime(2010, 9, 5);
            List<DateTime> datelist = new List<DateTime> { date };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditUserCourse(searcherID, list, datelist);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления отмеченного как подходящее резюме в БД
        /// </summary>
        [TestMethod]
        public void CheckAddCheckedResume_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddCheckedResume(searcherID,1);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления изображения в БД
        /// </summary>
        [TestMethod]
        public void CheckAddNewPhoto_True()
        {
            byte[] image_bytes = new byte[0];
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddPhotoLink(searcherID, image_bytes);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления мест образования в БД
        /// </summary>
        [TestMethod]
        public void CheckAddNewEducationPlaces_True()
        {
            Core db = new Core();
            List<string> list = new List<string> { "Место образования" };
            List<DateTime> datestart = new List<DateTime> { new DateTime(2010, 9, 5) };
            List<DateTime> dateend = new List<DateTime> { new DateTime(2010, 10, 5) };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddEducationPlace(searcherID, list, datestart, dateend);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения мест образования в БД
        /// </summary>
        [TestMethod]
        public void CheckEditEducationPlaces_True()
        {
            Core db = new Core();
            List<string> list = new List<string> { "Не место образования" };
            List<DateTime> datestart = new List<DateTime> { new DateTime(2010, 10, 5) };
            List<DateTime> dateend = new List<DateTime> { new DateTime(2010, 11, 5) };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditEducationPlace(searcherID, list, datestart, dateend);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления работодателя в БД
        /// </summary>
        [TestMethod]
        public void CheckAddNewEmployer_True()
        {
            bool actual = ResumeVMLibrary.CheckAddEmployer("Рога и копыта","yuo","111");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления предыдущих работ в БД
        /// </summary>
        [TestMethod]
        public void CheckAddNewPrevJobs_True()
        {
            Core db = new Core();
            List<string> list = new List<string> { "Работа" };
            List<DateTime> datestart = new List<DateTime> {new DateTime(2010, 9, 5) };
            List<DateTime> dateend = new List<DateTime> { new DateTime(2010, 10, 5) };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddPastJob(searcherID,list,datestart,dateend);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения предыдущих работ в БД
        /// </summary>
        [TestMethod]
        public void CheckEditPrevJobs_True()
        {
            Core db = new Core();
            List<string> list = new List<string> { "Не работа" };
            List<DateTime> datestart = new List<DateTime> { new DateTime(2010, 10, 5) };
            List<DateTime> dateend = new List<DateTime> { new DateTime(2010, 11, 5) };
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditPastJobs(searcherID,list, datestart, dateend);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления сферы деятельности в БД
        /// </summary>
        [TestMethod]
        public void CheckAddUserCategory_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddUserCategory(searcherID, 1);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения сферы деятельности в БД
        /// </summary>
        [TestMethod]
        public void CheckEditUserCategory_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditUserCategory(searcherID, 2);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления компьютерного навыка в БД
        /// </summary>
        [TestMethod]
        public void CheckAddComputerSkill_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddComputerSkill(searcherID, "Работа с БД на основе MSSQL");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения компьютерного навыка в БД
        /// </summary>
        [TestMethod]
        public void CheckEditComputerSkill_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditComputerSkill(searcherID, "Работа с визуальными редакторами");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления уровня образования в БД
        /// </summary>
        [TestMethod]
        public void CheckAddEducationGrade_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddEducationGrade(searcherID, 1);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения уровня образования в БД
        /// </summary>
        [TestMethod]
        public void CheckEditEducationGrade_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditEducationGrade(searcherID, 2);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку добавления языков в БД
        /// </summary>
        [TestMethod]
        public void CheckAddUserLanguage_True()
        {
            List<int> list = new List<int> { 1 };
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckAddUserLanguages(searcherID,list);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения языков в БД
        /// </summary>
        [TestMethod]
        public void CheckEditUserLanguages_True()
        {
            List<int> list = new List<int> { 2 };
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckEditUserLanguages(searcherID,list);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }

        /// <summary>
        /// Тест на проверку изменения соискателя в БД
        /// </summary>
        [TestMethod]
        public void CheckEditSearcher_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608127").FirstOrDefault().IdSearcher;
            DateTime date = new DateTime(2010, 10, 5);
            bool actual = ResumeVMLibrary.CheckEditSearcher(searcherID,"Андрей", "Андреев", "Андреевич", "Ул. Пушкина д.3", "+7505608155", "rabota@gmail.com", "Екатеринбург",
                date, "Женат", 123, 123, "Отсутствуют", "Мужской", "Не служил");
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }


        /// <summary>
        /// Тест на проверку удаления соискателя в БД
        /// </summary>
        [TestMethod]
        public void CheckDeleteSearcher_True()
        {
            Core db = new Core();
            int searcherID = db.context.SearchersInfo.Where(x => x.Name == "Андрей" && x.Surname == "Андреев" && x.Patronymic == "Андреевич" && x.Phone == "+7505608155").FirstOrDefault().IdSearcher;
            bool actual = ResumeVMLibrary.CheckDeleteSearcher(searcherID);
            bool excepted = true;
            Assert.AreEqual(excepted, actual);
        }
    }
}
