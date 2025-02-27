namespace CoolSprings.Repository.Database;

public class CustomerRepository : BaseRepository, ICustomerRepository
{
    public async Task AddCustomer(Customer customer)
    {
        try
        {

            var query = @"Insert into Customer
                         (CustomerId, CustomerName, CustomerPhone)
                          values(@CustomerId, @CustomerName, @CustomerPhone)";
            using(var db = Connect())
            {
                await db.ExecuteAsync(query, new
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    CustomerPhone = customer.CustomerPhone


                });
            }
           
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}