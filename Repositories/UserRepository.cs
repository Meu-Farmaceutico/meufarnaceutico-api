using MeufarmaceuticoApi.Domain;
using Dapper;
using System.Data;
using MeufarmaceuticoApi.Data;

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
       
        var user = _dapperService.Get<User>("[dbo].[GetUserById]", parms, commandType: CommandType.StoredProcedure);

        return user;
    }
}
