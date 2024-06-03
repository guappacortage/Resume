using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class CheckedResumeUsersVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для добавления нового резюме отмеченного как подходящее работодателю
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="idemployer">ID работодателя</param>
        public void AddNewCheckedResume(int iduser, int idemployer)
        {
            CheckedResumeUsers checkedResumeUsers = new CheckedResumeUsers()
            {
                IdSearcher = iduser,
                IdEmployer = idemployer,
            };
            db.context.CheckedResumeUsers.Add(checkedResumeUsers);
            db.context.SaveChanges();
        }
    }
}
