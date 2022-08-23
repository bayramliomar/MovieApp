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

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(
                        new List<Movie>()
                            {
                                new Movie {
                                    Title="Jiu Jitsu",
                                    Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                    ImagePath="1.jpg",
                                    GenreID=1
                                },
                                new Movie {
                                    Title="Fatman",
                                    Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                                    ImagePath="2.jpg",
                                    GenreID=2
                                },
                                new Movie {
                                    Title="The Dalton Gang",
                                    Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                                    ImagePath="3.jpg",
                                    GenreID=3
                                },
                                new Movie {
                                    Title="Tenet",
                                    Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                                    ImagePath="4.jpg",
                                    GenreID=4
                                },
                                new Movie {
                                    Title="The Craft: Legacy",
                                    Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                                    ImagePath="5.jpg",
                                    GenreID=2
                                },
                                new Movie {
                                    Title="Hard Kill",
                                    Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                                    ImagePath="6.jpg",
                                    GenreID=1
                                }
                            }
                        );
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(
                           new List<Genre>()
                           {
                                new Genre(){
                                    Name="Komedi"
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
                           }
                        );
                }
                context.SaveChanges();
            }
            else
            {
                context.Database.Migrate();
            }
        }
    }
}
