namespace KeeperFinal.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, KeepsService keepsService, VaultsService vaultsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, int keepId)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);

    _keepsService.GetKeepByIdAndIncreaseKept(keepId);

    return vaultKeep;
  }

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.GetVaultKeepById(vaultKeepId);
    if (vaultKeep == null)
    {
      throw new Exception($"Bad VaultKeep ID: {vaultKeepId}");
    }
    return vaultKeep;
  }

  internal string RemoveVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = GetVaultKeepById(vaultKeepId);
    if (vaultKeep.AccountId != userId)
    {
      throw new Exception("Not your VaultKeep");
    }
    _vaultKeepsRepository.RemoveVaultKeep(vaultKeepId);
    return "VaultKeep Removed.";
  }

  internal List<KeepCollaboration> GetKeepsByVaultId(int vaultId, Account user)
  {
    Vault vaults = _vaultsService.GetVaultById(vaultId);
    if (vaults.IsPrivate == true)
    {
      if (user == null || vaults.CreatorId != user.Id)
      {
        throw new Exception("This is a private vault and not yours");
      }
    }

    return _vaultKeepsRepository.GetKeepsByVaultId(vaultId);
    // // FIXME get the vault that we are trying to view the keeps for
    // // FIXME check if the user has access to the OG vault....am i the person who made and is it private
  }
}