using MeufarmaceuticoApi.Contracts.Data;

namespace MeufarmaceuticoApi.Repositories;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(CustomerDto customer);

    Task<CustomerDto?> GetAsync(Guid id);

    Task<bool> UpdateAsync(CustomerDto customer);

    Task<bool> DeleteAsync(Guid id);
}
