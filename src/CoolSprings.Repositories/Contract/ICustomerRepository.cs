namespace CoolSprings.Repository.Contract;

public interface ICustomerRepository
{
    Task<bool> AddCustomer(Customer customer);
}