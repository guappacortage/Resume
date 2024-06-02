using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class SearcherInfoVM
    {
        Core db = new Core();

        public bool CheckCreateResume(string name, string surname, string patronymic, string adress, string phone, string email, string city, string familystatus, 
            string children, string army, string gender)
        {
            if (String.IsNullOrEmpty(name) || name.Any(char.IsDigit))
            {
                throw new Exception("Имя введено некорректно");
            }
            if (String.IsNullOrEmpty(surname) || surname.Any(char.IsDigit))
            {
                throw new Exception("Фамилия введена некорректно");
            }
            if (patronymic.Any(char.IsDigit))
            {
                throw new Exception("Отчество введено некорректно");
            }
            if (String.IsNullOrEmpty(adress))
            {
                throw new Exception("Адрес введен некорректно");
            }
            if (String.IsNullOrEmpty(phone) || !Regex.IsMatch(phone, @"^\+7\d{10}$"))
            {
                throw new Exception("Телефон введен некорректно");
            }
            if (String.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^(\S+)@([a-z0-9-]+)(\.)([a-z]{2,4})(\.?)([a-z]{0,4})+$"))
            {
                throw new Exception("Почта введена некорректно");
            }
            if (String.IsNullOrEmpty(city) || city.Any(char.IsDigit))
            {
                throw new Exception("Город введен некорректно");
            }
            if (String.IsNullOrEmpty(familystatus) || familystatus.Any(char.IsDigit))
            {
                throw new Exception("Семейное положение введено некорректно");
            }
            if (String.IsNullOrEmpty(children))
            {
                throw new Exception("Вы не указали наличие детей");
            }
            if (String.IsNullOrEmpty(gender))
            {
                throw new Exception("Вы не указали ваш пол");
            }
            if (String.IsNullOrEmpty(army) && gender == "Мужской")
            {
                throw new Exception("Вы не указали служили вы в армии или нет");
            }
            return true;
        }
        public void AddSearcher(string name, string surname, string patronymic, string adress, string phone, string email, string city, DateTime birthday, string familystatus,
            int passportseria, int passportnumber, string children, string gender, string army, string personal, string driverlicense, List<string> pastjobslisttext, List<DateTime> liststartdatejob, List<DateTime> listenddatejob,
            List<string> educationplacestext, List<DateTime> liststartdateeducationplaces, List<DateTime> listenddateeducationplaces, int idgrade, List<int> languagesid, List<string> coursetext,
            List<DateTime> coursedate, string skill, int idcategory, byte[] imagecode, bool checkimageadded)
        {
            SearchersInfo newSearcher = new SearchersInfo()
            {
                Name = name,
                Address = adress,
                Surname = surname,
                Patronymic = patronymic,
                Phone = phone,
                Email = email,
                City = city,
                Birthday = birthday,
                Army = army,
                FamilyStatus = familystatus,
                PassportSeria = passportseria,
                PassportNumber = passportnumber,
                Children = children,
                Gender = gender
            };
            db.context.SearchersInfo.Add(newSearcher);
            db.context.SaveChanges();
            int IdSearcher = newSearcher.IdSearcher;
            UserComputerSkillsVM newComputesSkills = new UserComputerSkillsVM();
            newComputesSkills.AddNewComputerSkills(IdSearcher, skill);
            AdditionalInfoVM addAdditionalInfo = new AdditionalInfoVM();
            addAdditionalInfo.AddNewAdditionalInfo(IdSearcher, personal, driverlicense);
            if (coursetext.Count > 0)
            {
                CoursesVM addCourses = new CoursesVM();
                addCourses.AddNewCourses(IdSearcher, coursetext, coursedate);
            }
            if (pastjobslisttext.Count > 0)
            {
                PreviousJobsVM addnewpastjob = new PreviousJobsVM();
                addnewpastjob.AddNewPastJobs(IdSearcher, pastjobslisttext, liststartdatejob, listenddatejob);
            }
            if (educationplacestext.Count > 0)
            {
                EducationPlacesVM addEdPlaces = new EducationPlacesVM();
                addEdPlaces.AddNewEducationPlaces(IdSearcher, educationplacestext, liststartdateeducationplaces, listenddateeducationplaces);
            }
            UserLanguagesVM newLanguage = new UserLanguagesVM();
            newLanguage.AddNewLanguages(IdSearcher, languagesid);
            UserEducationGradeVM addEdGrade = new UserEducationGradeVM();
            addEdGrade.AddNewEducationGrade(IdSearcher, idgrade);
            UserComputerSkillsVM computerSkills = new UserComputerSkillsVM();
            if (!String.IsNullOrEmpty(skill))
            {
                computerSkills.AddNewComputerSkills(IdSearcher, skill);
            }
            UserCategoriesVM newCategory = new UserCategoriesVM();
            newCategory.AddUserCategory(IdSearcher, idcategory);
            if (checkimageadded == true)
            {
                PhotoVM newPhoto = new PhotoVM();
                newPhoto.AddNewPhoto(IdSearcher, imagecode);
            }
            else
            {
                PhotoVM newPhoto = new PhotoVM();
                newPhoto.AddNewPhoto(IdSearcher, null);
            }
        }


        public void EditSearcher(int iduser, string name, string surname, string patronymic, string adress, string phone, string email, string city, DateTime birthday, string familystatus,
            int passportseria, int passportnumber, string children, string gender, string army, string personal, string driverlicense, List<string> pastjobslisttext, List<DateTime> liststartdatejob, List<DateTime> listenddatejob,
            List<string> educationplacestext, List<DateTime> liststartdateeducationplaces, List<DateTime> listenddateeducationplaces, int idgrade, List<int> languagesid, List<string> coursetext,
            List<DateTime> coursedate, string skill, int idcategory)
        {
            var objSearcher = db.context.SearchersInfo.Where(x => x.IdSearcher == iduser).FirstOrDefault();
            objSearcher.Name = name;
            objSearcher.Surname = surname;
            objSearcher.Patronymic = patronymic;
            objSearcher.Army = army;
            objSearcher.Gender = gender;
            objSearcher.Phone = phone;
            objSearcher.Birthday = birthday;
            objSearcher.Address = adress;
            objSearcher.City = city;
            objSearcher.Email = email;
            objSearcher.PassportNumber = passportnumber;
            objSearcher.Children = children;
            objSearcher.PassportSeria = passportseria;
            objSearcher.FamilyStatus = familystatus;
            db.context.SaveChanges();
            if (languagesid.Count > 0)
            {
                UserLanguagesVM newLanguage = new UserLanguagesVM();
                newLanguage.EditLanguages(iduser, languagesid);
            }
            UserComputerSkillsVM newComputerSkills = new UserComputerSkillsVM();
            newComputerSkills.EditComputerSkills(iduser, skill);
            AdditionalInfoVM newAddInfo = new AdditionalInfoVM();
            newAddInfo.EditAdditionalInfo(iduser, personal, driverlicense);
            if (coursetext.Count > 0)
            {
                CoursesVM newCourses = new CoursesVM();
                newCourses.EditCourses(iduser, coursetext, coursedate);
            }
            PreviousJobsVM newPastJobs = new PreviousJobsVM();
            newPastJobs.EditPastJobs(iduser, pastjobslisttext, liststartdatejob, listenddatejob);
            EducationPlacesVM newEducationPlaces = new EducationPlacesVM();
            newEducationPlaces.EditEducationPlaces(iduser, educationplacestext, liststartdateeducationplaces, listenddateeducationplaces);
            UserEducationGradeVM newEducationGrade = new UserEducationGradeVM();
            newEducationGrade.EditEducationGrade(iduser, idgrade);
            UserCategoriesVM newCategory = new UserCategoriesVM();
            newCategory.EditUserCategory(iduser, idcategory);
        }

        public void DeleteSearcher(int idSearcher)
        {
            var objSearchersinfo = db.context.SearchersInfo.Single(x => x.IdSearcher == idSearcher);
            db.context.SearchersInfo.Remove(objSearchersinfo);
            db.context.SaveChanges();
        }

        public void EditStatus(int idSearcher, int statusid)
        {
            var objSearchersinfo = db.context.SearchersInfo.Single(x => x.IdSearcher == idSearcher);
            objSearchersinfo.Status = statusid;
            CheckedResumeUsersVM checkedResumeUsers = new CheckedResumeUsersVM();
            checkedResumeUsers.AddNewCheckedResume(idSearcher, db.context.EmployersInfo.Where(x=> x.IdUser == Properties.Settings.Default.idClient).FirstOrDefault().IdEmployer);
            db.context.SaveChanges();
        }
    }
}
