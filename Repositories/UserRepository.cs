using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MeufarmaceuticoApi.Contracts.Data;

namespace MeufarmaceuticoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;
    
    public UserRepository(DataContext context)
    {
        _dataContext = context;
    }

    public User GetUserById(long id)
    {

    }
}
