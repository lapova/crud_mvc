using APICrudMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudMvc.Controllers
{
    public class SeccionController : Controller
    {
        private readonly APIGateway apiGateway;

        public SeccionController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }

        public IActionResult Index()
        {
            List<Seccion> seccion;
            seccion = apiGateway.ListSeccion();
            return View(seccion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Seccion seccion = new Seccion();
            return View(seccion);
        }

        [HttpPost]
        public IActionResult Create(Seccion seccion)
        {
            try
            {
                bool success = apiGateway.CreateSeccion(seccion);
                if (success)
                {
                    ViewBag.Mensaje = "Proceso correcto";
                    ViewBag.MensajeTipo = "alert alert-success"; // Clase Bootstrap para alerta verde
                }
                else
                {
                    ViewBag.Mensaje = "Error en el proceso";
                    ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert alert-danger"; 
            }

            return View(seccion);
        }

        [HttpGet]
        public IActionResult Edit(int idSeccion)
        {
            Seccion seccion = apiGateway.GetSeccion(idSeccion);
            return View(seccion);
        }

        [HttpPost]
        public IActionResult Edit(Seccion seccion)
        {
            try
            {
                apiGateway.UpdateSeccion(seccion);
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase Bootstrap para alerta verde
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(seccion);
        }

        [HttpGet]
        public IActionResult Delete(int idSeccion)
        {
            Seccion seccion = apiGateway.GetSeccion(idSeccion); 
            return View(seccion); 
        }

        [HttpPost]
        public IActionResult Delete(Seccion seccion)
        {
            try
            {
                apiGateway.DeleteSeccion(seccion);
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase Bootstrap para alerta verde
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(seccion);
        }

    }
}
