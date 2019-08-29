using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;

namespace Omnia.Codebase2019.Core.Repositories
{
    internal class BeerRepository : IBeerRepository
    {
        private CodeBaseDBContext DbContext { get; }

        public BeerRepository(CodeBaseDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public ValueTask<Dictionary<Guid, IList<BasicBeer>>> AllBeersOrderedAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(User userId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<BasicBeer> OrderAsync(BasicBeer beer, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
