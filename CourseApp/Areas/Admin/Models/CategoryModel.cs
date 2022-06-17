using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseApp.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =10,ErrorMessage ="Category Name Should be 10 : 100 ")]
        public string Name { get; set; }
        public int ?ParentId { get; set; }
        public string ParentName { get; set; }

        public SelectList MainCategories { get; set; }


    }
}