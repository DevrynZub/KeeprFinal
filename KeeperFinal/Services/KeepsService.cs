
namespace KeeperFinal.Services;
public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;
  private readonly VaultsService _vaultsService;

  private readonly VaultKeepsRepository _vaultKeepsRepository;


  public KeepsService(KeepsRepository keepsRepository, VaultsService vaultsService, VaultKeepsRepository vaultKeepsRepository)
  {
    _keepsRepository = keepsRepository;
    _vaultsService = vaultsService;
    _vaultKeepsRepository = vaultKeepsRepository;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    int keepId = _keepsRepository.CreateKeep(keepData);

    Keep keep = GetKeepById(keepId, keepData.CreatorId);

    return keep;
  }

  internal Keep GetKeepById(int keepId, string userId = null)
  {
    Keep keep = _keepsRepository.GetKeepById(keepId);
    if (keep == null)
    {
      throw new Exception($"Bad Keep Id: {keepId}");
    }
    return keep;
  }

  internal Keep GetKeepByIdAndIncreaseViews(int keepId, string userId = null)
  {
    Keep keep = GetKeepById(keepId, userId);

    keep.Views++;

    _keepsRepository.UpdateKeep(keep);

    return keep;
  }
  internal Keep GetKeepByIdAndIncreaseKept(int keepId, string userId = null)
  {
    Keep keep = GetKeepById(keepId, userId);

    keep.Kept++;

    _keepsRepository.UpdateKeep(keep);

    return keep;
  }





  internal List<Keep> GetKeeps()
  {
    List<Keep> keeps = _keepsRepository.GetKeeps();
    return keeps;
  }

  internal Keep RemoveKeep(int keepId, string userId)
  {
    Keep keep = GetKeepById(keepId);
    if (keep.CreatorId != userId)
    {
      throw new Exception("Not your keep to remove");
    }
    _keepsRepository.RemoveKeep(keepId);
    return keep;
  }

  internal Keep UpdateKeep(Keep keepData, string userId)
  {
    Keep originalKeep = GetKeepById(keepData.Id, userId);
    if (originalKeep.CreatorId != userId)
    {
      throw new Exception("NOT YOUR KEEP BUDDY!");
    }

    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;

    _keepsRepository.UpdateKeep(originalKeep);

    return originalKeep;
  }
}

