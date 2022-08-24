using System.Collections.Generic;

namespace MovieApp_.Entities
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
