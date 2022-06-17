using Application.ViewModels.Users;

namespace Application.Contracts.Services;

public interface IUserService
{
    Task<CheckUserViewModel> Check(string userName, string email);
    Task<int> Register(RegisterUserViewModel model);
    Task<bool> IsExist(string email, string password);
}