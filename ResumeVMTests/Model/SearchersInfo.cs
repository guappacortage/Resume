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
    
    public partial class SearchersInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SearchersInfo()
        {
            this.AdditionalInfo = new HashSet<AdditionalInfo>();
            this.CheckedResumeUsers = new HashSet<CheckedResumeUsers>();
            this.EducationPlace = new HashSet<EducationPlace>();
            this.LinkForPhoto = new HashSet<LinkForPhoto>();
            this.PreviousJobs = new HashSet<PreviousJobs>();
            this.UserCategories = new HashSet<UserCategories>();
            this.UserComputerSkills = new HashSet<UserComputerSkills>();
            this.UserCourses = new HashSet<UserCourses>();
            this.UserEducationGrade = new HashSet<UserEducationGrade>();
            this.UserLanguages = new HashSet<UserLanguages>();
        }
    
        public int IdSearcher { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public System.DateTime Birthday { get; set; }
        public string FamilyStatus { get; set; }
        public string Children { get; set; }
        public string Army { get; set; }
        public int PassportSeria { get; set; }
        public int PassportNumber { get; set; }
        public Nullable<int> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdditionalInfo> AdditionalInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckedResumeUsers> CheckedResumeUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EducationPlace> EducationPlace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkForPhoto> LinkForPhoto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PreviousJobs> PreviousJobs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCategories> UserCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserComputerSkills> UserComputerSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCourses> UserCourses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserEducationGrade> UserEducationGrade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLanguages> UserLanguages { get; set; }
    }
}
