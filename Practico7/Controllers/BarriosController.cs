using Microsoft.AspNetCore.Mvc;
using Dominio;

namespace Practico7.Controllers
{
    public class BarriosController : Controller
    {
        public IActionResult Index()
        {
            List<Barrio> listaDeBarrios = Sistema.Instancia.GetBarrios();

            //VIEWDATA entrada a un diccionario "imaginario", le asigno la listaDeBarrios
            ViewData["barrios"] = listaDeBarrios;
            //VIEWBAG guarda listaDeBarrios
            ViewBag.ListadoDeBarrios = listaDeBarrios;
            //son lo mismo, viewbag es dinamic y se fija el tipo de dato de listaDeBarrios y le otorga ese tipo a ListadoDeBarrios

            //usando ViewModel
            //a la vista le paso la listaDeBarrios
            //como en la vista Index (la de ver los barrios) defini que estoy esperando objeto tipo List<Barrio>,
            //si le paso IActionResult laVista=View(new Barrio("Barrio1", 2)) (un objeto de tipo barrio) va a dejar de funcionar
            IActionResult laVista = View(listaDeBarrios);

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
