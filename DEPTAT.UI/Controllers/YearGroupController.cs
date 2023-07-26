using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DEPTAT.Application.DTOs.YearGroup;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Domain.Entities;
using DEPTAT.Application.Features.Settings.Queries.YearGroupQueries;

namespace DEPTAT.UI.Controllers
{
	[Authorize(Roles = "Admin")]
    public class YearGroupController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public YearGroupController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateYearGroupDto>>> CreateYearGroups([FromBody]CreateYearGroupDto createYearGroup)
        {
            var command = new CreateYearGroupCommand
            {
                CreateYearGroupDto = createYearGroup
            };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> CreateYearGroup()
        {
			var yeargroups = await _mediator.Send(new GetYearGroupsQueries());
			return View(yeargroups.Result.OrderByDescending(o=>o.Id).ToList());
        }

		[HttpGet]
		public async Task<IActionResult> GetYearGroup(int Id)
		{
			var yearGroup = await _mediator.Send(new GetYearGroupByIdQuery(Id));
			return Ok(yearGroup);

			
		}

		[HttpPut]
		public async Task<ActionResult<BaseResponse<UpdateYearGroupDto>>> UpdateYearGroups([FromBody] UpdateYearGroupDto updateYearGroup)
		{
			var command = new UpdateYearGroupCommand
			{
				UpdateYearGroupDto = updateYearGroup
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}
		[HttpDelete]
		public async Task<ActionResult> DeleteYearGroup(int id)
		{
			var command = new DeleteYearGroupCommand { Id = id };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
