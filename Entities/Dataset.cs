public class Dataset
{

  // metadata to tie a dataset to a specific client user
  private string fileName = string.Empty;
  private Guid? sessionID;
  private string clientIP = string.Empty;
  
  private uint headerCount = 0;
  private List<DatasetHeader> header;
  private List<Dictionary<string, string>> rows; 

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

  public Guid? GetSessionID()
  {
    return this.sessionID;
  }

  public string GetClientIP()
  {
    return this.clientIP;
  }

  public string GetFileName()
  {
    return this.fileName;
  }

  public List<DatasetHeader> GetHeader()
  {
    return this.header;
  }

  public List<Dictionary<string, string>> GetRows()
  {
    return this.rows;
  }

  public void AddHeader(string headerText)
  {
    string headerValue = $"col{this.headerCount++}";
    DatasetHeader header = new DatasetHeader {
      text = headerText,
      value = headerValue
    };
    this.header.Add(header);
  }

  public void AddRow(List<string> rowValues)
  {
    Dictionary<string, string> rowValueDict = new();
    uint rowKeyIndex = 0;
    foreach (string rowValue in rowValues)
    {
      string rowKey = $"col{rowKeyIndex++}";
      rowValueDict[rowKey] = rowValue;
    }
    this.rows.Add(rowValueDict);
  }
}