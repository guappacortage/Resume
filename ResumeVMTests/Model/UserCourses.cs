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
    
    public partial class UserCourses
    {
        public int IdUserCourse { get; set; }
        public int IdUser { get; set; }
        public string Course { get; set; }
        public System.DateTime CourseDate { get; set; }
    
        public virtual SearchersInfo SearchersInfo { get; set; }
    }
}
