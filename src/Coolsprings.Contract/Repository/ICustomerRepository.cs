namespace CoolSprings.Contract.Repository;

public interface ICustomerRepository
{
    Task AddCustomer(Customer newCustomer);

    Task<Customer> GetCustomer(string CustomerPhone);

    Task UpdateCustomer(TokenCredentialDTO credential);

    Task<CustomerHistoryDTO> GetCustomerHistory(Guid customerId);

    Task<Customer> GetCustomerByBookingId(Guid bookingId);
}