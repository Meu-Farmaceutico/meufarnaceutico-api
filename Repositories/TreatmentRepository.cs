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

public class TreatmentRepository : ITreatmentRepository
{
    private readonly DataContext _dataContext;
    private readonly IDapperRepository _dapperService;

    public TreatmentRepository(DataContext context, IDapperRepository dapperRepository)
    {
        _dataContext = context;
        _dapperService = dapperRepository;
    }

    public async Task<bool> CreateTreatment(Treatment treatment)
    {
        var parms = new DynamicParameters();
        parms.Add("TreatmentId", treatment.TreatmentId);
        parms.Add("TreatmentName", treatment.Name);
        parms.Add("TratmentInitialDate", treatment.InitialDate);
        parms.Add("TreatmentFinalDate", treatment.FinalDate);

        var treatment = Task.FromResult(_dapperService.Insert<ActionResult>("[dbo].[InsertCreatment]", parms, commandType: CommandType.StoredProcedure));

        return treatment;
    }

    public async Task<Treatment> GetTreatmentById(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("TreatmentId", id);
       
        var treatment = Task.FromResult(_dapperService.Get<ActionResult>("[dbo].[GetTreatmentId]", parms, commandType: CommandType.StoredProcedure));

        return treatment;
    }

    public async Task<Enumerable<Treatment>> GetTreatmentList()
    {
        var treatment = Task.FromResult(_dapperService.GetAll<ActionResult>("[dbo].[GetAllTreatment]", null, commandType: CommandType.StoredProcedure));

        return treatment;
    }

    public async Task<bool> UpdateTreatment(Treatment treatment)
    {
       var parms = new DynamicParameters();
        parms.Add("TreatmentId", treatment.TreatmentId);
        parms.Add("TreatmentName", treatment.Name);
        parms.Add("TratmentInitialDate", treatment.InitialDate);
        parms.Add("TreatmentFinalDate", treatment.FinalDate);

        var treatment = Task.FromResult(_dapperService.Update<ActionResult>("[dbo].[UpdateTreatment]", parms, commandType: CommandType.StoredProcedure));

        return treatment;
    }

    public async Task<bool> DeleteTreatment(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("TreatmentId", id);
       
        var treatment = Task.FromResult(_dapperService.Delete<ActionResult>("[dbo].[DeleteTreatment]", parms, commandType: CommandType.StoredProcedure));

        return treatment;
    }
}
