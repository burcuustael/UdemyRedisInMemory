using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI2.Web.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI2.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly RedisService _redisService;
        protected readonly IDatabase db;
        public BaseController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(4);
        }
    }
}
