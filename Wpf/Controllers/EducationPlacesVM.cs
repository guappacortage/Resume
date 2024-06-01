using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class EducationPlacesVM
    {
        Core db = new Core();
        public void AddNewEducationPlaces(int searherId, List<string> textseducationplaces, List<DateTime> liststarteducationplaces, List<DateTime> listendeducationplaces)
        {
            for (int i = 0; i < textseducationplaces.Count; i++)
            {
                EducationPlace newEducationPlace = new EducationPlace()
                {
                    IdUser = searherId,
                    PlaceOfEducation = textseducationplaces[i],
                    DateOfStartEducation = liststarteducationplaces[i],
                    DateOfEndEducation = listendeducationplaces[i]
                };
                db.context.EducationPlace.Add(newEducationPlace);
                db.context.SaveChanges();
            }
        }
        public void EditEducationPlaces(int searherId, List<string> textseducationplaces, List<DateTime> liststarteducationplaces, List<DateTime> listendeducationplaces)
        {
            var objEducationPlaces = db.context.EducationPlace.Where(x => x.IdUser == searherId).ToList();
            for (int i = 0; i < objEducationPlaces.Count; i++)
            {
                objEducationPlaces[i].PlaceOfEducation = textseducationplaces[i];
                objEducationPlaces[i].DateOfStartEducation = liststarteducationplaces[i];
                objEducationPlaces[i].DateOfEndEducation = listendeducationplaces[i];
            }
            db.context.SaveChanges();
        }
    }
}
