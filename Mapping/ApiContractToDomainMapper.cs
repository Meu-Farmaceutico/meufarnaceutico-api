using MeufarmaceuticoApi.Contracts.Requests;
using MeufarmaceuticoApi.Domain;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CreateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.NewGuid()),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(request.Id),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }
}
