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
INSERT INTO vaultKeeps (keepId, accountId)
VALUES (@KeepId, @AccountId);
SELECT LAST_INSERT_ID()
;";

    int vaultKeepId = _db.ExecuteScalar<int>(sql, vaultKeepData);

    vaultKeepData.Id = vaultKeepId;
    return vaultKeepData;
  }
}