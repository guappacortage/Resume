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
