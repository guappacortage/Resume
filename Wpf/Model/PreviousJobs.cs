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
    
    public partial class PreviousJobs
    {
        public int IdPrevJob { get; set; }
        public int IdSearcher { get; set; }
        public Nullable<System.DateTime> DateOfStartPreviousJob { get; set; }
        public Nullable<System.DateTime> DateOfEndPreviousJob { get; set; }
        public string NameOfPreviousJob { get; set; }
    
        public virtual SearchersInfo SearchersInfo { get; set; }
    }
}
