﻿using Demo.Domain.Abstractions;

namespace Demo.Domain.Customers;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer?> GetCustomerByEmailAsync(Email email);
}
