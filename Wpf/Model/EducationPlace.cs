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
    
    public partial class EducationPlace
    {
        public int IdEducatePlace { get; set; }
        public int IdSearcher { get; set; }
        public string PlaceOfEducation { get; set; }
        public Nullable<System.DateTime> DateOfStartEducation { get; set; }
        public Nullable<System.DateTime> DateOfEndEducation { get; set; }
    
        public virtual SearchersInfo SearchersInfo { get; set; }
    }
}
