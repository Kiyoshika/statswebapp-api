public class DatasetRepository
{
  private Dictionary<Guid, List<Dataset>> datasets;

  public DatasetRepository()
  {
    this.datasets = new();
  }

  public void save(Guid sessionID, Dataset dataset)
  {
    if (!this.datasets.ContainsKey(sessionID))
      this.datasets.Add(sessionID, new List<Dataset>());
    
    this.datasets[sessionID].Add(dataset);
  }

  public Dataset? FindByFileNameAndSessionID(string fileName, Guid sessionID)
  {
    if (!this.datasets.ContainsKey(sessionID))
      return null;

    foreach (Dataset _dataset in this.datasets[sessionID])
      if (_dataset.GetSessionID().Equals(sessionID) 
          && _dataset.GetFileName().Equals(fileName))
        return _dataset;

    return null;
  }
}