using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class OrdenFabricacionDTO
    {
        public string Id { get; set; }
        public string ClaveOrdenFabricacion { get; set; }
        public string LoteFabricacion { get; set; }
        public string IdProducto { get; set; }
        public List<DetalleFabricacionDTO> DetalleFabricacion { get; set; }
    }

    public class DetalleFabricacionDTO
    {
        public string ContratoId { get; set; }
        public string TipoContrato { get; set; }
        public string PartidaContratoId { get; set; }
        public string DescripcionPartida { get; set; }
        public string Unidad { get; set; }
        public int CantidadOriginalContrato { get; set; }
        public int CantidadAFabricar { get; set; }
    }
}
