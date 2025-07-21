

using CoolSprings.Contract.Repository;

namespace CoolSprings.API.Controllers;
[ApiController]
[ApiException]
[Route("api/v1/files")]
public class FileController : ControllerBase
{
    private readonly IProfileRepository _profileContract;
    public FileController(IProfileRepository profileContract)
    {
        _profileContract = profileContract;
    }
    [HttpPost]
    public async Task<IActionResult> AddFile([FromForm] ProfileData profileData)
{
        
        string fileName = profileData.ProfilePic.FileName;
        string fileExtension = fileName.Substring(fileName.LastIndexOf("."));
        if(fileExtension == ".jpg" || fileExtension == ".png")
        {
           string newFile = profileData.CustomerPhone + fileExtension;
            var filePath = Path.GetFullPath("~").Replace("~", "") + "wwwroot/Profiles\\" + newFile;
            using var stream = new FileStream(filePath, FileMode.Create);
           await profileData.ProfilePic.CopyToAsync(stream);
            var p = new Profile();
            {
                p.PId = Guid.NewGuid();
                p.FileName = fileExtension;
                p.PhoneNo = profileData.CustomerPhone;
            }
            await _profileContract.AddProfile(p);
           
        }
        return Ok(new ApiResponse(HttpStatusCode.Created, true, message: "profile uploaded"));
    }
    [HttpGet]
    public async Task<IActionResult> GetProfile([FromHeader]string phoneNo)
    {
        var profile = await _profileContract.GetProfile(phoneNo);
        return Ok(new ApiResponse(HttpStatusCode.Found, true, profile));

    }
}
