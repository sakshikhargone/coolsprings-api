namespace CoolSprings.Contract.Repository;

public interface IProfileRepository
{
    Task AddProfile(Profile newProfile);

    Task<Profile> GetProfile(string phoneNo);
}