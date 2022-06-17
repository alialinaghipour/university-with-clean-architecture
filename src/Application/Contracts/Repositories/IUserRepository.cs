using Domain.Models;

namespace Application.Contracts.Repositories;

public interface IUserRepository
{
    Task<bool> IsExistForLogin(string email, string password);
    void Add(User user);
    Task<bool> IsExistByUserName(string userName);
    Task<bool> IsExistByEmail(string email);
    Task Save();
}