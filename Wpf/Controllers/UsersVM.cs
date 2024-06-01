using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    internal class UsersVM
    {
        Core db = new Core();
        public bool CheckAuth(string username, string password)
        {

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
    }
}
