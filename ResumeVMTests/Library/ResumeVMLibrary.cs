using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ResumeVMTests.Model;

namespace ResumeVMTests.Library
{
    public class ResumeVMLibrary
    {
        public static bool CheckAuth(string username, string password)
        {
            Core db = new Core();
            if (String.IsNullOrEmpty(username))
            {
                throw new Exception("Вы не ввели логин.");
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Вы не ввели пароль.");
            }
            int checkClient = db.context.Users.Where(x => x.Username == username && x.Password == password).Count();
            if (checkClient == 0)
            {
                throw new Exception("Пользователь не найден.");
            }
            else
            {
                return true;
            }
        }
        public static bool CheckCreateSearcher(string name, string surname, string patronymic, string adress, string phone, string email, string city, DateTime birthday, string familystatus,
            int passportseria, int passportnumber, string children, string gender, string army)
        {
            Core db = new Core();
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
            if (db.context.SearchersInfo.Where(x => x.IdSearcher == newSearcher.IdSearcher).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckDeleteSearcher(int idSearcher)
        {
            Core db = new Core();
            var objSearchersinfo = db.context.SearchersInfo.Single(x => x.IdSearcher == idSearcher);
            db.context.SearchersInfo.Remove(objSearchersinfo);
            db.context.SaveChanges();
            if (db.context.SearchersInfo.Where(x => x.IdSearcher == idSearcher).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditSearcher(int iduser, string name, string surname, string patronymic, string adress, string phone, string email, string city, DateTime birthday, string familystatus,
            int passportseria, int passportnumber, string children, string gender, string army)
        {
            Core db = new Core();
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
            if (db.context.SearchersInfo.Where(x => x.IdSearcher == iduser && x.Surname == surname && x.Name == name && x.Patronymic == patronymic 
            && x.Address == adress && x.Phone == phone && x.Email == email && x.City == city).Count() > 0)
            {
                return true;    
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddUserCategory(int idSearcher, int categoryid)
        {
            Core db = new Core();
            UserCategories newUserCategories = new UserCategories()
            {
                IdSearcher = idSearcher,
                IdCategory = categoryid
            };
            db.context.UserCategories.Add(newUserCategories);
            db.context.SaveChanges();
            if (db.context.UserCategories.Where(x => x.IdSearcher == newUserCategories.IdSearcher).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditUserCategory(int idSearcher, int categoryid)
        {
            Core db = new Core();
            var objCategory = db.context.UserCategories.Where(x => x.IdSearcher == idSearcher).FirstOrDefault();
            objCategory.IdCategory = categoryid;
            db.context.SaveChanges();
            if (db.context.UserCategories.Where(x => x.IdSearcher == idSearcher && x.IdCategory == categoryid).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddUserCourse(int iduser, List<string> courseslist, List<DateTime> datecourseslist)
        {
            Core db = new Core();
            for (int i = 0; i < courseslist.Count; i++)
            {
                UserCourses newCourse = new UserCourses()
                {
                    IdSearcher = iduser,
                    Course = courseslist[i],
                    CourseDate = datecourseslist[i]
                };
                db.context.UserCourses.Add(newCourse);
                db.context.SaveChanges();
            }
            if (db.context.UserCourses.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditUserCourse(int iduser, List<string> courseslist, List<DateTime> datecourseslist)
        {
            Core db = new Core();
            var objCourses = db.context.UserCourses.Where(x => x.IdSearcher == iduser).ToList();
            for (int i = 0; i < objCourses.Count; i++)
            {
                objCourses[i].Course = courseslist[i];
                objCourses[i].CourseDate = datecourseslist[i];
            }
            db.context.SaveChanges();
            string checkcourse = courseslist[0];
            if (db.context.UserCourses.Where(x => x.Course == checkcourse).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddEducationPlace(int searherId, List<string> textseducationplaces, List<DateTime> liststarteducationplaces, List<DateTime> listendeducationplaces)
        {
            Core db = new Core();
            for (int i = 0; i < textseducationplaces.Count; i++)
            {
                EducationPlace newEducationPlace = new EducationPlace()
                {
                    IdSearcher = searherId,
                    PlaceOfEducation = textseducationplaces[i],
                    DateOfStartEducation = liststarteducationplaces[i],
                    DateOfEndEducation = listendeducationplaces[i]
                };
                db.context.EducationPlace.Add(newEducationPlace);
                db.context.SaveChanges();
            }
            if (db.context.EducationPlace.Where(x => x.IdSearcher == searherId).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditEducationPlace(int searherId, List<string> textseducationplaces, List<DateTime> liststarteducationplaces, List<DateTime> listendeducationplaces)
        {
            Core db = new Core();
            var objEducationPlaces = db.context.EducationPlace.Where(x => x.IdSearcher == searherId).ToList();
            for (int i = 0; i < objEducationPlaces.Count; i++)
            {
                objEducationPlaces[i].PlaceOfEducation = textseducationplaces[i];
                objEducationPlaces[i].DateOfStartEducation = liststarteducationplaces[i];
                objEducationPlaces[i].DateOfEndEducation = listendeducationplaces[i];
            }
            db.context.SaveChanges();
            string educationplace = textseducationplaces[0];
            if (db.context.EducationPlace.Where(x => x.IdSearcher == searherId && x.PlaceOfEducation == educationplace).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddPastJob(int searherId, List<string> textspastjobs, List<DateTime> liststartjob, List<DateTime> listendjob)
        {
            Core db = new Core();
            for (int i = 0; i < textspastjobs.Count; i++)
            {
                PreviousJobs newPastJob = new PreviousJobs()
                {
                    IdSearcher = searherId,
                    NameOfPreviousJob = textspastjobs[i],
                    DateOfStartPreviousJob = liststartjob[i],
                    DateOfEndPreviousJob = listendjob[i]
                };
                db.context.PreviousJobs.Add(newPastJob);
                db.context.SaveChanges();
            }
            if (db.context.PreviousJobs.Where(x => x.IdSearcher == searherId).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditPastJobs(int searherId, List<string> textspastjobs, List<DateTime> liststartjob, List<DateTime> listendjob)
        {
            Core db = new Core();
            var objPastJobs = db.context.PreviousJobs.Where(x => x.IdSearcher == searherId).ToList();
            for (int i = 0; i < objPastJobs.Count; i++)
            {
                objPastJobs[i].NameOfPreviousJob = textspastjobs[i];
                objPastJobs[i].DateOfStartPreviousJob = liststartjob[i];
                objPastJobs[i].DateOfEndPreviousJob = listendjob[i];
            }
            db.context.SaveChanges();
            if (db.context.PreviousJobs.Where(x => x.IdSearcher == searherId && x.NameOfPreviousJob == textspastjobs[0]).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddPhotoLink(int iduser, byte[] imagecode)
        {
            Core db = new Core();
            LinkForPhoto newPhoto = new LinkForPhoto()
            {
                IdSearcher = iduser,
                PhotoLink = imagecode
            };
            db.context.LinkForPhoto.Add(newPhoto);
            db.context.SaveChanges();
            if (db.context.LinkForPhoto.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddNewAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            Core db = new Core();
            AdditionalInfo newAdditionalInfo = new AdditionalInfo()
            {
                IdSearcher = iduser,
                PersonalQualities = personal,
                DriverLicense = driverlicense
            };
            db.context.AdditionalInfo.Add(newAdditionalInfo);
            db.context.SaveChanges();
            if (db.context.AdditionalInfo.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            Core db = new Core();
            var objAddInfo = db.context.AdditionalInfo.Where(x => x.IdSearcher == iduser).SingleOrDefault();
            if (objAddInfo != null)
            {
                objAddInfo.DriverLicense = driverlicense;
                objAddInfo.PersonalQualities = personal;
            }
            else
            {
                AdditionalInfo newAdditionalInfo = new AdditionalInfo()
                {
                    IdSearcher = iduser,
                    PersonalQualities = personal,
                    DriverLicense = driverlicense
                };
                db.context.AdditionalInfo.Add(newAdditionalInfo);
            }
            db.context.SaveChanges();
            if (db.context.AdditionalInfo.Where(x => x.IdSearcher == iduser && x.PersonalQualities == personal).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddCheckedResume(int iduser, int idemployer)
        {
            Core db = new Core();
            CheckedResumeUsers checkedResumeUsers = new CheckedResumeUsers()
            {
                IdSearcher = iduser,
                IdEmployer = idemployer,
            };
            db.context.CheckedResumeUsers.Add(checkedResumeUsers);
            db.context.SaveChanges();
            if (db.context.CheckedResumeUsers.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                db.context.CheckedResumeUsers.Remove(checkedResumeUsers);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddEmployer(string nameoforganization, string login, string password)
        {
            Core db = new Core();
            EmployersInfo employersInfo = new EmployersInfo()
            {
                NameOfOrganization = nameoforganization
            };
            db.context.EmployersInfo.Add(employersInfo);
            Users newUser = new Users()
            {
                RoleId = 2,
                Username = login,
                Password = password
            };
            db.context.Users.Add(newUser);
            db.context.SaveChanges();
            if (db.context.EmployersInfo.Where(x => x.IdUser == employersInfo.IdUser).Count() > 0 && db.context.Users.Where(x => x.IdUser == newUser.IdUser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddComputerSkill(int iduser, string skill)
        {
            Core db = new Core();
            UserComputerSkills newUser = new UserComputerSkills()
            {
                IdSearcher = iduser,
                ComputerSkill = skill
            };
            db.context.UserComputerSkills.Add(newUser);
            db.context.SaveChanges();
            if (db.context.UserComputerSkills.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditComputerSkill(int iduser, string skill)
        {
            Core db = new Core();
            var objComputerSkills = db.context.UserComputerSkills.Where(x => x.IdSearcher == iduser).SingleOrDefault();
            if (objComputerSkills != null)
            {
                objComputerSkills.ComputerSkill = skill;
            }
            else
            {
                UserComputerSkills newComputerSkill = new UserComputerSkills()
                {
                    IdSearcher = iduser,
                    ComputerSkill = skill
                };
                db.context.UserComputerSkills.Add(newComputerSkill);
            }
            db.context.SaveChanges();
            if (db.context.UserComputerSkills.Where(x => x.IdSearcher == iduser && x.ComputerSkill == skill).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddEducationGrade(int iduser, int ideducationgrade)
        {
            Core db = new Core();
            UserEducationGrade newEducationGrade = new UserEducationGrade()
            {
                IdSearcher = iduser,
                IdEducationGrade = ideducationgrade
            };
            db.context.UserEducationGrade.Add(newEducationGrade);
            db.context.SaveChanges();
            if (db.context.UserEducationGrade.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditEducationGrade(int iduser, int ideducationgrade)
        {
            Core db = new Core();
            var objEducationGrade = db.context.UserEducationGrade.Where(x => x.IdSearcher == iduser).FirstOrDefault();
            objEducationGrade.IdEducationGrade = ideducationgrade;
            db.context.SaveChanges();
            if (db.context.UserEducationGrade.Where(x => x.IdSearcher == iduser && x.IdEducationGrade == ideducationgrade).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckAddUserLanguages(int iduser, List<int> languageidslist)
        {
            Core db = new Core();
            foreach (int languageid in languageidslist)
            {
                UserLanguages newUser = new UserLanguages()
                {
                    IdSearcher = iduser,
                    LanguagesId = languageid
                };
                db.context.UserLanguages.Add(newUser);
                db.context.SaveChanges();
            }
            if (db.context.UserLanguages.Where(x => x.IdSearcher == iduser).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEditUserLanguages(int iduser, List<int> languageidslist)
        {
            Core db = new Core();
            var objLanguages = db.context.UserLanguages.Where(x => x.IdSearcher == iduser).ToList();
            for (int i = 0; i < objLanguages.Count; i++)
            {
                objLanguages[i].LanguagesId = languageidslist[i];
            }
            db.context.SaveChanges();
            int language = languageidslist[0];
            if (db.context.UserLanguages.Where(x => x.IdSearcher == iduser && x.LanguagesId == language).Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
