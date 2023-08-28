// namespace KeeperFinal.Services;
// public class ProfilesService
// {
//   private readonly ProfilesRepository _profileRepository;
//   public ProfilesService(ProfilesRepository profileRepository)
//   {
//     _profileRepository = profileRepository;
//   }
//   internal Profile GetProfileById(int profileId, string userId = null)
//   {
//     Profile profile = _profileRepository.GetProfileById(profileId);
//     if (profile == null)
//     {
//       throw new Exception($"Bad Profile Id: {profileId}");
//     }
//     return profile;
//   }
// }