using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    
    [ApiController]
    public class BeerController : ControllerBase
    {
        private IBeerService BeerService { get; }
        private ILogger<BeerController> Logger { get; }

        public BeerController(IBeerService beerService,
                                   ILogger<BeerController> logger)
        {
            BeerService = beerService;
            Logger = logger;
        }

        // GET: api/OrderBeer
        [HttpGet, Route("api/orders")]
        public async ValueTask<ApiResponse<Dictionary<Guid,IList<BasicBeer>>>> Get()
        {
            try
            {
                var allBeers = await BeerService.AllBeersOrderedAsync();
                return ApiUtils.CreateSuccessResponse(allBeers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return ApiUtils.CreateErrorResponse<Dictionary<Guid,IList<BasicBeer>>>(ex);
            }
        }

        // GET: api/OrderBeer/5
        //[HttpGet("{userId}", Name = "Get")]
        [HttpGet, Route("api/orders/{userId}")]
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
        [HttpPost, Route("api/orders")]
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

        // GET: api/available
        [HttpGet, Route("api/available")]
        public async ValueTask<ApiResponse<List<BasicBeer>>> GetAvailableBeers()
        {
            try
            {
                var allBeers = await BeerService.GetAvailableBeers();
                return ApiUtils.CreateSuccessResponse(allBeers);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return ApiUtils.CreateErrorResponse<List<BasicBeer>>(ex);
            }
        }
    }
}
