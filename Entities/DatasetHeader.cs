// this is represented as a JSON {text: '...', value: '...'} on the client
// the 'value' key will represent the column index (e.g., col0) which is used in DatasetRow to identify which position to place a value
public class DatasetHeader
{
  private string text;
  private string value;

  public string ToJSONString()
  {
    return "{\"text\": " + "\""+this.text+"\"" + ", \"value\": " +"\""+this.value+"\"" + "}";
  }
  
  public DatasetHeader(string text, string value)
  {
    this.text = text;
    this.value = value;
  }
}