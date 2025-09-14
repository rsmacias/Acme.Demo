using Demo.Domain.Abstractions;
using Demo.Domain.Customers;
using Demo.Domain.Shared;
using MediatR;
using System.Security.AccessControl;

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
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
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
    public async Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var customerAddress = Address.Create(request.StreetCity, request.StreetAddress, request.StreetZipCode);

            var customerEmail = new Email(request.Email);

            var customer = Customer.Create(request.Name, request.LastName, customerAddress, customerEmail);

            var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(customerEmail);

            if(existingCustomer is not null)
            {
                throw new Exception("Customer already exists");
            }

            _customerRepository.Add(customer);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateCustomerResponse()
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                Email = customer.Email.Value,
                StreetAddress = customer.Address.Street,
                StreetCity = customer.Address.City,
                StreetZipCode = customer.Address.ZipCode
            };
        }
        catch (Exception ex)
        {
            //Task.FromException(ex);
            throw;
        }
    }
}
