public class DataUploadService
{
  static private DatasetRepository datasetRepository = new();

  // store the file onto the server tied to client's information

  static public void UploadFile(
    string filename,
    Guid sessionID,
    string clientIP,
    IFormFile uploadedCSV)
    {

      Dataset dataset = new();
      dataset.SetFileName(filename);
      dataset.SetSessionID(sessionID);
      dataset.SetClientIP(clientIP);

      bool onHeader = true;
      using (var reader = new StreamReader(uploadedCSV.OpenReadStream()))
      {
        // for now doing a very naive split on commas
        // this WILL NOT WORK if commas are present inside quotes
        string[] fields = reader.ReadLine().Split(",", StringSplitOptions.None);
        if (onHeader)
        {
          foreach (string header in fields)
            dataset.AddHeader(header);
          onHeader = false;
        }
        else
        {
          // TODO: finish this, need to implement dataset.AddRow()
        }
      }

      datasetRepository.save(dataset);
    }
}