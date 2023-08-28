// namespace KeeperFinal.Controllers;
// [ApiController]
// [Route("api/[controller]")]
// public class ProfilesController : ControllerBase
// {
//   private readonly ProfilesService _profileService;
//   private readonly Auth0Provider _auth0Provider;

//   public ProfilesController(ProfilesService profileService, Auth0Provider auth0Provider)
//   {
//     _profileService = profileService;
//     _auth0Provider = auth0Provider;
//   }

//   [HttpGet("{profileId}")]
//   public async Task<ActionResult<Profile>> GetProfileById(int profileId)
//   {
//     try
//     {
//       Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
//       Profile profile = _profileService.GetProfileById(profileId, userInfo.Id);
//       return Ok(profile);
//     }
//     catch (Exception e)
//     {
//       return BadRequest(e.Message);
//     }
//   }
// }