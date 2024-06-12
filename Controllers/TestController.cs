using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using POC_RealTime.Hubs;
using POC_RealTime.Services;

namespace POC_RealTime.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly IHubContext<RandomStringHub> _hub;
    private readonly TimerService _timer;
        
    public TestController(IHubContext<RandomStringHub> hub, TimerService timer)
    {
        _hub = hub;
        _timer = timer;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _timer.Timer.Elapsed += async (s, e) => await _hub.Clients.All.SendAsync("newStringReceived", Guid.NewGuid().ToString());
;
        return Ok();
    }
}