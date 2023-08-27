using System.Security.Cryptography.X509Certificates;

namespace KeeperFinal.Services;
public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;
  private readonly VaultsService _vaultsService;

  public KeepsService(KeepsRepository keepsRepository, VaultsService vaultsService)
  {
    _keepsRepository = keepsRepository;
    _vaultsService = vaultsService;
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
    if (keep == null)
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

  internal List<Keep> GetKeepsByVaultId(int vaultId, string userId)
  {
    List<Keep> keeps = _keepsRepository.GetKeepsByVaultId(vaultId);
    return keeps;
  }

  internal string RemoveKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Not your keep to remove");
    }
    _keepsRepository.RemoveKeep(keepId);
    return "Keep removed";
  }

  internal Keep UpdateKeep(int keepId, Keep keepData)
  {
    Keep originalKeep = GetKeepById(keepId);

    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;

    Keep keep = _keepsRepository.UpdateKeep(originalKeep);
    return keep;
  }
}

