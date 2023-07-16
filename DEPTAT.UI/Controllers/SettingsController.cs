using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DEPTAT.Application.DTOs.YearGroup;
using DEPTAT.Application.Features.Settings.Commands.YearGroupCommands;
using DEPTAT.Domain.Entities;

namespace DEPTAT.UI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SettingsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
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
            return View();
        }
    }
}
