using APICrudMvc.Models;
using Newtonsoft.Json;
using System.Net;


namespace APICrudMvc
{
    public class APIGateway
    {
        private readonly string urlCliente = "https://localhost:7074/api/Cliente";
        private readonly string urlProducto = "https://localhost:7074/api/Producto";
        private readonly string urlProveedor = "https://localhost:7074/api/Proveedor";
        private readonly string urlSeccion = "https://localhost:7074/api/Seccion";
        private HttpClient httpClient;

        public APIGateway()
        {
            httpClient = new HttpClient();
            if (urlCliente.Trim().Substring(0, 5).ToLower() == "https")
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        //Métodos CRUD para cliente:
        public List<Cliente> ListCliente() //Listar
        {
            List<Cliente> cliente = new List<Cliente>();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlCliente).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<List<Cliente>>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
            return cliente;
        }

        public Cliente GetCliente(int idCliente)
        {
            Cliente cliente = new Cliente();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{urlCliente}/{idCliente}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    cliente = JsonConvert.DeserializeObject<Cliente>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
            return cliente;
        }

        public bool CreateCliente(Cliente cliente) //Crear
        {
            try
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync(urlCliente, cliente).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
        }

        public bool UpdateCliente(Cliente cliente) //Actualizar
        {
            try
            {
                HttpResponseMessage response = httpClient.PutAsJsonAsync($"{urlCliente}/{cliente.idCliente}", cliente).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
        }

        public bool DeleteCliente(Cliente cliente) //Eliminar
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync($"{urlCliente}/{cliente.idCliente}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

        //Métodos CRUD para producto:
        public List<Producto> ListProducto() //Listar
        {
            List<Producto> producto = new List<Producto>();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlProducto).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    producto = JsonConvert.DeserializeObject<List<Producto>>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
            return producto;
        }

        public Producto GetProducto(int idProducto)
        {
            Producto producto = new Producto();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{urlProducto}/{idProducto}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    producto = JsonConvert.DeserializeObject<Producto>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
            return producto;
        }

        public bool CreateProducto(Producto producto) //Crear
        {
            try
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync(urlProducto, producto).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

        public bool UpdateProducto(Producto producto) //Actualizar
        {
            try
            {
                HttpResponseMessage response = httpClient.PutAsJsonAsync($"{urlProducto}/{producto.idProducto}", producto).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
        }

        public bool DeleteProducto(Producto producto) //Eliminar
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync($"{urlProducto}/{producto.idProducto}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

        //Métodos CRUD para proveedor:
        public List<Proveedor> ListProveedor() //Listar
        {
            List<Proveedor> proveedor = new List<Proveedor>();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlProveedor).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    proveedor = JsonConvert.DeserializeObject<List<Proveedor>>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
            return proveedor;
        }

        public Proveedor GetProveedor(int idProveedor)
        {
            Proveedor proveedor = new Proveedor();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{urlProveedor}/{idProveedor}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    proveedor = JsonConvert.DeserializeObject<Proveedor>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
            return proveedor;
        }

        public bool CreateProveedor(Proveedor proveedor) //Crear
        {
            try
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync(urlProveedor, proveedor).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }
        public bool UpdateProveedor(Proveedor proveedor) //Actualizar
        {
            try
            {
                HttpResponseMessage response = httpClient.PutAsJsonAsync($"{urlProveedor}/{proveedor.idProveedor}", proveedor).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
        }
        public bool DeleteProveedor(Proveedor proveedor) //Eliminar
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync($"{urlProveedor}/{proveedor.idProveedor}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

        //Métodos CRUD para seccion:
        public List<Seccion> ListSeccion() //Listar
        {
            List<Seccion> seccion = new List<Seccion>();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(urlSeccion).Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    seccion = JsonConvert.DeserializeObject<List<Seccion>>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
            return seccion;
        }

        public Seccion GetSeccion(int idSeccion)
        {
            Seccion seccion = new Seccion();
            try
            {
                HttpResponseMessage response = httpClient.GetAsync($"{urlSeccion}/{idSeccion}").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    seccion = JsonConvert.DeserializeObject<Seccion>(result);
                }
                else
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
            return seccion;
        }

        public bool CreateSeccion(Seccion seccion) //Crear
        {
            try
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync(urlSeccion, seccion).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

        public bool UpdateSeccion(Seccion seccion) //Actualizar
        {
            try
            {
                HttpResponseMessage response = httpClient.PutAsJsonAsync($"{urlSeccion}/{seccion.idSeccion}", seccion).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message);
            }
        }
        public bool DeleteSeccion(Seccion seccion) //Eliminar
        {
            try
            {
                HttpResponseMessage response = httpClient.DeleteAsync($"{urlSeccion}/{seccion.idSeccion}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Error en la API, info del error " + response.Content.ReadAsStringAsync().Result);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la API, info del error " + ex.Message, ex);
            }
        }

    }
}


