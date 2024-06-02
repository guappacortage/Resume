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
