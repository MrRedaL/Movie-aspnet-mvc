﻿using AspNetCoreMvcApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcApp.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Actor Image")]
        [Required(ErrorMessage = "Actor Image is required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set;}

        //relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }
    }
}
