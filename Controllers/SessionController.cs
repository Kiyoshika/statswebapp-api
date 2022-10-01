using Microsoft.AspNetCore.Mvc;

namespace statswebapp_api.Controllers;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class SessionController : ControllerBase
{
    private readonly ILogger<SessionController> _logger;

    public SessionController(ILogger<SessionController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetNewSessionID")]
    public string GetNewSessionID()
    {
        return "random-session-id-here";
    }
}