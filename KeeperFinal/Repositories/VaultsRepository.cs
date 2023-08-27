namespace KeeperFinal.Repositories;
public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal int CreateVault(Vault vaultData)
  {
    string sql = @"
    INSERT INTO vaults
    (name, description, img, isPrivate, keepId, creatorId)
    VALUES(@Name, @Description, @Img, @IsPrivate, @KeepId, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";

    int vaultId = _db.ExecuteScalar<int>(sql, vaultData);
    return vaultId;
  }

  internal Vault GetVaultById(int vaultId)
  {
    string sql = @"
SELECT
v.*,
acc.*
FROM vaults v
JOIN accounts acc On acc.id = v.creatorId
WHERE v.id = @vaultId
;";
    Vault vault = _db.Query<Vault, Profile, Vault>(sql,
    (vault, profile) =>
    {
      vault.Creator = profile;
      return vault;
    }, new { vaultId }).FirstOrDefault();
    return vault;
  }


  internal void UpdateVault(Vault originalVault)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalVault);
  }
  internal void RemoveVault(int vaultId)
  {
    string sql = "DELETE FROM vaults where id = @vaultId LIMIT 1;";
    _db.Execute(sql, new { vaultId });
  }

  internal List<MyVaults> GetMyVaults(string userId)
  {
    string sql = @"
SELECT
v.*,
acc.*
FROM vaults v
JOIN accounts acc ON acc.id = v.accountId
WHERE v.accountId = @userId
;";

    List<MyVaults> vaults = _db.Query<Vault, MyVaults, Profile, MyVaults>(
      sql,
      (vault, vaults, profile) =>
      {
        vault.Creator = profile;
        return vaults;
      },
      new { userId }).ToList();
    return vaults;
  }


}

