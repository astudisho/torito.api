using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Torito.Core.Services.Interfaces;

namespace Torito.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ToritoController : ControllerBase
    {
        private readonly IRecentTweetService _recentTweetService;
        private readonly ILogger<ToritoController> _logger;

        public ToritoController(IRecentTweetService recentTweetService, ILogger<ToritoController> logger)
        {
            _recentTweetService = recentTweetService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecent(CancellationToken ct)
        {
            var result = await _recentTweetService.GetRecentTorito(ct);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLastDay(CancellationToken ct)
        {
            var result = await _recentTweetService.GetLastDayTorito(ct);

            return Ok(result);
        }
    }
}
