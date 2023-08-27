namespace KeeperFinal.Services;
public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    VaultKeep vaultKeep = _vaultKeepsRepository.CreateVaultKeep(vaultKeepData);
    return vaultKeep;
  }
}