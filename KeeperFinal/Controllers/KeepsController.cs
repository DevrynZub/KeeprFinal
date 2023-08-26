namespace KeeperFinal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth0Provider;

  public KeepsController(KeepsService keepsService, Auth0Provider auth0Provider)
  {

    _keepsService = keepsService;

    _auth0Provider = auth0Provider;
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

  [HttpGet("{keepId}")]
  public ActionResult<Keep> GetKeepById(int keepId)
  {
    try
    {
      Keep keep = _keepsService.GetKeepById(keepId);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> GetKeeps()
  {
    try
    {
      List<Keep> keeps = _keepsService.GetKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  public ActionResult<Keep> UpdateKeep(int keepId, [FromBody] Keep keepData)
  {
    try
    {
      Keep keep = _keepsService.UpdateKeep(keepId, keepData);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<string>> RemoveKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _keepsService.RemoveKeep(keepId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

}