using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.DTOs.Debtors;
using DEPTAT.Application.Features.Examinations.Commands.DebtorsCommand;
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Features.Settings.Commands.FacultyCommands;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace DEPTAT.UI.Controllers
{
	[Authorize]
    public class DebtorsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DebtorsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }
		[Authorize(Roles = "Admin, Account")]
        public async Task<IActionResult> Index()
        {
            var debtorList = await _mediator.Send(new GetDebtorsQuery());
            return View(debtorList.Result?.OrderByDescending(o => o.Id).ToList());
            
        }
		[Authorize]

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                ModelState.AddModelError("file", "Please select a valid Excel file.");
                return View("Index");
            }

            var command = new CreateDebtorCommand()
            {
                CreateDebtorsDto = new CreateDebtorsDto()
                {
                    File = file
                }
            };
           
            
            var response = await _mediator.Send(command);
            

            return View(response);
        }
		[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDebtor(string Id)
        {
            var debtor = await _mediator.Send(new GetDebtorsByStudentNumberQuery(Id));
            return Ok(debtor);

        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<UpdateDebtorsDto>>> UpdateDebtor([FromBody] UpdateDebtorsDto updateDebtorsDto)
        {
            var command = new UpdateDebtorCommand()
            {
                UpdateDebtorsDto = updateDebtorsDto
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
