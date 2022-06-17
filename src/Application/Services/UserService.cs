using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.Security;
using Application.Tools;
using Application.ViewModels.Users;
using Domain.Models;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CheckUserViewModel> Check(string userName, string email)
    {
        var userNameValid = await _userRepository
            .IsExistByUserName(userName);
        var emailValid = await _userRepository
            .IsExistByEmail(email.TrimToLower());

        if (userNameValid && emailValid)
            return CheckUserViewModel.UserNameAndEmailNotValid;
        if (emailValid)
            return CheckUserViewModel.EmailNotValid;
        if (userNameValid)
            return CheckUserViewModel.UserNameNotValid;

        return CheckUserViewModel.Ok;
    }

    public async Task<int> Register(RegisterUserViewModel model)
    {
        var user = new User
        {
            Email = model.Email,
            Password = model.Password,
            UserName = model.UserName
        };
        
        _userRepository.Add(user);
        await _userRepository.Save();

        return user.UserId;
    }

    public Task<bool> IsExist(string email, string password)
    {
        return _userRepository.IsExistForLogin(
            email.TrimToLower(),
            password.Hash());
    }
}