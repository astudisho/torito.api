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
    public class SyncController : ControllerBase
    {
        private readonly ILogger<SyncController> _logger;
        private readonly ISyncService _syncService;

        public SyncController(ILogger<SyncController> logger, ISyncService syncService)
        {
            _logger = logger;
            _syncService = syncService;
        }

        [HttpPost]
        public async Task<IActionResult> Tweets(CancellationToken ct)
        {
            var result = await _syncService.SyncTweets(ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Address(CancellationToken ct)
        {
            var result = await _syncService.SyncAddress(ct);
            return Ok(result);
        }

        [HttpPost]
        //[Route("Location")]
        public async Task<IActionResult> Location(CancellationToken ct)
        {
            var result = await _syncService.SyncLocation(ct);
            return Ok(result);
        }
    }
}
