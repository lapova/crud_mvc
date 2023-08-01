using APICrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.Extensions.Hosting;

namespace APICrudMvc.Controllers
{
    public class ClienteController : Controller
    {
        // Para acceder a la API
        private readonly APIGateway apiGateway;

        public ClienteController(APIGateway ApiGateway)
        {
            // Se utiliza el objeto apiGateway para acceder a la API
            this.apiGateway = ApiGateway;
        }

        // Método para mostrar la lista de clientes
        public IActionResult Index()
        {
            List<Cliente> cliente;
            cliente = apiGateway.ListCliente(); // Toma lista de clientes usando la API
            return View(cliente); // Envia a vista Index con la lista de clientes
        }

        //Método para mostrar pagina para crear cliente(get)
        [HttpGet]
        public IActionResult Create()
        {
            Cliente cliente = new Cliente(); // Crea un objeto cliente vacío
            return View(cliente); // Regresa la vista create con el objeto cliente vacío
        }

        //Método para crear un cliente(post)
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            try
            {
                bool success = apiGateway.CreateCliente(cliente);
                if (success)
                {
                    // insertar ok, se asigna el mensaje y la alerta verde
                    ViewBag.Mensaje = "Proceso correcto";
                    ViewBag.MensajeTipo = "alert alert-success"; // Clase Bootstrap para alerta verde
                }
                else
                {
                    // Si hay un error al insertar, se asigna el mensaje y la alerta roja
                    ViewBag.Mensaje = "Error en el proceso";
                    ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, se asigna el mensaje de error y el tipo de alerta roja
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert alert-danger"; // Clase Bootstrap para alerta roja
            }

            return View(cliente);
        }

        // Método para mostrar pagina para editar cliente (get)
        [HttpGet]
        public IActionResult Edit(int idCliente)
        {
            Cliente cliente = apiGateway.GetCliente(idCliente);
            return View(cliente);
        }

        // Método para editar un cliente (post)
        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            try
            {
                // Actualizar el cliente usando la API
                apiGateway.UpdateCliente(cliente);

                // Si la actualización fue ok, mostrar mensaje de "Proceso correcto" - color verde
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase de Bootstrap para mensaje verde
            }
            catch (Exception ex)
            {
                // Si hay error durante la actualización, mostrar mensaje de "Error en el proceso" - color rojo
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase de Bootstrap para mensaje rojo
            }
            return View(cliente);
        }

        // Método para mostrar la pagina para eliminar cliente (get)
        [HttpGet]
        public IActionResult Delete(int idCliente)
        {
            Cliente cliente = apiGateway.GetCliente(idCliente); // Toma el cliente a eliminar usando la API
            return View(cliente); // Regresa la vista Delete con el cliente a eliminar
        }

        // Método para eliminar un cliente (post)
        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            try
            {
                // Eliminar el cliente usando la API
                apiGateway.DeleteCliente(cliente);

                // Si la eliminación fue ok, mostrar mensaje de "Proceso correcto" - color verde
                ViewBag.Mensaje = "Proceso correcto";
                ViewBag.MensajeTipo = "alert-success"; // Clase de Bootstrap para mensaje verde
            }
            catch (Exception ex)
            {
                // Si hay error al eliminar, mostrar mensaje de "Error en el proceso" - color rojo
                ViewBag.Mensaje = "Error en el proceso: " + ex.Message;
                ViewBag.MensajeTipo = "alert-danger"; // Clase de Bootstrap para mensaje rojo
            }
            return View(cliente);
        }

    }
}
