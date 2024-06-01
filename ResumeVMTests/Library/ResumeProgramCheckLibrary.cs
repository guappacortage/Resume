using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResumeVMTests.Library
{
    public class ResumeProgramCheckLibrary
    {
        public static bool CheckCreateResume(string name, string surname, string patronymic, string adress, string phone, string email, string city, string familystatus)
        {
            if (String.IsNullOrEmpty(name) || name.Any(char.IsDigit))
            {
                throw new Exception("Имя введено некорректно");
            }
            if (String.IsNullOrEmpty(surname) || surname.Any(char.IsDigit))
            {
                throw new Exception("Фамилия введена некорректно");
            }
            if (patronymic.Any(char.IsDigit))
            {
                throw new Exception("Отчество введено некорректно");
            }
            if (String.IsNullOrEmpty(adress))
            {
                throw new Exception("Адрес введен некорректно");
            }
            if (String.IsNullOrEmpty(phone) || !Regex.IsMatch(phone, @"^\+7\d{10}$"))
            {
                throw new Exception("Телефон введен некорректно");
            }
            if (String.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^(\S+)@([a-z0-9-]+)(\.)([a-z]{2,4})(\.?)([a-z]{0,4})+$"))
            {
                throw new Exception("Почта введена некорректно");
            }
            if (String.IsNullOrEmpty(city) || city.Any(char.IsDigit))
            {
                throw new Exception("Город введен некорректно");
            }
            if (String.IsNullOrEmpty(familystatus) || familystatus.Any(char.IsDigit))
            {
                throw new Exception("Семейное положение введено некорректно");
            }
            return true;
        }
    }
}
