// this is represented as a JSON {text: '...', value: '...'} on the client
// the 'value' key will represent the column index (e.g., col0) which is used in DatasetRow to identify which position to place a value
public class DatasetHeader
{
  public string text {get; set;} = string.Empty;
  public string value {get; set;} = string.Empty;
}