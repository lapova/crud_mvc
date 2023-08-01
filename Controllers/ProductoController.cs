using APICrudMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudMvc.Controllers
{
    public class ProductoController : Controller
    {
        private readonly APIGateway apiGateway;

        public ProductoController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }
        public IActionResult Index()
        {
            List<Producto> producto;
            producto = apiGateway.ListProducto();
            return View(producto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Producto producto = new Producto();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            try
            {
                bool success = apiGateway.CreateProducto(producto);
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
                ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Edit(int idProducto)
        {
            Producto producto = apiGateway.GetProducto(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            try
            {
                bool success = apiGateway.UpdateProducto(producto);
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
                ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(producto);
        }

        [HttpGet]
        public IActionResult Delete(int idProducto)
        {
            Producto producto = apiGateway.GetProducto(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Delete(Producto producto)
        {
            try
            {
                bool success = apiGateway.DeleteProducto(producto);
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
                ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(producto);
        }

    }
}
