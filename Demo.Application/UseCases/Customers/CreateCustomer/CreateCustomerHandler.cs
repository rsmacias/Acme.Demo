using Demo.Domain.Customers;
using Demo.Domain.Shared;
using MediatR;

namespace Demo.Application.Features.Customers.CreateCustomers;

public class CreateCustomerRequest : IRequest<CreateCustomerResponse>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string StreetAddress { get; set; }
    public string StreetZipCode { get; set; }
    public string StreetCity { get; set; }
    public string Email { get; set; }
}

public class CreateCustomerResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string StreetAddress { get; set; }
    public string StreetZipCode { get; set; }
    public string StreetCity { get; set; }
    public string Email { get; set; }
}


public sealed class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    //public void Handle(CreateCustomerRequest request)
    //{
    //    try
    //    {
    //        var address = Address.Create(
    //        request.StreetCity,
    //        request.StreetAddress,
    //        request.StreetZipCode);

    //        var email = new Email(request.Email);


    //        var customer = Customer.Create(
    //            request.Name,
    //            request.LastName,
    //            address,
    //            email
    //            );
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerAddress = Address.Create(request.StreetCity, request.StreetAddress, request.StreetZipCode);

            var customerEmail = new Email(request.Email);

            var customer = Customer.Create(request.Name, request.LastName, customerAddress, customerEmail);

            return Task.FromResult<CreateCustomerResponse>(new CreateCustomerResponse());
        }
        catch (Exception ex)
        {
            //Task.FromException(ex);
            throw;
        }
    }
}
