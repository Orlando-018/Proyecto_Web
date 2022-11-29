using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Primeruso.Models;
using Primeruso.Models.dbModels;
using Primeruso.ViewModels;
using System.Diagnostics;

namespace Primeruso.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProyectoPWContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, ProyectoPWContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Sugerencias()
        {
            return View();
        }

        public IActionResult Administracion()
        {
            return View();
        }

        public IActionResult Comentarios()
        {
            return View();
        }

        public IActionResult ReservacionUsuarios()
        {
            List<Hotel> listahoteles = _dbcontext.Hotels.ToList();
            List<SelectListItem> lstHoteles = new List<SelectListItem>();

            foreach(Hotel hotel in listahoteles)
            {
                lstHoteles.Add(new SelectListItem { Value = hotel.IdHotel.ToString(), Text = hotel.NombreHotel });
            }

            ReservaViewModel rvm = new ReservaViewModel
            {
                ListaHoteles = lstHoteles
            };
            return View(rvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}