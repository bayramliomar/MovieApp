using System.ComponentModel;

namespace MovieApp_.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Players { get; set; }
        public string ImagePath { get; set; }
        public int GenreID { get; set; }
    }
}
