using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Omnia.Codebase2019.Core.Services;
using Omnia.Codebase2019.Models;
using Omnia.Fx.Models.Shared;
using Omnia.Fx.Models.Users;
using Omnia.Fx.Utilities;

namespace Omnia.Codebase2019.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderBeerController : ControllerBase
    {
        private IBeerService BeerService { get; }
        private ILogger<OrderBeerController> Logger { get; }

        public OrderBeerController(IBeerService beerService,
                                   ILogger<OrderBeerController> logger)
        {
            BeerService = beerService;
            Logger = logger;
        }

        // GET: api/OrderBeer
        [HttpGet]
        public async ValueTask<ApiResponse<Dictionary<User,IList<BasicBeer>>>> Get()
        {
            try
            {
                var allBeers = await BeerService.AllBeersOrderedAsync();
                return ApiUtils.CreateSuccessResponse(allBeers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return ApiUtils.CreateErrorResponse<Dictionary<User,IList<BasicBeer>>>(ex);
            }
        }

        // GET: api/OrderBeer/5
        [HttpGet("{userId}", Name = "Get")]
        public async ValueTask<ApiResponse<IList<BasicBeer>>> Get(Guid userId)
        {
            try
            {
                var userBeers = await BeerService.BeersOrderedByUserAsync(userId);
                return ApiUtils.CreateSuccessResponse(userBeers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return ApiUtils.CreateErrorResponse<IList<BasicBeer>>(ex);
            }
        }

        // POST: api/OrderBeer
        [HttpPost]
        public async ValueTask<ApiResponse<BasicBeer>> Post([FromBody] BasicBeer beer)
        {
            try
            {
                var userBeers = await BeerService.OrderAsync(beer);
                return ApiUtils.CreateSuccessResponse(userBeers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return ApiUtils.CreateErrorResponse<BasicBeer>(ex);
            }
        }
    }
}
