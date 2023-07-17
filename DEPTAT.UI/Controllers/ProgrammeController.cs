using DEPTAT.Application.DTOs.Programme;
using DEPTAT.Application.Features.Settings.Commands.ProgrammeCommands;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	public class ProgrammeController : Controller
	{
		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ProgrammeController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> Index()
		{
			var departmentList = await _mediator.Send(new GetDepartmentsQuery());
			ViewBag.DepartmentList = departmentList.Result?.OrderByDescending(o => o.Id).ToList();


			var ProgrammeName = await _mediator.Send(new GetProgrammesQuery());
			return View(ProgrammeName.Result?.OrderByDescending(o => o.Id).ToList());
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<CreateProgrammeDto>>> CreateProgramme([FromBody] CreateProgrammeDto createProgramme)
		{
			var command = new CreateProgrammeCommand
			{
				CreateProgrammeDto = createProgramme
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}



		[HttpGet]
		public async Task<IActionResult> GetProgramme(int Id)
		{
			var Programme = await _mediator.Send(new GetProgrammeByIdQuery(Id));
			return Ok(Programme);


		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateProgrammeDto>>> UpdateProgramme([FromBody] UpdateProgrammeDto updateProgramme)
		{
			var command = new UpdateProgrammeCommand
			{
				UpdateProgrammeDto = updateProgramme
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteProgramme(int id)
		{
			var command = new DeleteProgrammeCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> Detailed()
		{
			var ProgrammeName = await _mediator.Send(new GetProgrammesQuery());
			return View(ProgrammeName.Result?.OrderByDescending(o => o.Id).ToList());
		}

	}
}

