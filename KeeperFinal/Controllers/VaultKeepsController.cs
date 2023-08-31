namespace KeeperFinal.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{
  private readonly VaultKeepsService _vaultKeepsService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultService;

  public VaultKeepsController(VaultKeepsService vaultKeepsService, Auth0Provider auth0Provider, VaultsService vaultsService)
  {
    _vaultKeepsService = vaultKeepsService;
    _auth0Provider = auth0Provider;
    _vaultService = vaultsService;
  }

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultService.GetVaultById(vaultKeepData.VaultId);
      if (vault.CreatorId != userInfo.Id)
      {
        throw new Exception("This isn't your vault buddy!");
      }
      vaultKeepData.CreatorId = userInfo.Id;
      vaultKeepData.AccountId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.CreateVaultKeep(vaultKeepData);
      return Ok(vaultKeep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [Authorize]
  [HttpDelete("{vaultKeepId}")]
  public async Task<ActionResult<string>> RemoveVaultKeep(int vaultKeepId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      VaultKeep vaultKeep = _vaultKeepsService.GetVaultKeepById(vaultKeepId);
      if (vaultKeep.CreatorId != userInfo.Id)
      {
        throw new Exception("This isn't your vault buddy!");
      }
      _vaultKeepsService.RemoveVaultKeep(vaultKeepId, userInfo.Id);
      return Ok("Vault has been closed");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}