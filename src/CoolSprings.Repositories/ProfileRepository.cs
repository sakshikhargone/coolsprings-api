using CoolSprings.Contract.Repository;

namespace CoolSprings.Repository;

public class ProfileRepository : BaseRepository, IProfileRepository
{
    public async Task AddProfile(Profile newProfile)
    {
        var sql = """
                  INSERT INTO Profile(PId,FileName,PhoneNo)
                  Values(NewId(), @FileName, @PhoneNo)
                  """;
        using var db = Connect();
        await db.ExecuteAsync(sql, new
        {
            PId = newProfile.PId,
            FileName = newProfile.FileName,
            PhoneNo = newProfile.PhoneNo
        }, commandTimeout: commandTimeoutSeconds);
    }

    public async Task<Profile> GetProfile(string phoneNo)
    {
        try
        {
            var sql = """
                  SELECT * FROM Profile
                  WHERE PhoneNo = @phoneNo
                """;
            using var db = Connect();
            var profileData = await db.QueryFirstOrDefaultAsync<Profile>(sql, new { phoneNo }, commandTimeout: commandTimeoutSeconds);
            return profileData;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}