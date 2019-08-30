﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omnia.Codebase2019.Core.Repositories;
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
        private IBeerRepository BeerRepository { get; }

        public BeerService(IOmniaContext omniaContext,
                           IUserService userService,
                           IBeerRepository beerRepository)
        {
            this.OmniaContext = omniaContext;
            this.UserService = userService;
            BeerRepository = beerRepository;
        }

        public async ValueTask<Dictionary<Guid, IList<BasicBeer>>> AllBeersOrderedAsync()
        {

            var result = await this.BeerRepository.AllBeersOrderedAsync();

            return result;
        }

        public ValueTask<IList<BasicBeer>> BeersOrderedByUserAsync(Guid userId)
        {
            return this.BeerRepository.BeersOrderedByUserAsync(userId);
        }

        public ValueTask<BasicBeer> OrderAsync(BasicBeer beer)
        {
            return this.BeerRepository.OrderAsync(beer, this.OmniaContext.Identity.UserId);
        }

        public List<BasicBeer> GetAvailableBeers()
        {
            var beers = new List<BasicBeer>();

            beers.Add(new Lager
            {
                Brand = "Corona"
            });

            beers.Add(new Lager
            {
                Brand = "Rignes"
            });

            beers.Add(new PaleAle
            {
                Brand = "Holy GrAle"
            });

            beers.Add(new PaleAle
            {
                Brand = "Sierra Nevada Pale Ale"
            });

            beers.Add(new IndiaPaleAle
            {
                Brand = "Anchor Steve"
            });

            beers.Add(new IndiaPaleAle
            {
                Brand = "Punk IPA"
            });

            beers.Add(new IndiaPaleAle
            {
                Brand = "Sierra Nevada Torpedo Extra IPA"
            });

            beers.Add(new IndiaPaleAle
            {
                Brand = "Dogfish Head 60 Minute IPA"
            });

            return  beers;

        }
    }
}
