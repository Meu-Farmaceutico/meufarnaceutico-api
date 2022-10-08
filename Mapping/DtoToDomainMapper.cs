using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Mapping;

public static class DtoToDomainMapper
{
    public static Customer ToCustomer(this CustomerDto customerDto)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.Parse(customerDto.Id)),
            Email = EmailAddress.From(customerDto.Email),
            Username = Username.From(customerDto.Username),
            FullName = FullName.From(customerDto.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(customerDto.DateOfBirth))
        };
    }
}
