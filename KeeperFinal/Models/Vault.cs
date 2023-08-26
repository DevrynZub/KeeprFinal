public class Vault : RepoItem<int>
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string Img { get; set; }
  public bool? IsPrivate { get; set; }
  public int KeepId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }

}