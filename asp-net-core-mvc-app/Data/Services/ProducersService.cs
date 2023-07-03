﻿using AspNetCoreMvcApp.Data.Base;
using AspNetCoreMvcApp.Models;

namespace AspNetCoreMvcApp.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }
    }
}
