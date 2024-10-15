using MediatR;
using Microsoft.AspNetCore.Mvc;
using OBilet.Application.Features.BusLocation.Queries;
using OBilet.Web.Models;
using System.Diagnostics;

namespace OBilet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISender _mediator;

        public HomeController(ILogger<HomeController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(BusLocationQuery query)
        {
            var result = await _mediator.Send(query);
            return View(result.Value);
        }        
        
        public IActionResult Journey()
        {
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
    }
}
