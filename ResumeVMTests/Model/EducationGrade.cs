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
    
    public partial class EducationGrade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EducationGrade()
        {
            this.UserEducationGrade = new HashSet<UserEducationGrade>();
        }
    
        public int IdEducationGrade { get; set; }
        public string GradeOfEducation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEducationGrade> UserEducationGrade { get; set; }
    }
}
