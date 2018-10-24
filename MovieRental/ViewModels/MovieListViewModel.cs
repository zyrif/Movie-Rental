using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.ViewModels
{
    public class MovieListViewModel
    {
        public List<Movie> Movies { get; set; }
    }
}