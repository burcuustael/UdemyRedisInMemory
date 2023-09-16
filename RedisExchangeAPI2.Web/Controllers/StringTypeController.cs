using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI2.Web.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI2.Web.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;

        private readonly IDatabase db;

        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
            db = _redisService.GetDb(0);
        }

        public IActionResult Index()
        {
            db.StringSet("name", "burcus");
            db.StringSet("ziyaretci", 100);
            return View();
        }

        public IActionResult Show()
        {
            var value = db.StringGet("name");

           // db.StringIncrement("ziyaretci",10);

            var count = db.StringDecrementAsync("ziyaretci", 1).Result;

            if (value.HasValue)
            {
                ViewBag.value = value;
            }
            return View();
        }
    }
}
