
using System.Runtime;

public class Keep{
public string Id { get; set; }
public DateTime CreatedAt { get; set; }
public DateTime UpdatedAt { get; set; }
public string Name { get; set; }
public string Description { get; set; }
public string Img { get; set; }
public int Views { get; set; }
public string CreatorId { get; set; }
public Profile Creator { get; set;}
}