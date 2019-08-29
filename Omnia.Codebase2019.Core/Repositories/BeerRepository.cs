using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Omnia.Codebase2019.Core.Entities;
using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;

namespace Omnia.Codebase2019.Core.Repositories
{
    internal class BeerRepository : IBeerRepository
    {
        private DbSet<OrderedBeerEntity> OrderedBeers { get; }
        private CodeBaseDBContext DatabaseContext { get; }

        public BeerRepository(CodeBaseDBContext dbContext)
        {
            OrderedBeers = dbContext.OrderedBeers;
            DatabaseContext = dbContext;
        }

        public async ValueTask<Dictionary<Guid, IList<BasicBeer>>> AllBeersOrderedAsync()
        {
            Dictionary<Guid, IList<BasicBeer>> result = new Dictionary<Guid, IList<BasicBeer>>();

            var allOrders = await this.OrderedBeers.ToListAsync();

            foreach(var order in allOrders)
            {
                if (!result.ContainsKey(order.UserId))
                {
                    result.Add(order.UserId, new List<BasicBeer>());
                }

                result[order.UserId].Add(order.Beer);
            }

            return result;
        }

        public async ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(Guid userId)
        {

            IList<BasicBeer> result = (await this.OrderedBeers.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.Beer).ToList();

            return result;
        }

        public async ValueTask<BasicBeer> OrderAsync(BasicBeer beer, Guid userId)
        {
            var newOrder = new OrderedBeerEntity
            {
                Beer = beer,
                UserId = userId
            };

            this.OrderedBeers.Add(newOrder);

            await DatabaseContext.SaveChangesAsync();

            return newOrder.Beer;
        }
    }
}
