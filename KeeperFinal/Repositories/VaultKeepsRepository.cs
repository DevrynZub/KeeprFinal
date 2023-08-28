using System.ComponentModel.Design;

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

  internal VaultKeep GetVaultKeepById(int vaultKeepId)
  {
    string sql = "SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";

    VaultKeep vaultKeep = _db.QueryFirstOrDefault<VaultKeep>(sql, new { vaultKeepId });
    return vaultKeep;
  }

  internal void RemoveVaultKeep(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1";
    _db.Execute(sql, new { vaultKeepId });
  }


  internal List<KeepCollaboration> GetKeepsByVaultId(int vaultId)
  {
    string sql = @"
    SELECT
      vK.*,
      k.*,
      acc.*
      FROM vaultKeeps vK
      JOIN keeps k ON vK.keepId = k.id
      JOIN accounts acc ON k.creatorId = acc.id
      WHERE vK.vaultId = @vaultId
    ; ";

    List<KeepCollaboration> keeps = _db.Query<VaultKeep, KeepCollaboration, Account, KeepCollaboration>(
      sql,
      (vaultKeep, keep, account) =>
    {
      keep.Creator = account;
      keep.VaultKeepId = vaultKeep.Id;
      return keep;
    }, new { vaultId }).ToList();
    return keeps;
  }
}