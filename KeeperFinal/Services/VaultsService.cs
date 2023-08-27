namespace KeeperFinal.Services;
public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;
  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }
  internal Vault CreateVault(Vault vaultData)
  {
    int vaultId = _vaultsRepository.CreateVault(vaultData);
    Vault vault = GetVaultById(vaultId);
    return vault;
  }

  internal Vault GetVaultById(int vaultId, string userId = null)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception("This vault does not exist");
    }
    if (vault.IsPrivate == true && vault.CreatorId != userId)
    {
      throw new Exception($"Bad vault id: {vaultId}. 😂");
    }
    return vault;
  }


  internal Vault UpdateVault(Vault vaultData, string userId)
  {
    Vault originalVault = GetVaultById(vaultData.Id, userId);
    if (originalVault.CreatorId != userId)
    {
      throw new Exception("Not your vault to edit");
    }

    originalVault.Name = vaultData.Name ?? originalVault.Name;
    originalVault.IsPrivate = vaultData.IsPrivate ?? originalVault.IsPrivate;

    _vaultsRepository.UpdateVault(originalVault);

    return originalVault;
  }


  internal string RemoveVault(int vaultId, string userId)
  {
    Vault vault = GetVaultById(vaultId);
    if (vault.CreatorId != userId)
    {
      throw new Exception("Not your vault to remove");
    }
    _vaultsRepository.RemoveVault(vaultId);
    return "Vault removed";
  }

  internal List<MyVaults> GetMyVaults(string userId)
  {
    List<MyVaults> vaults = _vaultsRepository.GetMyVaults(userId);
    return vaults;
  }
}