using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ProductoDTO
    {
        public string Id { get; set; }
        public string CodigoFabricante { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public string TipoFabricacion { get; set; }
        public string Unidad { get; set; }
        public NormaDTO Norma { get; set; }          // ahora es objeto
        public PrototipoDTO Prototipo { get; set; }  // ahora es objeto
        public string Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<PruebaDTO> Pruebas { get; set; } // ahora es lista de objetos
    }

    public class ProductoPDTO
    {
        public string Id { get; set; }
        public string CodigoFabricante { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }
        public string TipoFabricacion { get; set; }
        public string Unidad { get; set; }
        public string Norma { get; set; }         // solo Id como string
        public string Prototipo { get; set; }     // solo Id como string
        public string Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public List<string> Pruebas { get; set; } // lista de IDs
    }
 


}
