using Application.ViewModels.Course;

namespace Application.Contracts.Services;

public interface ICourseService
{
    Task<List<GetCoursesViewModel>> GetAll();
    Task<GetCourseByIdViewModel?> GetById(int id);
}