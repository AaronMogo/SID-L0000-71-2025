using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class DetalleContratoDTO
    {
        public string PartidaContrato { get; set; }
        public string DescripcionAviso { get; set; }
        public string AreaDestinoCFE { get; set; } // opcional, solo aplica en CFE
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public decimal ImporteTotal { get; set; }
    }

    public class ContratoDTO
    {
        [JsonPropertyName("$Tipo")]
        public string Tipo { get; set; }
        public string Id { get; set; }
        public string TipoContrato { get; set; }
        public string NoContrato { get; set; }
        public string Estatus { get; set; }
        public List<DetalleContratoDTO> DetalleContrato { get; set; }

        // Campos opcionales para contratos CFE
        public string UrlArchivo { get; set; }
        public string MD5 { get; set; }
        public DateTime? FechaEntregaCFE { get; set; }

        // Solo en ContratoCFEConGarantia
        public double? PerdidasGarantizadasVacio { get; set; }
        public double? PerdidasGarantizadasCarga { get; set; }
    }

    public class ContratosResponseDTO
    {
        public int Total { get; set; }
        public int PaginaActual { get; set; }
        public int TamañoPagina { get; set; }
        public List<ContratoDTO> Contratos { get; set; }
    }


}
