using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;
using Dapper;
using System.Data;
using System.Data.Common;

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

    public async Task<Medication> GetTreatmentById(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("MedicationId", id);
       
        var medication = Task.FromResult(_dapperService.Get<ActionResult>("[dbo].[GetMedicationId]", parms, commandType: CommandType.StoredProcedure));

        return medication;
    }

    public async Task<Enumerable<Medication>> GetTreatmentList()
    {
        var medication = Task.FromResult(_dapperService.GetAll<ActionResult>("[dbo].[GetAllMedication]", null, commandType: CommandType.StoredProcedure));

        return medication;
    }
}
