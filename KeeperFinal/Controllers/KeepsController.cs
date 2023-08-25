
[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
private readonly KeepsService _keepsService;
private readonly Auth0Provider _auth0Provider;

public KeepsController(KeepsService _keepsService, Auth0Provider _auth0Provider)
{
_keepsService = keepsService;
_auth0Provider = auth0Proivder;
}

[Authorize]
[HttpPost]
public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
{
  try
  {
    Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
    keepData.CreatorId = userInfo.Id;
    Keep keep = _keepsService.CreateKeep(keepData);
    return Ok(keep);
  }
  catch (Exception e)
  {
  return BadRequest(e.Message);
  }
}



}