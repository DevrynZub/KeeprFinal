namespace KeeperFinal.Models;
public class VaultKeep
{
  public int Id { get; set; }
  public int KeepId { get; set; }
  public int VaultId { get; set; }
  public string AccountId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}


