using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public interface ITreatmentRepository
{
    public Task<bool> CreateTreatment(Treatment treatment);

    public Task<Treatment>GetTreatmentById(long id);

    public Task<Enumerable<Treatment>> GetTreatmentList();

    public Task<bool> UpdateTreatment(Treatment treatment);

    public Task<bool> DeleteTreatment(long id);
}
