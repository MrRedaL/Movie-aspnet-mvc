using AspNetCoreMvcApp.Data.Enums;
using AspNetCoreMvcApp.Models;
using Microsoft.Extensions.Hosting.Internal;
using System.Reflection;

namespace AspNetCoreMvcApp.Data
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
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/cc7027dd-3b47-4fe1-92b6-0c633b7ce9b5/280x420",
                            FullName = "Anthony Hopkins",
                            Bio = "This is the Bio of the Anthony Hopkins"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/f7972756-eee0-4a34-81af-280d6ca0e0af/280x420",
                            FullName = "Channing Tatum",
                            Bio = "This is the Bio of the Channing Tatum"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1629390/c8660bfe-604c-4aa0-b284-7dcdb263297e/280x420",
                            FullName = "Chloe Grace Moretz",
                            Bio = "This is the Bio of the Chloe Grace Moretz"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/a51add63-a707-4f73-988a-56ee9c3f5e30/280x420",
                            FullName = "Chris Tucker",
                            Bio = "This is the Bio of the Chris Tucker"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/a5f2476b-542e-47f4-bf2c-e8a803953400/280x420",
                            FullName = "Jackie Chan",
                            Bio = "This is the Bio of the Jackie Chan"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1773646/57344f8d-5272-4ea5-b5ca-6b7df0ff59ae/280x420",
                            FullName = "Jack Nicholson",
                            Bio = "This is the Bio of the Jack Nicholson"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/626fe579-c0c1-41a9-ad53-93cbca6ff27c/280x420",
                            FullName = "Jodie Foster",
                            Bio = "This is the Bio of the Jodie Foster"
                        },
                        new Actor()
                        {
                            ProfilePictureUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1773646/3acd328c-721a-47ac-a7bf-fe7d5efb69fc/280x420",
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
                            LogoUrl = "https://img.freepik.com/premium-vector/initial-letter-c-with-filmstripes-movie-production-logo_57043-491.jpg?w=826",
                            Name = "Creative Cinema",
                            Description = "This is the Description of the Creative Cinema"
                        },
                        new Cinema()
                        {
                            LogoUrl = "https://img.freepik.com/free-vector/movie-time-neon-sign-sign_24908-55542.jpg?w=826&t=st=1680258690~exp=1680259290~hmac=2b1e622ec232621e2b245711a4e9692a7ff6011cfdde5ecaec1f6779c166bde6",
                            Name = "Cinema",
                            Description = "This is the Description of the Cinema"
                        },
                        new Cinema()
                        {
                            LogoUrl = "https://img.freepik.com/free-vector/movie-time-neon-sign-sign_24908-55555.jpg?w=826&t=st=1680258693~exp=1680259293~hmac=bdfc52ca3639c3364387e7235c27e10d1c6d8812b77413c237d70e0fb68c0ec2",
                            Name = "Movie Time",
                            Description = "This is the Description of the Movie Time"
                        },
                        new Cinema()
                        {
                            LogoUrl = "https://img.freepik.com/premium-vector/cinema-night-neon-sign-design-element-light-banner-announcement-neon-signboard_77399-1295.jpg?w=826",
                            Name = "Cinema Night",
                            Description = "This is the Description of the Cinema Night"
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
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/34eed8b6-b64b-4d34-825b-44448a7b2c56/280x420",
                            FullName = "Brett Ratner",
                            Bio = "This is the Bio of the Brett Ratner"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/089955f1-d1c5-4914-a2fa-a3019f1efe05/280x420",
                            FullName = "Jonathan Demme",
                            Bio = "This is the Bio of the Jonathan Demme"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1600647/2f94d5ee-e8fe-4e7c-91a4-5c31cf83fb85/280x420",
                            FullName = "Robert Zemeckis",
                            Bio = "This is the Bio of the Robert Zemeckis"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/e70b3771-0e38-434c-bbea-41a9b7036e0f/280x420",
                            FullName = "Stanley Kubrick",
                            Bio = "This is the Bio of the Stanley Kubrick"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1777765/446240ea-b5a4-47ea-abc4-8e94fbe65082/280x420",
                            FullName = "Stephen Sommers",
                            Bio = "This is the Bio of the Stephen Sommers"
                        },
                        new Producer()
                        {
                            ProfilePictureUrl ="https://avatars.mds.yandex.net/get-kinopoisk-image/1704946/a4312163-b306-46df-89b2-61ea390b2f7e/280x420",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/3560b757-9b95-45ec-af8c-623972370f9d/300x450",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1599028/b59df583-bdf7-4222-b761-b9c6a0d8559d/300x450",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/1900788/56d7dbb1-2eb0-4f5f-8f2c-88334f7a3790/300x450",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/6201401/49ba5c05-249b-4387-8418-833aa54bb376/300x450",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/6201401/9c655ce1-2b59-4941-97aa-f9e928ed0ff4/300x450",
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
                            ImageUrl = "https://avatars.mds.yandex.net/get-kinopoisk-image/4303601/e5ab661c-c972-4046-86bb-1470e4bd6f1e/300x450",
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
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 2
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 6,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 7,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
