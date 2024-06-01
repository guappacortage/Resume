using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Model;

namespace Wpf.Controllers
{
    public class PreviousJobsVM
    {
        Core db = new Core();
        public void AddNewPastJobs(int searherId, List<string> textspastjobs, List<DateTime> liststartjob, List<DateTime> listendjob)
        {
            for (int i = 0; i < textspastjobs.Count; i++)
            {
                PreviousJobs newPastJob = new PreviousJobs()
                {
                    IdUser = searherId,
                    NameOfPreviousJob = textspastjobs[i],
                    DateOfStartPreviousJob = liststartjob[i],
                    DateOfEndPreviousJob = listendjob[i]
                };
                db.context.PreviousJobs.Add(newPastJob);
                db.context.SaveChanges();
            }
        }
        public void EditPastJobs(int iduser, List<string> textspastjobs, List<DateTime> liststartjob, List<DateTime> listendjob)
        {
            var objPastJobs = db.context.PreviousJobs.Where(x => x.IdUser == iduser).ToList();
            for (int i = 0; i < objPastJobs.Count; i++)
            {
                objPastJobs[i].NameOfPreviousJob = textspastjobs[i];
                objPastJobs[i].DateOfStartPreviousJob = liststartjob[i];
                objPastJobs[i].DateOfEndPreviousJob = listendjob[i];
            }
            db.context.SaveChanges();
        }
    }
}
