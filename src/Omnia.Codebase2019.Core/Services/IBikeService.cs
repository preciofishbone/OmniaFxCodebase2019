﻿using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omnia.Codebase2019.Core.Services
{
    public interface IBikeService
    {
        ValueTask<BasicBike> OrderAsync(BasicBike bike);

        ValueTask<IList<BasicBike>> BikesOrderedByUserAsync(Guid userId);

        /// <summary>
        /// Get orders for all users
        /// </summary>
        /// <returns>Dictionary of UserId and Orders</returns>
        ValueTask<Dictionary<Guid, IList<BasicBike>>> AllBikesOrderedAsync();

        ValueTask<List<BasicBike>> GetAvailableBikes();
    }
}
