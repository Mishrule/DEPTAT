using DEPTAT.Application.DTOs.Student;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using DEPTAT.Application.Features.Settings.Commands.StudentCommands;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Features.Students.Commands.StudentCommands;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Application.Responses;
using DEPTAT.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
    public class StudentController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IMediator _mediator;

        public StudentController(IWebHostEnvironment webHostEnvironment, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }

        
        public async Task<IActionResult> Index()
        {
            var programmeList = await _mediator.Send(new GetProgrammesQuery());
            ViewBag.ProgrammeList = programmeList.Result?.OrderByDescending(o => o.Id).ToList();
            

            return View();
        }

        [HttpGet("/Student/GetStudent/{Id}")]
        public async Task<IActionResult> GetStudent()
        {
        

            var programmeList = await _mediator.Send(new GetProgrammesQuery());
            ViewBag.ProgrammeList = programmeList.Result?.OrderByDescending(o => o.Id).ToList();

                return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] CreateStudentDto createStudent, IFormFile imageUrl)
        {
            // Save the uploaded profile picture if provided
            if (imageUrl != null && imageUrl.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                imageUrl.CopyTo(new FileStream(filePath, FileMode.Create));
                createStudent.ImageUrl = uniqueFileName;
            }

            // Save the user to a database or any other storage
            var command = new CreateStudentCommand()
            {
                CreateStudentDto = createStudent
            };
            var response = await _mediator.Send(command);
            return Json(response); // Return the user's ID as JSON response
        }

        [HttpGet]
        public async Task<IActionResult> FetchStudent(int Id)
        {

            var student = await _mediator.Send(new GetStudentByIdQuery(Id));
            
          return Json(student);
        }

        [HttpGet]
        public async Task<IActionResult> Detailed()
        {
            var student = await _mediator.Send(new GetStudentsQuery());
            return View(student.Result?.OrderByDescending(o => o.Id).ToList());
        }

        [HttpGet("/Student/GetDetailedStudent/{Id}")]
        public async Task<IActionResult> GetDetailedStudent()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateStudentDto updateStudent, IFormFile imageUrl)
        {
            // Save the uploaded profile picture if provided
            if (imageUrl != null && imageUrl.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageUrl.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                imageUrl.CopyTo(new FileStream(filePath, FileMode.Create));
                updateStudent.ImageUrl = uniqueFileName;
            }

            // Save the user to a database or any other storage
            var command = new UpdateStudentCommand()
            {
                UpdateStudentDto = updateStudent
            };
            var response = await _mediator.Send(command);
            return Json(response); // Return the user's ID as JSON response
        }

        [HttpGet]
        public async Task<IActionResult> FetchDetailedStudent(int Id)
        {

            var student = await _mediator.Send(new GetStudentByIdQuery(Id));

            return Json(student);
        }

    }
}
