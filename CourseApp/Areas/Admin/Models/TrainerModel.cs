using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseApp.Areas.Admin.Models
{
    public class TrainerModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage =" Please , Write email in correct forrmate")]
        public string Email { get; set; }
        [Url(ErrorMessage =" Please , Write correct URL")]
        public string Website { get; set; }
        [StringLength(250,MinimumLength =10)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}