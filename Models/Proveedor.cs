using System.ComponentModel.DataAnnotations;

namespace APICrudMvc.Models
{
    public class Proveedor
    {
        [Key]
        public int idProveedor { get; set; }
        [StringLength(50)]
        public string nombre { get; set; } = "";
        [StringLength(50)]
        public string direccion { get; set; } = "";
        [StringLength(100)]
        public string telefono { get; set; } = "";
        [StringLength(20)]
        public string tipoProducto { get; set; } = "";
    }
}


