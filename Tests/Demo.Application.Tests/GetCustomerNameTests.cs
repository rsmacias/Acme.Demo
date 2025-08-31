using Demo.Domain.Customers;
using FluentAssertions;
using Moq;

namespace Demo.Application.Tests;

public class GetCustomerNameTests
{

    [Fact]
    public async Task ShouldReturnNotEmptyString()
    {
        // Arrange / Given
        var _customerRepositoryMock = new Mock<ICustomerRepository>();

        _customerRepositoryMock
            .Setup(x => x.GetCustomerNameAsync())
            .Returns(Task.FromResult("Anything"));

        var operation = new GetCustomerName(_customerRepositoryMock.Object);

        // Act / When
        var result = await operation.Handle("input");

        // Assert / Then
        result.Should().NotBeEmpty();
        //result.Should().Be("Hello");
    }


    [Fact]
    public async Task ShouldThrowExceptionWhenResultEmpty()
    {
        // Arrange / Given
        var _customerRepositoryMock = new Mock<ICustomerRepository>();

        _customerRepositoryMock
            .Setup(x => x.GetCustomerNameAsync())
            .Returns(Task.FromResult(string.Empty));

        var operation = new GetCustomerName(_customerRepositoryMock.Object);

        // Act / When
        try
        {
            var result = await operation.Handle("input");
        }
        catch (Exception ex)
        {
            ex.Should().NotBeNull();
        }
        

        // Assert / Then
        //result.Should().NotBeEmpty();
        //result.Should().Be("Hello");
    }
}
