using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public interface ITreatmentRepository
{
    public bool CreateTreatment(Treatment treatment);

    public Treatment GetTreatmentById(long id);

    Enumerable<Treatment> GetTreatmentList();

    void UpdateTreatment(Treatment treatment);

    void DeleteTreatment(long id);
}
