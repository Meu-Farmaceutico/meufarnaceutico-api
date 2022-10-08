using MeufarmaceuticoApi.Domain;

namespace MeufarmaceuticoApi.Services;

public interface ICustomerService
{
    Task<bool> CreateAsync(Customer customer);

    Task<Customer?> GetAsync(Guid id);

    Task<bool> UpdateAsync(Customer customer);

    Task<bool> DeleteAsync(Guid id);
}
