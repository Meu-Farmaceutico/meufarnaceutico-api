using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public interface IMedicationRepository
{
    public Task<Medication> GetMedicationById(long id);

    Task<Enumerable<Medication>> GetMedicationAll();
}
