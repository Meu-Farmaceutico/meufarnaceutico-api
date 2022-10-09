using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public interface IMedicationRepository
{
    public Medication GetMedicationById(long id);

    Enumerable<Medication> GetMedicationAll();
}
