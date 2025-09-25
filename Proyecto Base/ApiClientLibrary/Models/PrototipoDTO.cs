using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class PrototipoDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string UrlArchivo { get; set; } = string.Empty;
        public string MD5 { get; set; } = string.Empty;
        public string Estatus { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
    }

}
