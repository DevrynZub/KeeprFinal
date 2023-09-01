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
      throw new Exception("Not your vault");
    }
    _vaultKeepsRepository.RemoveVaultKeep(vaultKeepId);
    return "VaultKeep Removed.";
  }

  internal List<KeepCollaboration> GetKeepsByVaultId(int vaultId)

  {
    // FIXME get the vault that we are trying to view the keeps for
    // FIXME check if the user has access to the OG vault....am i the person who made and is it private
    List<KeepCollaboration> keepCollaborations = _vaultKeepsRepository.GetKeepsByVaultId(vaultId);

    // vaults = vaults.FindAll(vault => vault.isPrivate == false || vault.CreatorId == userId);

    return keepCollaborations;
  }
}