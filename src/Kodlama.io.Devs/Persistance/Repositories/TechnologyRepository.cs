using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, BaseDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
