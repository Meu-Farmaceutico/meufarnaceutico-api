using MeufarmaceuticoApi.Domain;

namespace MeufarmaceuticoApi.Repositories;

public interface IUserRepository
{
    public Task<User> GetUserById(long id); 
}
