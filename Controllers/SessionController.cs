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
    Guid newSessionID = SessionManager.GenerateSessionID();
    _logger.LogInformation(string.Format("Client IP {0} requested new session ID {1}", Request.Headers["client-ip"], newSessionID));
    return newSessionID;
  }

  [HttpDelete(Name = "RemoveSessionID")]
  public IActionResult RemoveSessionID()
  {
    try
    {
      Guid sessionID = new Guid(Request.Headers["session-id"]);
      SessionManager.RemoveSessionID(sessionID);
    }
    catch
    {
      return BadRequest();
    }

    return Ok();

  }
}