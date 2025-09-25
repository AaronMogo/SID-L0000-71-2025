using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientLibrary.Models
{
    public class ResultadoPruebaDTO
    {
        public string IdPrueba { get; set; }
        public string IdValorReferencia { get; set; }
        public DateTime FechaPrueba { get; set; }
        public string OperadorPrueba { get; set; }
        public string IdInstrumentoMedicion { get; set; }
        public decimal ValorMedido { get; set; }
        public string Resultado { get; set; }
        public int NumeroIntento { get; set; }
    }



}
