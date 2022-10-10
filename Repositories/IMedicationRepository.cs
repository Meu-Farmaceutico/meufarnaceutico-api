using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public interface IMedicationRepository
{
    public Task<Medication> GetMedicationById(long id);

    public Task<List<Medication>> GetAllMedication();
}
