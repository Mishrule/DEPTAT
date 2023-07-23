﻿using DEPTAT.Application.DTOs.Course;
using DEPTAT.Application.DTOs.Examination;
using DEPTAT.Application.DTOs.Otp;
using DEPTAT.Application.Features.Examinations.Commands;
using DEPTAT.Application.Features.Examinations.Queries;
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;
using DEPTAT.Application.Features.Settings.Commands.CourseCommands;
using DEPTAT.Application.Features.Settings.Commands.DepartmentCommands;
using DEPTAT.Application.Features.Settings.Commands.OtpCommands;
using DEPTAT.Application.Features.Settings.Handlers.OtpHandlers;
using DEPTAT.Application.Features.Settings.Queries.AcademicYearQuery;
using DEPTAT.Application.Features.Settings.Queries.CourseQuery;
using DEPTAT.Application.Features.Settings.Queries.DepartmentQuery;
using DEPTAT.Application.Features.Settings.Queries.OtpQuery;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DEPTAT.UI.Controllers
{
	public class ExaminationController : Controller
	{
		private readonly IMediator _mediator;

		public ExaminationController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> SearchStudent(string studentNumber)
		{
			var data = await _mediator.Send(new GetDebtorsByStudentNumberQuery(studentNumber));
			return Ok(data);
		}

		public async Task<IActionResult> Attendance()
		{
			var programmeList = await _mediator.Send(new GetProgrammesQuery());
			ViewBag.ProgrammeList = programmeList.Result?.OrderByDescending(o => o.Id).ToList();

			var academicYearList = await _mediator.Send(new GetAcademicYearsQuery());
			ViewBag.AcademicYearList = academicYearList.Result?.OrderByDescending(o => o.Id).ToList();


			return View();
		}

		public async Task<IActionResult> GetStudentByProgramme(int ProgrammeName)
		{
			var studentListList = await _mediator.Send(new GetStudentByProgrammeQuery(ProgrammeName));
			//var data = studentListList.Result?.OrderByDescending(o => o.StudentNumber).ToList();
			return Json(studentListList);
		}

		public async Task<IActionResult> ClockStudent()
		{
			//var studentListList = await _mediator.Send(new GetStudentByProgrammeQuery(studentNumber));
			//ViewBag.StudentList = studentListList.Result?.OrderByDescending(o => o.StudentNumber).ToList();
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ClockAttendance([FromBody] OtpDto data)
		{
			data.CurrentYear = DateTime.Now.Year;
			var command = new CreateAndUpdateOtpCommands()
			{
				OtpDto = data
			};
			var response = await _mediator.Send(command);
			return Ok(response);
			
		}

		public async Task<IActionResult> ViewOTP()
		{
			var otp = await _mediator.Send(new GetOtpsQuery());
			return View(otp.Result?.OrderByDescending(o => o.Id).ToList());
		}

		public async Task<IActionResult> ValidateOTP(string studentNumber, string otpCode)
		{
			var otp = await _mediator.Send(new GetValidateOTPQuery(studentNumber, otpCode));
			return Ok(otp);
		}

		[HttpPost]
		public async Task<IActionResult> TakeAttendance(CreateAttendanceDto createAttendance)
		{
			var command = new CreateAttendanceCommand
			{
				CreateAttendanceDto = createAttendance
			};
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> AttendanceList()
		{
			var attendanceList = await _mediator.Send(new GetAttendanceQuery());
			return View(attendanceList.Result?.OrderByDescending(o => o.Id).ToList());
			
		}

	}
}
	