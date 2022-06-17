using Application.Contracts.Repositories;
using Application.Contracts.Services;
using Application.ViewModels.Course;

namespace Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<GetCoursesViewModel>> GetAll()
    {
        return await _courseRepository.GetAll();
    }

    public async Task<GetCourseByIdViewModel?> GetById(int id)
    {
        return await _courseRepository.GetById(id);
    }
}