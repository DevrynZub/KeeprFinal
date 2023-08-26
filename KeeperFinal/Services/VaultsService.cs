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

  internal Vault GetVaultById(int vaultId)
  {
    Vault vault = _vaultsRepository.GetVaultById(vaultId);
    if (vault == null)
    {
      throw new Exception("This vault does not exist");
    }
    return vault;
  }
}