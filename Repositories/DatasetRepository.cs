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

  public List<Dataset> FindByFileNameAndSessionID(string FileName, Guid sessionID)
  {
    List<Dataset> foundDatasets = new();
    foreach (Dataset _dataset in this.datasets)
      if (_dataset.GetSessionID().Equals(sessionID))
        foundDatasets.Add(_dataset);

    return foundDatasets;
  }
}