﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Data.Enums;

namespace AspNetCoreMvcApp.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public double Price { get; set; }
        public MovieCategory Category { get; set; }

        //Relationships
        public List<Actor_Movie>? Actors_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
