using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class UserLanguagesVM
    {
       Core db = new Core();
        /// <summary>
        /// Метод для добавления языков, которые выбрал пользователь
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="languageidslist">Список с ID языков</param>
        public void AddNewLanguages(int iduser, List<int> languageidslist)
       {
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
       }
        /// <summary>
        /// Метод для изменения языков, которые выбрал пользователь
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="languageidslist">Список с ID языков</param>
        public void EditLanguages(int iduser, List<int> languageidslist)
       {
            var objLanguages = db.context.UserLanguages.Where(x => x.IdSearcher == iduser).ToList();
            for (int i = 0; i<objLanguages.Count; i++)
            {
                objLanguages[i].LanguagesId = languageidslist[i];
            }
            db.context.SaveChanges();
       }
    }
}
