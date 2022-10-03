public class DatasetRepository
{
  private List<Dataset> datasets;

  public DatasetRepository()
  {
    this.datasets = new();
  }

  public void save(Dataset dataset)
  {
    datasets.Add(dataset);
  }

  public Dataset? FindByFileNameAndSessionID(string fileName, Guid sessionID)
  {
    foreach (Dataset _dataset in this.datasets)
      if (_dataset.GetSessionID().Equals(sessionID) 
          && _dataset.GetFileName().Equals(fileName))
        return _dataset;

    return null;
  }
}