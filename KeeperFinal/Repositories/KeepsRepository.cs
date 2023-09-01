namespace KeeperFinal.Repositories;
public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateKeep(Keep keepData)
  {
    string sql = @"
      INSERT INTO keeps (name, description, img, creatorId)
      VALUES(@Name, @Description, @Img, @CreatorId);
      SELECT LAST_INSERT_ID()  
      ;";

    int keepId = _db.ExecuteScalar<int>(sql, keepData);
    return keepId;
  }

  internal Keep GetKeepById(int keepId)
  {
    string sql = @"
      SELECT
      kee. *,
      acc.*
      FROM keeps kee
      JOIN accounts acc ON acc.id = kee.creatorId
      WHERE kee.id = @keepId
      ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      },
      new { keepId }
    ).FirstOrDefault();
    return keep;
  }

  internal List<Keep> GetKeeps()
  {
    string sql = @"
  SELECT
  kee. *,
  acc.*
  FROM keeps kee
  JOIN accounts acc ON acc.id = kee.creatorId
  ORDER BY kee.name ASC
  ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
    sql,
    (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }
    ).ToList();
    return keeps;
  }

  internal void UpdateKeep(Keep originalKeep)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    views = @Views,
    kept = @Kept
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalKeep);
  }

  internal void RemoveKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
    _db.Execute(sql, new { keepId });
  }

  internal List<Keep> GetProfileKeeps(string profileId)
  {
    string sql = @"
      SELECT
      kee.*,
      acc.*
      FROM keeps kee
      JOIN accounts acc ON kee.creatorId = acc.id
      WHERE kee.creatorId = @profileId;";
    return _db.Query<Keep, Profile, Keep>(
      sql,
      (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { profileId }).ToList();
  }
}


