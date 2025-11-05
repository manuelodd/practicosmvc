using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace Practico7.Controllers
{
    public class BarriosController : Controller
    {
        public IActionResult Index()
        {
            List<Barrio> listaDeBarrios = Sistema.Instancia.GetBarrios();
            ViewBag.ListadoDeBarrios = listaDeBarrios;
            return View();
        }

        public IActionResult VerBarrio(int codigo)
        {
            Barrio unB = Sistema.Instancia.BuscarBarrio(codigo);
            ViewBag.ElBarrio = unB;
            return View(unB);
        }

    }
}
