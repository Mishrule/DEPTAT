using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	public class CourseController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public CourseController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> Index()
		{
			var programmeList = await _mediator.Send(new GetProgrammesQuery());
			ViewBag.ProgrammeList = programmeList.Result?.OrderByDescending(o => o.Id).ToList();

			var CourseName = await _mediator.Send(new GetCoursesQuery());
			return View(CourseName.Result?.OrderByDescending(o => o.Id).ToList());
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<CreateCourseDto>>> CreateCourse([FromBody] CreateCourseDto createCourse)
		{
			var command = new CreateCourseCommand
			{
				CreateCourseDto = createCourse
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}



		[HttpGet]
		public async Task<IActionResult> GetCourse(int Id)
		{
			var Course = await _mediator.Send(new GetCourseByIdQuery(Id));
			return Ok(Course);


		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateCourseDto>>> UpdateCourse([FromBody] UpdateCourseDto updateCourse)
		{
			var command = new UpdateCourseCommand
			{
				UpdateCourseDto = updateCourse
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteCourse(int id)
		{
			var command = new DeleteCourseCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
