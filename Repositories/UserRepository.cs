using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain;
using Dapper;
using System.Data;
using System.Data.Common;

namespace MeufarmaceuticoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;
    private readonly IDapperRepository _dapperService;
    
    public UserRepository(DataContext context, IDapperRepository dapperRepository)
    {
        _dataContext = context;
        _dapperService  = dapperRepository;
    }

    public async Task<User> GetUserById(long id)
    {
        var parms = new DynamicParameters();
        parms.Add("UserById", id);
       
        var user = Task.FromResult(_dapperService.Get<ActionResult>("[dbo].[GetUserById]", parms, commandType: CommandType.StoredProcedure));

        return user;
    }
}
