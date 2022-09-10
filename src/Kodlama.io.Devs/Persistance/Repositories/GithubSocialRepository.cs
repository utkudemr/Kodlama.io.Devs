﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class GithubSocialRepository : EfRepositoryBase<GithubSocial, BaseDbContext>, IGithubSocialRepository
    {
        public GithubSocialRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
