using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Web;

namespace MovieRental.Models
{
    public class Movie
    {   
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required]
        [DisplayName("Genre")]
        public byte GenreId { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [DisplayName("Number in Stock")]
        public byte NumberInStock { get; set; }

    }
}