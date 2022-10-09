using MeufarmaceuticoApi.Domain.Common;
using Dapper;
using System.Data;
using MeufarmaceuticoApi.Data;

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
        parms.Add("TreatmentName", treatment.Name, DbType.String);
        parms.Add("TratmentInitialDate", treatment.InitialDate, DbType.DateTime);
        parms.Add("TreatmentFinalDate", treatment.FinalDate, DbType.DateTime);

        var treat = _dapperService.Insert<bool>("[dbo].[InsertCreatment]", parms, commandType: CommandType.StoredProcedure);

        return treat;
    }

    public async Task<Treatment> GetTreatmentById(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("TreatmentId", id);
       
        var treatment = _dapperService.Get<Treatment>("[dbo].[GetTreatmentId]", parms, commandType: CommandType.StoredProcedure);

        return treatment;
    }

    public List<Treatment> GetTreatmentList()
    {
        var treatment = _dapperService.GetAll<List<Treatment>>("[dbo].[GetAllTreatment]", null, commandType: CommandType.StoredProcedure);

        List<Treatment> list = new List<Treatment>();

        foreach(List<Treatment> item in treatment)
        {
            Treatment treatment1 = new Treatment()
            {
                Name = item[0].Name,
                InitialDate = item[0].InitialDate,
                FinalDate = item[0].FinalDate,
            };

            list.Add(treatment1);
        }

        return list;
    }

    public async Task<bool> UpdateTreatment(Treatment treatment)
    {
        try
        {
            var parms = new DynamicParameters();
            parms.Add("TreatmentId", treatment.TreatmentId);
            parms.Add("TreatmentName", treatment.Name, DbType.String);
            parms.Add("TratmentInitialDate", treatment.InitialDate, DbType.DateTime);
            parms.Add("TreatmentFinalDate", treatment.FinalDate, DbType.DateTime);

            var treat = _dapperService.Update<bool>("[dbo].[UpdateTreatment]", parms, commandType: CommandType.StoredProcedure);

            return treat;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> DeleteTreatment(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("TreatmentId", id);
       
        var treatment = _dapperService.Delete<bool>("[dbo].[DeleteTreatment]", parms, commandType: CommandType.StoredProcedure);

        return treatment;
    }
}
