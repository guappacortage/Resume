using System;
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

        public void AddNewAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            AdditionalInfo newAdditionalInfo = new AdditionalInfo()
            {
                IdUser = iduser,
                PersonalQualities = personal,
                DriverLicense = driverlicense
            };
            db.context.AdditionalInfo.Add(newAdditionalInfo);
            db.context.SaveChanges();
        }

        public void EditAdditionalInfo(int iduser, string personal, string driverlicense)
        {
            var objAddInfo = db.context.AdditionalInfo.Where(x => x.IdUser == iduser).SingleOrDefault();
            if (objAddInfo != null)
            {
                objAddInfo.DriverLicense = driverlicense;
                objAddInfo.PersonalQualities = personal;
            }
            else
            {
                AdditionalInfo newAdditionalInfo = new AdditionalInfo()
                {
                    IdUser = iduser,
                    PersonalQualities = personal,
                    DriverLicense = driverlicense
                };
                db.context.AdditionalInfo.Add(newAdditionalInfo);
            }
            db.context.SaveChanges();
        }
    }
}
