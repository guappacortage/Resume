﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class AdditionalInfoVM
    {
        Core db = new Core();
        /// <summary>
        /// Метод для добавления дополнительной информации
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="personal">Личные качества</param>
        /// <param name="driverlicense">Водительская лицензия</param>
        public void AddNewAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            AdditionalInfo newAdditionalInfo = new AdditionalInfo()
            {
                IdSearcher = iduser,
                PersonalQualities = personal,
                DriverLicense = driverlicense
            };
            db.context.AdditionalInfo.Add(newAdditionalInfo);
            db.context.SaveChanges();
        }
        /// <summary>
        /// Метод для изменения дополнительной информации
        /// </summary>
        /// <param name="iduser">ID соискателя</param>
        /// <param name="personal">Личные качества</param>
        /// <param name="driverlicense">Водительская лицензия</param>
        public void EditAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            var objAddInfo = db.context.AdditionalInfo.Where(x => x.IdSearcher == iduser).SingleOrDefault();
            if (objAddInfo != null)
            {
                objAddInfo.DriverLicense = driverlicense;
                objAddInfo.PersonalQualities = personal;
            }
            else
            {
                AdditionalInfo newAdditionalInfo = new AdditionalInfo()
                {
                    IdSearcher = iduser,
                    PersonalQualities = personal,
                    DriverLicense = driverlicense
                };
                db.context.AdditionalInfo.Add(newAdditionalInfo);
            }
            db.context.SaveChanges();
        }
    }
}
