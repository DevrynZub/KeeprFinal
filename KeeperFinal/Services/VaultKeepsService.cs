namespace KeeperFinal.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, KeepsService keepsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _keepsService = keepsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }

  internal string RemoveVaultKeep(int vaultKeepId, string userId)
  {
    if (vaultKeepId.AccountId != userId)
    {
      throw new Exception("Not your vault");
    }
    _vaultKeepsRepository.RemoveVaultKeep(vaultKeepId);
  }
}