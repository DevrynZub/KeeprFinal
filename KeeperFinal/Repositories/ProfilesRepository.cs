namespace KeeperFinal.Repositories;
public class ProfilesRepository
{
  internal Profile GetProfileById(int profileId)
  {
    string sql = @"
SELECT
pro.*,
acc.*
FROM profile pro
JOIN accounts acc ON acc.id = pro.creatorId
WHERE pro.id = @profileId
;";

    Profile profile = _db.Query<Profile, Account, Profile>(
  sql,
  (profile, account) =>
  {
    profile.Creator = account;
    return profile;
  },
  new { profileId }
).FirstOrDefault();
    return profile;
  }
}