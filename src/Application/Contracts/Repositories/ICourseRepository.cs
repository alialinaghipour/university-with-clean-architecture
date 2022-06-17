using Application.ViewModels.Course;

namespace Application.Contracts.Repositories;

public interface ICourseRepository
{
    Task<List<GetCoursesViewModel>> GetAll();
    Task<GetCourseByIdViewModel?> GetById(int id);
}