//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wpf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Previous_jobs
    {
        public int id_user { get; set; }
        public string prev_job_first { get; set; }
        public System.DateTime date_of_start_first_prev_job { get; set; }
        public System.DateTime date_of_end_first_prev_job { get; set; }
        public string prev_job_second { get; set; }
        public System.DateTime date_of_start_second_prev_job { get; set; }
        public System.DateTime date_of_end_second_prev_job { get; set; }
    
        public virtual Searchers_Info Searchers_Info { get; set; }
    }
}
