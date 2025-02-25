namespace CoolSprings.Repository.Database;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public async Task<bool> AddCustomer(Customer customer)
    {
        try
        {
            using var db = Connect();
            return true;

        }
        catch (Exception ex)
        {
            throw;
        }
    }
}