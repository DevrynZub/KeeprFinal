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
INSERT INTO vaultKeeps (keepId, vaultId, creatorId)
VALUES (@KeepId, @vaultId @CreatorId);
SELECT LAST_INSERT_ID()
;";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);

    vaultKeepData.Id = vaultKeepId;
    return vaultKeepData;
  }
}