using MovieApp_.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp_.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;
        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie {
                    ID=1,
                    Title="Jiu Jitsu",
                    Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                    Director="Dimitri Logothetis",
                    Players=new string[] { "Nicolas Cage", "Alain Moussi"},
                    ImagePath="1.jpg",
                    GenreID=1
                },
                new Movie {
                    ID=2,
                    Title="Fatman",
                    Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                    Director="Eshom Nelms",
                    Players=new string[] { "Mel Gibson", "Walton Goggins","Michelle Lan"},
                    ImagePath="2.jpg",
                    GenreID=2
                },
                new Movie {
                    ID=3,
                    Title="The Dalton Gang",
                    Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                    Director="Christopher Forbes",
                    Players=new string[] { "oyuncu 1","oyuncu 2"},
                    ImagePath="3.jpg",
                    GenreID=3
                },
                new Movie {
                    ID=4,
                    Title="Tenet",
                    Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                    Director="Christopher Nolan",
                    Players=new string[] { "Robert Pattinson", "Elizabeth Debicki"},
                    ImagePath="4.jpg",
                    GenreID=4
                },
                new Movie {
                    ID=5,
                    Title="The Craft: Legacy",
                    Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                    Director="Zoe Lister-Jones",
                    Players=new string[] { "Cailee Spaeny", "Zoey Luna"},
                    ImagePath="5.jpg",
                    GenreID=2
                },
                new Movie {
                    ID=6,
                    Title="Hard Kill",
                    Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                    Director="Matt Eskandari",
                    Players=new string[] { "Bruce Willis", "Jesse Metcalfe"},
                    ImagePath="6.jpg",
                    GenreID=1
                }
            };
        }

        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }

        public static void Add(Movie model)
        {
            model.ID = _movies.Count+1;
            _movies.Add(model);
        }

        public static void Remove(int id)
        {
            var model = GetById(id);
            _movies.Remove(model);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.ID == id);
        }

        public static List<Movie> GetByGenreId(int id)
        {
            return _movies.Where(x => x.GenreID == id).ToList();
        }

        public static List<Movie> Search(string query)
        {
            return _movies.Where(x => x.Title.ToLower().Contains(query.ToLower()) || x.Description.ToLower().Contains(query.ToLower())).ToList();
        }

        public static void Edit(Movie model)
        {
            var data = GetById(model.ID);
            data.Title = model.Title;
            data.Description = model.Description;
            data.Director = model.Director;
            data.ImagePath = model.ImagePath;
            data.GenreID = model.GenreID;
        }
    }
}
