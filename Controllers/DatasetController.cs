using Microsoft.AspNetCore.Mvc;
using statswebapp_api;

namespace statswebapp_api.Controllers;

[ApiController]
[Route("/api/v1/[controller]/[action]")]
public class DatasetController : ControllerBase
{
  private readonly ILogger<DatasetController> _logger;

  public DatasetController(ILogger<DatasetController> logger)
  {
    _logger = logger;
  }

  [HttpPost(Name = "UploadDataset")]
  public IActionResult UploadDataset()
  {
    IFormFile? file = Request.Form.Files[0];
    string fileName = Request.Headers["filename"];
    Guid sessionID = new Guid(Request.Headers["session-id"]);
    string clientIP = Request.Headers["client-ip"];

    bool uploaded = DatasetService.UploadFile(
      fileName,
      sessionID,
      clientIP,
      file);

      if (!uploaded)
        return BadRequest("There was a problem parsing the CSV file while uploading.");
      return Ok();
  }

  [HttpGet(Name = "GetDataset")]
  public IActionResult GetDataset(string fileName)
  {
    Guid sessionID = new Guid(Request.Headers["session-id"]);
    Dataset? dataset = DatasetService.FetchDataset(fileName, sessionID);

    if (dataset == null)
      return NotFound();
    return Ok(new 
    {
      headers = dataset.GetHeader(),
      rows = dataset.GetRows()
    });
  }
}