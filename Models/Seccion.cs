using System.ComponentModel.DataAnnotations;

namespace APICrudMvc.Models
{
    public class Seccion
    {
        [Key]
        public int idSeccion { get; set; }
        [StringLength(50)]
        public string nombre { get; set; } = "";
        [StringLength(50)]
        public string descripcion { get; set; } = "";
    }
}


