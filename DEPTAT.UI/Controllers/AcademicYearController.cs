using DEPTAT.Application.DTOs.AcademicYear;
using DEPTAT.Application.Features.Settings.Commands.AcademicYearCommands;
using DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	public class AcademicYearController : Controller
	{
		

		private readonly IMediator _mediator;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AcademicYearController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
		{
			_mediator = mediator;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<IActionResult> Index()
		{
			var AcademicYears = await _mediator.Send(new GetAcademicYearsQuery());
			return View(AcademicYears.Result?.OrderByDescending(o => o.Id).ToList());
		}

		[HttpPost]
		public async Task<ActionResult<BaseResponse<CreateAcademicYearDto>>> CreateAcademicYear([FromBody] CreateAcademicYearDto createAcademicYear)
		{
			var command = new CreateAcademicYearCommand
			{
				CreateAcademicYearDto = createAcademicYear
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		//[HttpGet]
		//public async Task<IActionResult> CreateAcademicYear()
		//{
		//	var AcademicYears = await _mediator.Send(new GetAcademicYearsQuery());
		//	return View(AcademicYears.Result.OrderByDescending(o => o.Id).ToList());
		//}

		[HttpGet]
		public async Task<IActionResult> GetAcademicYear(int Id)
		{
			var AcademicYear = await _mediator.Send(new GetAcademicYearByIdQuery(Id));
			return Ok(AcademicYear);


		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateAcademicYearDto>>> UpdateAcademicYear([FromBody] UpdateAcademicYearDto updateAcademicYear)
		{
			var command = new UpdateAcademicYearCommand
			{
				UpdateAcademicYearDto = updateAcademicYear
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteAcademicYear(int id)
		{
			var command = new DeleteAcademicYearCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}

}

