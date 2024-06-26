﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class UserCoursesVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для добавления курсов выбранных пользователем
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="courseslist">Список курсов</param>
        /// <param name="datecourseslist">Список дат прохождения курсов</param>
        public void AddNewCourses(int iduser, List<string> courseslist, List<DateTime> datecourseslist)
        {
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
        }
        /// <summary>
        /// Метод для изменения курсов выбранных пользователем
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="courseslist">Список курсов</param>
        /// <param name="datecourseslist">Список дат прохождения курсов</param>
        public void EditCourses(int iduser, List<string> courseslist, List<DateTime> datecourseslist)
        {
            var objCourses = db.context.UserCourses.Where(x => x.IdSearcher == iduser).ToList();
            for (int i = 0; i < objCourses.Count; i++)
            {
                objCourses[i].Course = courseslist[i];
                objCourses[i].CourseDate = datecourseslist[i];
            }
            db.context.SaveChanges();
        }
    }
}
