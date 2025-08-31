namespace Demo.Domain.Shared;

public record Address
{
    public string City { get; init; }
    public string Street { get; init; } 
    public string ZipCode { get; init; }

    private Address()
    {
        
    }

    public static Address Create(string city, string street, string zipCode)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ApplicationException("City invalid");

        ArgumentException.ThrowIfNullOrWhiteSpace(street, nameof(street));

        ArgumentException.ThrowIfNullOrWhiteSpace(zipCode, nameof(zipCode));

        return new Address
        {
            City = city,
            Street = street,
            ZipCode = zipCode
        };
    }
}
