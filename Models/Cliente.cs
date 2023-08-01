using System.ComponentModel.DataAnnotations;

namespace APICrudMvc.Models
{
    public class Cliente //Clase cliente
    {
        [Key]
        // Propiedad que indica el ID del cliente (pk)
        public int idCliente { get; set; }
        [StringLength(50)]
        // Propiedad que indica el nombre del cliente 
        public string nombre { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el apellido del cliente 
        public string apellido { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el correo del cliente 
        public string correo { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el tipo de cliente 
        public string tipoCliente { get; set; } = "";
    }
}


