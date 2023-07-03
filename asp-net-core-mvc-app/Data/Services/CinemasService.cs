using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Models;

namespace AspNetCoreMvcApp.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {

        }
    }
}
