using Microsoft.AspNetCore.Mvc;
using PruebaTESI.Business;
using PruebaTESI.Entities.DTO;
using PruebaTESI.Models;
using System.Diagnostics;

namespace PruebaTESI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            Pacientes_OP pacientes = new Pacientes_OP();
            List<PAZIENTI_DTO> lstPacientes=pacientes.getLstPacientes();
            return View(lstPacientes);
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
