using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace Practico7.Controllers
{
    public class CasasController : Controller
    {
        public IActionResult IngresoMetros()
        {
            return View();
        }

        public IActionResult MuestroCasas()
        {
            List<Casa> casas = Sistema.Instancia.CasasPorMetro(1000);
            ViewBag.TodasLasCasas = casas;

            return View();
        }


    }
}
