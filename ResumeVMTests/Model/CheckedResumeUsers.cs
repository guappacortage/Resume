//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResumeVMTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CheckedResumeUsers
    {
        public int IdUserChecked { get; set; }
        public int IdEmployer { get; set; }
        public int IdSearcher { get; set; }
    
        public virtual EmployersInfo EmployersInfo { get; set; }
        public virtual SearchersInfo SearchersInfo { get; set; }
    }
}
