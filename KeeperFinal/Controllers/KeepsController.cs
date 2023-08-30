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
  public async Task<ActionResult<Keep>> GetKeepById(int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.GetKeepByIdAndIncreaseViews(keepId, userInfo?.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public async Task<ActionResult<List<Keep>>> GetKeeps()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Keep> keeps = _keepsService.GetKeeps();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> UpdateKeep(int keepId, [FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      keepData.Id = keepId;
      Keep keep = _keepsService.UpdateKeep(keepData, userInfo.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{keepId}")]
  public async Task<ActionResult<string>> RemoveKeep(int keepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.RemoveKeep(keepId, userInfo.Id);
      return Ok($"{keepId} was deleted");
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

}