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
    
    public partial class Additional_info
    {
        public int id_user { get; set; }
        public string personal_qualities { get; set; }
        public string driver_license { get; set; }
    
        public virtual Searchers_Info Searchers_Info { get; set; }
    }
}
