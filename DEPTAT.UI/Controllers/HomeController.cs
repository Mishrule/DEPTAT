using DEPTAT.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DEPTAT.Application.Features.Examinations.Queries.DebtorQuery;
using DEPTAT.Application.Features.Settings.Queries.OtpQuery;
using DEPTAT.Application.Features.Settings.Queries.ProgrammesQuery;
using DEPTAT.Application.Features.Students.Queries.StudentQuery;
using DEPTAT.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace DEPTAT.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly DeptatDbContext _db;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, DeptatDbContext db)
        {
            _logger = logger;
            _mediator = mediator;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            await TotalData();

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int TotalUsers()
        {
            return  _db.Users.Count();
        }


        public async Task TotalData()
        {
            var totalStudents = await _mediator.Send(new GetTotalStudentsQuery());
            ViewBag.TotalStudents = totalStudents;

            var totalUsers = TotalUsers();
            ViewBag.TotalUsers = totalUsers;

            var totalOtps = await _mediator.Send(new GetTotalOTPQuery());
            ViewBag.TotalOtps = totalOtps;

            var totalProgramme = await _mediator.Send(new GetTotalProgrammeQuery());
            ViewBag.TotalProgrammes = totalProgramme;


            var LastSevenOTPGen = await _mediator.Send(new GetOtpsQuery());
            ViewBag.LastSevenOTPGen = LastSevenOTPGen.Result?.TakeLast(7);

            var lastFiveStudentOwing = await _mediator.Send(new GetDebtorsQuery());
            ViewBag.TotalLastOwing = lastFiveStudentOwing.Result?.TakeLast(5).Where(q => q.PaymentStatus == "Owing");

            var lastFiveStudentFullyPaid = await _mediator.Send(new GetDebtorsQuery());
            ViewBag.TotalLastFully = lastFiveStudentFullyPaid.Result?.TakeLast(5).Where(q => q.PaymentStatus == "Fully Paid");

            var students = await _mediator.Send(new GetStudentsQuery());
            ViewBag.Students = students.Result.TakeLast(6).ToList();

        }
    }
}