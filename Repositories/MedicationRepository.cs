using MeufarmaceuticoApi.Domain.Common;
using Dapper;
using System.Data;
using MeufarmaceuticoApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MeufarmaceuticoApi.Repositories;

public class MedicationRepository : IMedicationRepository
{
    private readonly DataContext _dataContext;
    private readonly IDapperRepository _dapperService;

    public MedicationRepository(DataContext context, IDapperRepository dapperRepository)
    {
        _dataContext = context;
        _dapperService = dapperRepository;
    }

    public async Task<Medication> GetMedicationById(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("MedicationId", id);
       
        var medication = _dapperService.Get<Medication>("[dbo].[GetMedicationId]", parms, commandType: CommandType.StoredProcedure);

        return medication;
    }

    public async Task<List<Medication>> GetAllMedication()
    {
        var medication = _dapperService.GetAll<List<Medication>>("[dbo].[GetAllMedication]", null, commandType: CommandType.StoredProcedure);

        List<Medication> list = new List<Medication>();

        foreach (List<Medication> item in medication)
        {
            Medication medication1 = new Medication()
            {
                NameMedication = item[0].NameMedication,
                Description = item[0].Description
            };

            list.Add(medication1);
        }

        return list;
    }
}
