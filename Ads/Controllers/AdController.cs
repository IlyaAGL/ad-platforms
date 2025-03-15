using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/ad")]
public class AdController : ControllerBase
{
    private AdService _adService;

    public AdController(AdService adService)
    {
        _adService = adService;
    }
    [HttpGet]
    public ActionResult<List<string>> getAdsByLocation([FromQuery] string location) {
        List<string> ads = _adService.getAdsByLocation(location);

        return Ok(ads);
    }

    [HttpPost("upload")]
    public IActionResult uploadRoutes(IFormFile file) {
        string status = _adService.upload(file);

        if(status == "Ok") {
            return Ok(status);
        }

        return BadRequest(status);
    }
}