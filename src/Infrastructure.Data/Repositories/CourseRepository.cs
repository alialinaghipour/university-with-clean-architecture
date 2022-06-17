using Application.Contracts.Repositories;
using Application.ViewModels.Course;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly UniversityDbContext _context;

    public CourseRepository(UniversityDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetCoursesViewModel>> GetAll()
    {
        return await _context.Courses
            .Select(c => new GetCoursesViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl
            })
            .ToListAsync();
    }

    public async Task<GetCourseByIdViewModel?> GetById(int id)
    {
        return await _context.Courses
            .Select(c=>new GetCourseByIdViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl
            })
            .SingleOrDefaultAsync(c=>c.Id==id);
    }
}