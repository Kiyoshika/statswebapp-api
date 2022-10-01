using Microsoft.AspNetCore.Mvc;
using statswebapp_api;

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
  public Guid GetNewSessionID()
  {
    return SessionManager.GenerateSessionID();
  }
}