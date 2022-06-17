using Application.Contracts.Repositories;
using Domain.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UniversityDbContext _context;

    public UserRepository(UniversityDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> IsExistForLogin(string email, string password)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email &&
                           u.Password == password);
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsExistByUserName(string userName)
    {
        return await _context.Users.AnyAsync(u => u.UserName == userName);
    }

    public async Task<bool> IsExistByEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}