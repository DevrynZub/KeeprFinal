namespace KeeperFinal.Services;
public class ProfilesService
{
  private readonly ProfilesRepository _profilesRepository;
  private readonly KeepsRepository _keepsRepository;

  private readonly VaultsRepository _vaultsRepository;


  public ProfilesService(ProfilesRepository profilesRepository, KeepsRepository keepsRepository, VaultsRepository vaultsRepository)
  {
    _profilesRepository = profilesRepository;
    _keepsRepository = keepsRepository;
    _vaultsRepository = vaultsRepository;
  }
  internal Profile GetProfileById(string profileId)
  {
    Profile profile = _profilesRepository.GetProfileById(profileId);
    if (profile == null)
    {
      throw new Exception($"Bad Profile Id: {profileId}");
    }
    return profile;
  }

  internal List<Keep> GetProfileKeeps(string profileId)
  {
    List<Keep> keeps = _keepsRepository.GetProfileKeeps(profileId);
    return keeps;
  }

  internal List<Vault> GetProfileVaults(string profileId)
  {
    List<Vault> vaults = _vaultsRepository.GetProfileVaults(profileId);
    return vaults;
  }
}