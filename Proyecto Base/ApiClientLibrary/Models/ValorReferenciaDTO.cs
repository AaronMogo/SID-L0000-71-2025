using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ValorReferenciaDTO
    {
        public string Id { get; set; } = string.Empty;
        public string IdProducto { get; set; } = string.Empty;
        public string IdPrueba { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Valor2 { get; set; }
        public string Unidad { get; set; } = string.Empty;
        public string Comparacion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }
}
