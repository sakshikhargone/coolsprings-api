

using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class EnquiryRepository:BaseRepository,IEnquiryRepository
{
    public async Task AddEnquiry(Enquiry newEnquiry)
    {
        var sql = """
                   INSERT INTO Enquiry( Email, Message, CreatedAt,ContactNo)
                  VALUES( @Email, @Message, @CreatedAt,@ContactNo )
                  """;
        using var db = Connect();
        await db.ExecuteAsync(sql, new
        {
            
            Email = newEnquiry.Email,
            Message = newEnquiry.Message,
            CreatedAt = newEnquiry.CreatedAt,
            ContactNo = newEnquiry.ContactNo
        });
    }
}
