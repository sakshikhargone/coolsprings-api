using CoolSprings.Contract.Repository;
using CoolSprings.Model;
using CoolSprings.Repository;
using Moq;
using NUnit.Framework;
using System.Data;

namespace CoolSprings.Repositories.UnitTests;

public class CustomerRepositoryTests
{
    private readonly ICustomerRepository _customerContract;
   
    public CustomerRepositoryTests()
    {
        _customerContract = new FakeCustomerRepository();

    }
    [Test]
    public async Task GetCustomer_Return_CustomerData()
    {
        string customerPhone = "9012348900";
        var result = await _customerContract.GetCustomer(customerPhone);
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.InstanceOf<Customer>());
    }
    [Test]
    public async Task GetCustomerReturnNull()
    {
        string customerPhone = "";
        var result = await _customerContract.GetCustomer(customerPhone);
        Assert.That(result, Is.Null);
    }

}


public class FakeCustomerRepository : CustomerRepository, ICustomerRepository {
    private new Mock<IDbConnection> _fakeConnection;

    public override IDbConnection Connect()
    {
        _fakeConnection = new Mock<IDbConnection>();
        return _fakeConnection.Object;
    }
}

