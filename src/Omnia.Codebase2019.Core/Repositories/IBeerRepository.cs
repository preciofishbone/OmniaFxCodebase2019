using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omnia.Codebase2019.Core.Repositories
{
    /// <summary>
    /// The repository used internally to interact with the DB
    /// (Used from services)
    /// </summary>
    internal interface IBeerRepository
    {
        ValueTask<BasicBeer> OrderAsync(BasicBeer beer, Guid userId);

        ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(User userId);

        ValueTask<Dictionary<Guid, IList<BasicBeer>>> AllBeersOrderedAsync();
    }
}
