using APICrudMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudMvc.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly APIGateway apiGateway;

        public ProveedorController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }
        public IActionResult Index()
        {
            List<Proveedor> proveedor;
            proveedor = apiGateway.ListProveedor();
            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Proveedor proveedor = new Proveedor();
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Create(Proveedor proveedor)
        {
            try
            {
                bool success = apiGateway.CreateProveedor(proveedor);
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

            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Edit(int idProveedor)
        {
            Proveedor proveedor = apiGateway.GetProveedor(idProveedor);
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Edit(Proveedor proveedor)
        {
            try
            {
                apiGateway.UpdateProveedor(proveedor);
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase Bootstrap para alerta verde
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Delete(int idProveedor)
        {
            Proveedor proveedor = apiGateway.GetProveedor(idProveedor);
            return View(proveedor);
        }

        [HttpPost]
        public IActionResult Delete(Proveedor proveedor)
        {
            try
            {
                apiGateway.DeleteProveedor(proveedor);
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase Bootstrap para alerta verde
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(proveedor);
        }

    }
}
