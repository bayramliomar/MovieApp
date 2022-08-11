using MovieApp_.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp_.Data
{
    public class JenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static JenreRepository()
        {
            _genres = new List<Genre>()
            {
                 new Genre(){
                    ID=1,
                    Name="Komedi"
                },
                new Genre(){
                    ID=2,
                    Name="Drama"
                },
                new Genre(){
                    ID=3,
                    Name="Korku"
                },
                new Genre(){
                    ID=4,
                    Name="Bilim Kurgu"
                },
                new Genre(){
                    ID=5,
                    Name="Romantik Komedi"
                }
            };
        }

        public static List<Genre> Genres
        {
            get
            {
                return _genres;
            }
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(x => x.ID == id);
        }
    }
}
