using CoolSprings.Contract.Repository;

namespace CoolSprings.API.Controllers
{
    [ApiController]
    [ApiException]
    [Route(ApiEndpoint.Enquiry.EnquiryBase)]
    public class EnquiryController:ControllerBase
    {
        private readonly IEnquiryRepository _enquiryContract;
        public EnquiryController(IEnquiryRepository enquiryContract)
        {
            _enquiryContract = enquiryContract;
        }
        [HttpPost]
        public async Task<IActionResult> AddEnquiry([FromBody]Enquiry newEnquiry)
        {
            var e = new Enquiry();
            {
                
                e.Email = newEnquiry.Email;
                e.ContactNo = newEnquiry.ContactNo;
                e.Message = newEnquiry.Message;
                e.CreatedAt = DateTime.Now;
            }
            await _enquiryContract.AddEnquiry(e);
            return Ok(new ApiResponse(HttpStatusCode.Created, true));
        }
    }
}
