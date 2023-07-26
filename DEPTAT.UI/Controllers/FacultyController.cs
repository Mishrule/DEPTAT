using DEPTAT.Application.DTOs.AcademicYear;
using DEPTAT.Application.DTOs.Faculty;
using DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery;
using DEPTAT.Application.Features.Settings.Queries.FacultyQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class FacultyController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public FacultyController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> Index()
		{
			var facultyName = await _mediator.Send(new GetFacultiesQuery());
			return View(facultyName.Result?.OrderByDescending(o => o.Id).ToList());
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<CreateFacultyDto>>> CreateFaculty([FromBody] CreateFacultyDto createFaculty)
		{
			var command = new CreateFacultyCommand
			{
				CreateFacultyDto = createFaculty
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		

		[HttpGet]
		public async Task<IActionResult> GetFaculty(int Id)
		{
			var faculty = await _mediator.Send(new GetFacultyByIdQuery(Id));
			return Ok(faculty);


		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateFacultyDto>>> UpdateFaculty([FromBody] UpdateFacultyDto updateFaculty)
		{
			var command = new UpdateFacultyCommand
			{
				UpdateFacultyDto = updateFaculty
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteFaculty(int id)
		{
			var command = new DeleteFacultyCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}

