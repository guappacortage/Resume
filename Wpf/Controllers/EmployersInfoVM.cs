using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class EmployersInfoVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для проверки ввода полей при добавлении работодателя
        /// </summary>
        /// <param name="nameoforganization">Название организации</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool EmployerCheck(string nameoforganization, string login, string password)
        {
            if (String.IsNullOrEmpty(nameoforganization))
            {
                throw new Exception("Вы не ввели название организации");
            }
            if (String.IsNullOrEmpty(login))
            {
                throw new Exception("Вы не ввели логин работодателя");
            }
            if (String.IsNullOrEmpty(password))
            {
                throw new Exception("Вы не ввели пароль работодателя");
            }
            return true;
        }

        /// <summary>
        /// Метод для добавления работодателя
        /// </summary>
        /// <param name="nameoforganization">Название организации</param>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        public void AddNewEmployer(string nameoforganization, string login, string password)
        {
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
        }
    }
}
