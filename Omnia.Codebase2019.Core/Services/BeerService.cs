using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Omnia.Codebase2019.Models;
using Omnia.Fx.Contexts;
using Omnia.Fx.Models.Users;
using Omnia.Fx.Users;

namespace Omnia.Codebase2019.Core.Services
{
    internal class BeerService : IBeerService
    {
        private IOmniaContext OmniaContext { get; }
        private IUserService UserService { get; }
        public BeerService(IOmniaContext omniaContext,
                           IUserService userService)
        {
            this.OmniaContext = omniaContext;
            this.UserService = userService;
        }

        public ValueTask<Dictionary<User, IList<BasicBeer>>> AllBeersOrderedAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public ValueTask<BasicBeer> OrderAsync(BasicBeer beer)
        {
            throw new NotImplementedException();
        }
    }
}
