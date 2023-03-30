using eTickets.Data.Enums;
using eTickets.Models;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Actors
                if(!context.Actors.Any())
                {
                    context.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/anthony-hopkins.jpg",
                            FullName = "Anthony Hopkins",
                            Bio = "This is the Bio of the Anthony Hopkins"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/channing-tatum.jpg",
                            FullName = "Channing Tatum",
                            Bio = "This is the Bio of the Channing Tatum"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/chloe-grace-moretz.jpg",
                            FullName = "Chloe Grace Moretz",
                            Bio = "This is the Bio of the Chloe Grace Moretz"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/chris-tucker.jpg",
                            FullName = "Chris Tucker",
                            Bio = "This is the Bio of the Chris Tucker"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/jackie-chan.jpg",
                            FullName = "Jackie Chan",
                            Bio = "This is the Bio of the Jackie Chan"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/jack-nicholson.jpg",
                            FullName = "Jack Nicholson",
                            Bio = "This is the Bio of the Jack Nicholson"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/jodie-foster.jpg",
                            FullName = "Jodie Foster",
                            Bio = "This is the Bio of the Jodie Foster"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "/eTickets/wwwroot/images/actors/tom-hanks.jpg",
                            FullName = "Tom Hanks",
                            Bio = "This is the Bio of the Tom Hanks"
                        }
                    });
                    context.SaveChanges();
                }
                //Cinemas
                if (!context.Cinemas.Any())
                {
                    context.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            LogoUrl = "/eTickets/wwwroot/images/cinemas/cinema-1.jpg",
                            Name = "Cinema 1",
                            Description = "This is the Description of the Cinema 1"
                        },
                        new Cinema()
                        {
                            LogoUrl = "/eTickets/wwwroot/images/cinemas/cinema-2.jpg",
                            Name = "Cinema 2",
                            Description = "This is the Description of the Cinema 2"
                        },
                        new Cinema()
                        {
                            LogoUrl = "/eTickets/wwwroot/images/cinemas/cinema-3.jpg",
                            Name = "Cinema 3",
                            Description = "This is the Description of the Cinema 3"
                        },
                        new Cinema()
                        {
                            LogoUrl = "/eTickets/wwwroot/images/cinemas/cinema-4.jpg",
                            Name = "Cinema 4",
                            Description = "This is the Description of the Cinema 4"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/brett-ratner.jpg",
                            FullName = "Brett Ratner",
                            Bio = "This is the Bio of the Brett Ratner"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/jonathan-demme.jpg",
                            FullName = "Jonathan Demme",
                            Bio = "This is the Bio of the Jonathan Demme"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/robert-zemeckis.jpg",
                            FullName = "Robert Zemeckis",
                            Bio = "This is the Bio of the Robert Zemeckis"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/stanley-kubrick.jpg",
                            FullName = "Stanley Kubrick",
                            Bio = "This is the Bio of the Stanley Kubrick"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/stephen-sommers.jpg",
                            FullName = "Stephen Sommers",
                            Bio = "This is the Bio of the Stephen Sommers"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="/eTickets/wwwroot/images/producers/tim-story.jpg",
                            FullName = "Tim Story",
                            Bio = "This is the Bio of the Tim Story"
                        }

                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/forrest-gump-drama.jpg",
                            Title = "Forrest Gump",
                            Description = "This is the Description of the Forrest Gump movie",
                            StartDate = DateTime.Now.AddDays(0),
                            EndDate = DateTime.Now.AddDays(3),
                            Price = 22.99,
                            Category = MovieCategory.Drama,
                            CinemaId = 1,
                            ProducerId = 3
                        },
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/gi-joe-action.jpg",
                            Title = "G.I. Joe: the Rise of Cobra",
                            Description = "This is the Description of the G.I. Joe: the Rise of Cobra movie",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(6),
                            Price = 26.99,
                            Category = MovieCategory.Action,
                            CinemaId = 2,
                            ProducerId = 5
                        },
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/rush-hour-comedy.jpg",
                            Title = "Rush Hour",
                            Description = "This is the Description of the Rush Hour movie",
                            StartDate = DateTime.Now.AddDays(6),
                            EndDate = DateTime.Now.AddDays(9),
                            Price = 17.99,
                            Category = MovieCategory.Comedy,
                            CinemaId = 3,
                            ProducerId = 1
                        },
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/shining-horror.jpg",
                            Title = "The Shining",
                            Description = "This is the Description of the  movie",
                            StartDate = DateTime.Now.AddDays(9),
                            EndDate = DateTime.Now.AddDays(12),
                            Price = 22.99,
                            Category = MovieCategory.Horror,
                            CinemaId = 4,
                            ProducerId = 4
                        },
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/silence-of-the-lambs-thriller.jpg",
                            Title = "The Silence of the Lambs",
                            Description = "This is the Description of the The Silence of the Lambs movie",
                            StartDate = DateTime.Now.AddDays(12),
                            EndDate = DateTime.Now.AddDays(15),
                            Price = 29.99,
                            Category = MovieCategory.Thriller,
                            CinemaId = 1,
                            ProducerId = 2
                        },
                        new Movie()
                        {
                            ImageUrl = "/eTickets/wwwroot/images/movies/tom-and-herry-cartoon.jpg",
                            Title = "Tom and Jerry",
                            Description = "This is the Description of the Tom and Jerry movie",
                            StartDate = DateTime.Now.AddDays(15),
                            EndDate = DateTime.Now.AddDays(18),
                            Price = 10.99,
                            Category = MovieCategory.Cartoon,
                            CinemaId = 2,
                            ProducerId = 6
                        }
                    });
                    context.SaveChanges();
                }
                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {
                    context.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 8,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 6,
                            MovieId = 8
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 9
                        },
                        new Actor_Movie()
                        {
                            ActorId = 7,
                            MovieId = 9
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 10
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
