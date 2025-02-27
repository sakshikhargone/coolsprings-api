namespace CoolSprings.Repository.Contract;

public interface ICustomerRepository
{
    Task AddCustomer(Customer customer);
}