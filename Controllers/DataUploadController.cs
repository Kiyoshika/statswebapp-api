using Microsoft.AspNetCore.Mvc;
using statswebapp_api;

namespace statswebapp_api.Controllers;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class DataUploadController : ControllerBase
{
  private readonly ILogger<DataUploadController> _logger;

  public DataUploadController(ILogger<DataUploadController> logger)
  {
    _logger = logger;
  }

  [HttpPost(Name = "UploadDataset")]
  public void UploadDataset()
  {
    IFormFile? file = Request.Form.Files[0];
    string fileName = Request.Headers["filename"];
    Guid sessionID = new Guid(Request.Headers["session-id"]);
    string clientIP = Request.Headers["client-ip"];

    DataUploadService.UploadFile(
      fileName,
      sessionID,
      clientIP,
      file);
  }
}