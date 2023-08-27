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
      INSERT INTO keeps (name, description, img, views, creatorId)
      VALUES(@Name, @Description, @Img, @Views, @CreatorId);
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
      WHERE kee.id = @keepId LIMIT 1
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

  internal Keep UpdateKeep(Keep originalKeep)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description
    WHERE id = @Id
    LIMIT 1; 
     SELECT * FROM keeps WHERE id = @Id
    ;";

    Keep updateKeep = _db.QueryFirstOrDefault<Keep>(sql, originalKeep);

    return updateKeep;
  }

  internal void RemoveKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
    _db.Execute(sql, new { keepId });
  }

  internal List<Keep> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
      SELECT
      v.*,
      acc.*
      FROM vaults v
      JOIN accounts acc ON acc.id = v.creatorId
      WHERE v.keepId = @vaultId
      ;";

    List<Keep> keeps = _db.Query<Keep, Vault, Keep>(
      sql,
      (keep, vault) =>
      {
        vault.KeepId = keep.Id;
        return keep;
      },
      new { vaultId }
    ).ToList();
    return keeps;
  }
}

