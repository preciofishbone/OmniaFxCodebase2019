﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Omnia.Codebase2019.Core.Entities;
using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;

namespace Omnia.Codebase2019.Core.Repositories
{
    internal class BikeRepository : IBikeRepository
    {
        private DbSet<OrderedBikeEntity> OrderedBikes { get; }
        private CodeBaseDBContext DatabaseContext { get; }

        public BikeRepository(CodeBaseDBContext dbContext)
        {
            OrderedBikes = dbContext.OrderedBikes;
            DatabaseContext = dbContext;
        }

        public async ValueTask<Dictionary<Guid, IList<BasicBike>>> AllBikesOrderedAsync()
        {
            Dictionary<Guid, IList<BasicBike>> result = new Dictionary<Guid, IList<BasicBike>>();

            var allOrders = await this.OrderedBikes.ToListAsync();

            foreach(var order in allOrders)
            {
                if (!result.ContainsKey(order.UserId))
                {
                    result.Add(order.UserId, new List<BasicBike>());
                }

                result[order.UserId].Add(order.Bike);
            }

            return result;
        }

        public async ValueTask<IList<BasicBike>> BikesOrderedByUserAsync(Guid userId)
        {

            IList<BasicBike> result = (await this.OrderedBikes.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.Bike).ToList();

            return result;
        }

        public async ValueTask<BasicBike> OrderAsync(BasicBike bike, Guid userId)
        {
            var newOrder = new OrderedBikeEntity
            {
                Bike = bike,
                UserId = userId
            };

            this.OrderedBikes.Add(newOrder);

            await DatabaseContext.SaveChangesAsync();

            return newOrder.Bike;
        }
    }
}
