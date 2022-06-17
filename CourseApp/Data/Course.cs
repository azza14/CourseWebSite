//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.CourseLessons = new HashSet<CourseLesson>();
            this.TraineeCourses = new HashSet<TraineeCourse>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int TrainerId { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseLesson> CourseLessons { get; set; }
        public virtual Trainer Trainer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraineeCourse> TraineeCourses { get; set; }
    }
}