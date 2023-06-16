using System;
using System.Collections.Generic;
using System.Database.Domain.Entities;
using System.Database.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace System.Database.Infrastruture.Repositories
{
    public class CostumerRepository : GenericRepository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(DatabaseDbContext dbContext) : base(dbContext)
        {
        }
    }
}