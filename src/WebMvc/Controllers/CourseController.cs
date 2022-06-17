using Application.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers;

[Authorize]
public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    
    public async Task<IActionResult> Index()
    {
        var model =await _courseService.GetAll();
        return View(model);
    }
    
    public async Task<IActionResult> ShowCourse(int id)
    {
        var course =await _courseService.GetById(id);
        if (course == null)
            return NotFound();

        return View(course);
    }
}