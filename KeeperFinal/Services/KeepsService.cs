namespace KeeperFinal.Services;
public class KeepsService
{
private readonly KeepsRepository _keepsRepository;

public KeepsService(KeepsRepository keepsRepository)
{
  _keepsRepository = keepsRepository;
}

internal Keep CreateKeep(Keep keepData)
{
  int keepId = _keepsRepository.CreateKeep(keepData);

  Keep keep = GetKeepById(keepId);

  return keep;
}

internal Keep GetKeepById(int keepId)
    {
Keep keep = _keepsRepository.GetKeepById(keepId);
if(keep == null)
{
  throw new Exception($"Bad Keep Id: {keepId}");
}
return keep;
    }

internal List<Keep> GetKeeps()
  {
List<Keep> keeps = _keepsRepository.GetKeeps();
return keeps;
  }
}
    
