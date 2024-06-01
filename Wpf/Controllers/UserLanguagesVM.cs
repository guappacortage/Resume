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
       public void AddNewLanguages(int iduser, List<int> languageidslist)
       {
            foreach (int languageid in languageidslist)
            {
                UserLanguages newUser = new UserLanguages()
                {
                    UserId = iduser,
                    LanguagesId = languageid
                };
                db.context.UserLanguages.Add(newUser);
                db.context.SaveChanges();
            }
       }
       public void EditLanguages(int iduser, List<int> languageidslist)
       {
            var objLanguages = db.context.UserLanguages.Where(x => x.UserId == iduser).ToList();
            for (int i = 0; i<objLanguages.Count; i++)
            {
                objLanguages[i].LanguagesId = languageidslist[i];
            }
            db.context.SaveChanges();
       }
    }
}
