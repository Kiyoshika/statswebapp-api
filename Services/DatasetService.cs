using Microsoft.AspNetCore.Mvc;

public class DatasetService
{
  static private DatasetRepository datasetRepository = new();

  // store the file onto the server tied to client's information

  static public bool UploadFile(
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
        while (!reader.EndOfStream)
        {
          // for now doing a very naive split on commas
          // this WILL NOT WORK if commas are present inside quotes
          string? currentLine = reader.ReadLine();
          if (currentLine == null)
            return false;
          
          string[] fields = currentLine.Split(",", StringSplitOptions.None);
         
          if (onHeader)
          {
            foreach (string header in fields)
              dataset.AddHeader(header);
            onHeader = false;
          }
          else
          {
            List<string> fieldsList = new();
            foreach (string field in fields)
              fieldsList.Add(field);
            dataset.AddRow(fieldsList);
          }
        }
        }

      datasetRepository.save(sessionID, dataset);

      return true;
    }

    static public Dataset? FetchDataset(string fileName, Guid sessionID)
    {
      return datasetRepository.FindByFileNameAndSessionID(fileName, sessionID);
    }
}