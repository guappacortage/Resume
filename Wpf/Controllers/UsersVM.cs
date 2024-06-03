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
        /// <summary>
        /// Метод для проверки правильности логина и пароля
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
