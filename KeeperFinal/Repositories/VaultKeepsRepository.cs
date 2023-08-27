namespace KeeperFinal.Repositories;
public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }
  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
INSERT INTO vaultKeeps (keepId, vaultId, accountId, creatorId)
VALUES (@KeepId, @VaultId, @AccountId, @CreatorId);
SELECT LAST_INSERT_ID()
;";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);

    vaultKeepData.Id = vaultKeepId;
    return vaultKeepData;
  }

  internal void RemoveVaultKeep(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1";
    int rowsAffected = _db.Execute(sql, new { vaultKeepId });
    if (rowsAffected > 1)
    {
      throw new Exception("Oh NOOOOOO");
    }
  }
}