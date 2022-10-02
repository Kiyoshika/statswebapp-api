public class Dataset
{

  // metadata to tie a dataset to a specific client user
  private string fileName;
  private Guid sessionID;
  private string clientIP;
  
  private uint headerCount = 0;
  private List<DatasetHeader> header;
  private List<DatasetRow> rows; 

  public Dataset()
  {
    this.header = new();
    this.rows = new();
  }

  public void SetFileName(string fileName)
  {
    this.fileName = fileName;
  }

  public void SetSessionID(Guid sessionID)
  {
    this.sessionID = sessionID;
  }

  public void SetClientIP(string clientIP)
  {
    this.clientIP = clientIP;
  }

  public Guid GetSessionID()
  {
    return this.sessionID;
  }

  public string GetClientIP()
  {
    return this.clientIP;
  }

  public void AddHeader(string headerText)
  {
    string headerValue = $"col{this.headerCount++}";
    DatasetHeader header = new DatasetHeader(headerText, headerValue);
    this.header.Add(header);
  }

  public string ToJSONString()
  {
    string headerString = "[";
    foreach (DatasetHeader header in this.header)
      headerString += header.ToJSONString() + ",";
    headerString = headerString.Remove(headerString.Length - 1, 1);
    headerString += "]";

    return "{" + 
      "\"headers\":" + headerString + 
      "}";
  }
}