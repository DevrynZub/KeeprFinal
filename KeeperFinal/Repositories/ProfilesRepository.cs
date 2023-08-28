namespace KeeperFinal.Repositories;
public class ProfilesRepository
{
  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Profile GetProfileById(string profileId)
  {
    string sql = @"
    SELECT * FROM accounts WHERE id = @profileId LIMIT 1;";
    return _db.QueryFirstOrDefault<Profile>(sql, new { profileId });
  }
}