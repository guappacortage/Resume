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
    
    public partial class UserCategories
    {
        public int IdUserCategory { get; set; }
        public int IdSearcher { get; set; }
        public int IdCategory { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual SearchersInfo SearchersInfo { get; set; }
    }
}
