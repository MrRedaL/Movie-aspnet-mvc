using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvcApp.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context)
        {

        }   
    }
}
