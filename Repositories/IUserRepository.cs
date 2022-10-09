using MeufarmaceuticoApi.Contracts.Data;
using MeufarmaceuticoApi.Domain;

namespace MeufarmaceuticoApi.Repositories;

public interface IUserRepository
{
    public User GetUserById(long id); 
}
