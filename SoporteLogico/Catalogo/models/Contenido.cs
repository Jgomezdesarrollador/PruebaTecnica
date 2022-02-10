using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogo.models
{
    public class Contenido
    {
        public int Id { get; set; }
        [Required]
        public string codigo_producto { get; set; }
        [Required]
        public string clase_producto { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string autor { get; set; }
        
    }
}
