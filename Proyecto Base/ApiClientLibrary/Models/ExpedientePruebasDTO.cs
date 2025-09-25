using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ExpedientePruebasDTO
    {


        public string Id { get; set; }
        public string ClaveExpediente { get; set; }
        public string OrdenFabricacion { get; set; }
        public int CantidadMuestras { get; set; }
        public int MaximoRechazos { get; set; }
        public List<string> Muestras { get; set; }

        //public string Id { get; set; }
        //public string ClaveExpediente { get; set; }
        //public List<MuestraExpedienteDTO> MuestrasExpediente { get; set; }
        //public int TamanioMuestra { get; set; }
        //public int MaximoRechazos { get; set; }
        //public string TipoMuestreo { get; set; }
        //public object ResultadosPruebas { get; set; } // Puede ser null
        //public OrdenFabricacionDTO OrdenFabricacion { get; set; }
        //public List<string> AvisosPrueba { get; set; }
        //public string EstatusPruebas { get; set; }
        //public string ResultadoExpediente { get; set; }
        //public DateTime InicioPruebas { get; set; }
        //public DateTime FinPruebas { get; set; }
        //public DateTime FechaRegistro { get; set; }
    }

    public class MuestraExpedienteDTO
    {
        public string Identificador { get; set; }
        public string Estatus { get; set; }
        public List<ResultadoPruebaDTO> ResultadosPruebas { get; set; }
    }

    //public class ResultadoPruebaDTO
    //{
    //    public PruebaDTO Prueba { get; set; }
    //    public ValorReferenciaDTO ValorReferencia { get; set; }
    //    public DateTime FechaPrueba { get; set; }
    //    public string OperadorPrueba { get; set; }
    //    public InstrumentoMedicionDTO InstrumentoMedicion { get; set; }
    //    public decimal ValorMedido { get; set; }
    //    public string Resultado { get; set; }
    //    public int NumeroIntento { get; set; }
    //}

    public class InstrumentoMedicionDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime FechaCalibracion { get; set; }
        public DateTime FechaVencimientoCalibracion { get; set; }
        public string UrlArchivo { get; set; }
        public string MD5 { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaRegistro { get; set; }
    }

}
