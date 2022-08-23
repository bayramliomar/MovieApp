using MovieApp_.Entities;
using System.Collections.Generic;

namespace MovieApp_.Models
{
    public class MovieViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
