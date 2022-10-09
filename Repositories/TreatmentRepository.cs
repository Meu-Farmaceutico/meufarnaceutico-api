using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public class TreatmentRepository : ITreatmentRepository
{
    private readonly DataContext _dataContext;

    public TreatmentRepository(DataContext context)
    {
        _dataContext = context;
    }

    public bool CreateTreatment()
    {
        
    }

    public Treatment GetTreatmentById(long id)
    {

    }

    public Enumerable<Treatment> GetTreatmentList()
    {

    }

    public void UpdateTreatment(Treatment treatment)
    {
       
    }

    public void DeleteTreatment(long id)
    {
        
    }
}
