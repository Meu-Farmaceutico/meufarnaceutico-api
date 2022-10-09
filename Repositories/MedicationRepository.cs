using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain.Common;

namespace MeufarmaceuticoApi.Repositories;

public class MedicationRepository : IMedicationRepository
{
    private readonly DataContext _dataContext;

    public MedicationRepository(DataContext context)
    {
        _dataContext = context;
    }

    public Treatment GetTreatmentById(long id)
    {

    }

    public Enumerable<Treatment> GetTreatmentList()
    {

    }
}
