using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class UserEducationGradeVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для добавления уровня образования пользователя
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="ideducationgrade">ID уровня образования</param>
        public void AddNewEducationGrade(int iduser, int ideducationgrade) 
        {
            UserEducationGrade newEducationGrade = new UserEducationGrade()
            {
                IdSearcher = iduser,
                IdEducationGrade = ideducationgrade
            };
            db.context.UserEducationGrade.Add(newEducationGrade);
            db.context.SaveChanges();
        }
        /// <summary>
        /// Метод для изменения уровня образования пользователя
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="ideducationgrade">ID уровня образования</param>
        public void EditEducationGrade(int iduser, int ideducationgrade)
        {
            var objEducationGrade = db.context.UserEducationGrade.Where(x => x.IdSearcher == iduser).FirstOrDefault();
            objEducationGrade.IdEducationGrade = ideducationgrade;
            db.context.SaveChanges();
        }
    }
}
