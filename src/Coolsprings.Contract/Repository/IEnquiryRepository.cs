namespace CoolSprings.Contract.Repository;

public interface IEnquiryRepository
{
    Task AddEnquiry(Enquiry newEnquiry);
}
