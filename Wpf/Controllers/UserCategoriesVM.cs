﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class UserCategoriesVM
    {
        Core db = new Core();
        public void AddUserCategory (int iduser, int categoryid)    
        {
            UserCategories newUserCategories = new UserCategories()
            {
                IdSearcher = iduser,
                IdCategory = categoryid
            };
            db.context.UserCategories.Add(newUserCategories);
            db.context.SaveChanges();
        }

        public void EditUserCategory(int iduser, int categoryid)
        {
            var objCategory = db.context.UserCategories.Where(x => x.IdSearcher == iduser).FirstOrDefault();
            objCategory.IdCategory = categoryid;
            db.context.SaveChanges();
        }

    }
}
