namespace CoolSprings.Contract;

public interface IEnquiryRepository
{
    Task AddEnquiry(Enquiry newEnquiry);
}
