using System.ComponentModel.DataAnnotations;

namespace APICrudMvc.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [StringLength(50)]
        public string nombre { get; set; } = "";
        public float precio { get; set; } 
    }
}



