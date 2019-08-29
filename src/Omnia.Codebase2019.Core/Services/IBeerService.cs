using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Omnia.Codebase2019.Core.Services
{
    public interface IBeerService
    {
        ValueTask<BasicBeer> OrderAsync(BasicBeer beer);

        ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(User user);

        ValueTask<Dictionary<User, IList<BasicBeer>>> AllBeersOrderedAsync();
    }
}
