using DEPTAT.Application.DTOs.Department;
using DEPTAT.Application.Features.Settings.Commands.DepartmentCommands;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Features.Settings.Queries.FacultyQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public DepartmentController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> Index()
		{
			var facultyList = await _mediator.Send(new GetFacultiesQuery());
			ViewBag.FacultyList = facultyList.Result?.OrderByDescending(o => o.Id).ToList();
			var DepartmentName = await _mediator.Send(new GetDepartmentsQuery());
			return View(DepartmentName.Result?.OrderByDescending(o => o.Id).ToList());
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<CreateDepartmentDto>>> CreateDepartment([FromBody] CreateDepartmentDto createDepartment)
		{
			var command = new CreateDepartmentCommand
			{
				CreateDepartmentDto = createDepartment
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}



		[HttpGet]
		public async Task<IActionResult> GetDepartment(int Id)
		{
			var Department = await _mediator.Send(new GetDepartmentByIdQuery(Id));
			return Ok(Department);


		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateDepartmentDto>>> UpdateDepartment([FromBody] UpdateDepartmentDto updateDepartment)
		{
			var command = new UpdateDepartmentCommand
			{
				UpdateDepartmentDto = updateDepartment
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteDepartment(int id)
		{
			var command = new DeleteDepartmentCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
