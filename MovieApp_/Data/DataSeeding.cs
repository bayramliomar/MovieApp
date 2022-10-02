using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp_.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp_.Data
{
    public class DataSeeding
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();//dotnet ef database update

            var genres = new List<Genre>()
                           {
                                new Genre(){
                                    Name="Komedi",
                                    Movies=new List<Movie>()
                                    {
                                        new Movie()
                                        {
                                            Title="Recep İvedik 1",
                                            Description="Açıklama 1",
                                            ImagePath="1.jpg"
                                        },
                                        new Movie()
                                        {
                                            Title="Recep İvedik 2",
                                            Description="Açıklama 2",
                                            ImagePath="2.jpg"
                                        }
                                    }
                                },
                                new Genre(){
                                    Name="Drama"
                                },
                                new Genre(){
                                    Name="Korku"
                                },
                                new Genre(){
                                    Name="Bilim Kurgu"
                                },
                                new Genre(){
                                    Name="Macera"
                                },
                                new Genre(){
                                    Name="Aksiyon"
                                }
                           };
            var movies = new List<Movie>()
                            {
                                new Movie {
                                    Title="Jiu Jitsu",
                                    Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                    ImagePath="1.jpg",
                                    Genres=new List<Genre>{genres[0],genres[1]}
                                },
                                new Movie {
                                    Title="Fatman",
                                    Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                                    ImagePath="2.jpg",
                                     Genres=new List<Genre>{genres[1],genres[2]}
                                },
                                new Movie {
                                    Title="The Dalton Gang",
                                    Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                                    ImagePath="3.jpg",
                                     Genres=new List<Genre>{genres[2],genres[3]}
                                },
                                new Movie {
                                    Title="Tenet",
                                    Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                                    ImagePath="4.jpg",
                                     Genres=new List<Genre>{genres[3],genres[4]}
                                },
                                new Movie {
                                    Title="The Craft: Legacy",
                                    Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                                    ImagePath="5.jpg",
                                     Genres=new List<Genre>{genres[4],genres[5]}
                                },
                                new Movie {
                                    Title="Hard Kill",
                                    Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                                    ImagePath="6.jpg",
                                    Genres=new List<Genre>{genres[1],genres[4]}
                                }
                            };
            var users = new List<User>()
                            {
                                new User {
                                   Username="A1 Developer",
                                   Password="12345",
                                   ImagePath="1.jpg"
                                },
                                 new User {
                                   Username="A3 Developer",
                                   Password="12345",
                                   ImagePath="3.jpg"
                                }

                            };
            var people = new List<Person>()
            {
                new Person()
                {
                    Name = "Amir",
                    Surname = "Khan",
                    Imdb = "4.7",
                    PlaceOfBirth = "İndian",
                    User=users[0]
                },
                new Person()
                {
                    Name="Şahan",
                    Surname="Gökbakar",
                    PlaceOfBirth="Turkey",
                    Imdb="2.6",
                    User=new User()
                    {
                        Username="A2 Developer",
                        Password="123456",
                        ImagePath="2.jpg"
                    }
                }
            };
            var crews = new List<Crew>()
            {
               new Crew()
               {
                    Movie=movies[0],
                    Person=people[1],
                    Job="Yönetmen"
               },
                new Crew()
               {
                    Movie=movies[1],
                    Person=people[1],
                    Job="Yönetmen Yardımcısı"
               }
            };
            var casts = new List<Cast>()
            {
                new Cast()
                {
                    Movie=movies[0],
                    Person=people[0],
                    RoleName="Recep İvedik",
                    Character="Baş Rol"
                },
                 new Cast()
                {
                    Movie=movies[1],
                    Person=people[0],
                    RoleName="Recep İvedik",
                    Character="Baş Rol"
                }
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);
                }
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }
                if (context.Users.Count() == 0)
                {
                    context.Users.AddRange(users);
                }
                if (context.People.Count() == 0)
                {
                    context.People.AddRange(people);
                }
                if (context.Crews.Count() == 0)
                {
                    context.Crews.AddRange(crews);
                }
                if (context.Casts.Count() == 0)
                {
                    context.Casts.AddRange(casts);
                }
                context.SaveChanges();
            }
        }
    }
}
