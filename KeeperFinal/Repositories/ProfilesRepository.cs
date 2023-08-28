namespace KeeperFinal.Repositories;
public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(int profileId)
  {
    string sql = @"
SELECT
p.*,
acc.*
FROM profile pro
JOIN accounts acc ON acc.id = pro.creatorId
WHERE pro.id = @profileId
;";

    Profile profile = _db.Query<Profile, Account, Profile>(
  sql,
  (profile, account) =>
  {
    profile.Id = account.Id;
    return profile;
  },
  new { profileId }
  ).FirstOrDefault();
    return profile;
  }
}