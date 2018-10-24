using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.AccessControl;
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
        public byte GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public byte NumberInStock { get; set; }

    }
}