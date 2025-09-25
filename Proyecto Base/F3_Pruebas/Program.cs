using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System.Net.Http;
using System.Text;
using System.Text.Json;


F3_Pruebas servicio = new F3_Pruebas();

while (true)
{
    Console.WriteLine("\n F3 - MENÚ");

    Console.WriteLine("1. PUT AgregaResultadoPrueba");
    Console.WriteLine("------------------");


    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");
    var opcion = Console.ReadLine();

    if (opcion == "0") break;

    if (opcion == "1") // PUT 
    {
        //var expediente = "FGW-2025-00378";
        //var muestra = "TRF-00378-01";

        //var resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 1500,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //}
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 70,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568c2997c4a1351387aff",
        //    IdValorReferencia = "68d56d93997c4a1351387b23",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d56700997c4a1351387ae8",
        //    ValorMedido = 35,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};

        ///////////////////////////////// 02 //////////////////////////////////////

        //var expediente = "FGW-2025-00378";
        //var muestra = "TRF-00378-02";

        //var resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 1200,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 68,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568c2997c4a1351387aff",
        //    IdValorReferencia = "68d56d93997c4a1351387b23",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d56700997c4a1351387ae8",
        //    ValorMedido = 0,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};

        ///////////////////////////////// 03 //////////////////////////////////////
        //var expediente = "FGW-2025-00378";
        //var muestra = "TRF-00378-03";

        //var resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 1800,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 62,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568c2997c4a1351387aff",
        //    IdValorReferencia = "68d56d93997c4a1351387b23",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d56700997c4a1351387ae8",
        //    ValorMedido = 0,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};


        /////////////////////////////////// 04 //////////////////////////////////////
        //var expediente = "FGW-2025-00378";
        //var muestra = "TRF-00378-04";

        //var resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 950,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};

        //var  resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 1100,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 2
        //};

        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 71,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 69,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 2
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568c2997c4a1351387aff",
        //    IdValorReferencia = "68d56d93997c4a1351387b23",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d56700997c4a1351387ae8",
        //    ValorMedido = 0,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        ///////////////////////////////// 05 //////////////////////////////////////
        var expediente = "FGW-2025-00378";
        var muestra = "TRF-00378-05";

        //var resultado = new ResultadoPruebaDTO //resistencia de aislamiento, valor minimo 1000m a 10kv
        //{
        //    IdPrueba = "68d56892997c4a1351387afc",
        //    IdValorReferencia = "68d56d4c997c4a1351387b21",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566cb997c4a1351387ae3",
        //    ValorMedido = 1300,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        //var resultado = new ResultadoPruebaDTO
        //{
        //    IdPrueba = "68d568af997c4a1351387afd",
        //    IdValorReferencia = "68d56d7b997c4a1351387b22",
        //    FechaPrueba = DateTime.UtcNow,
        //    OperadorPrueba = "AARON MORENO",
        //    IdInstrumentoMedicion = "68d566e8997c4a1351387ae5",
        //    ValorMedido = 66,
        //    Resultado = "SATISFACTORIO",
        //    NumeroIntento = 1
        //};
        var resultado = new ResultadoPruebaDTO
        {
            IdPrueba = "68d568c2997c4a1351387aff",
            IdValorReferencia = "68d56d93997c4a1351387b23",
            FechaPrueba = DateTime.UtcNow,
            OperadorPrueba = "AARON MORENO",
            IdInstrumentoMedicion = "68d56700997c4a1351387ae8",
            ValorMedido = 0,
            Resultado = "SATISFACTORIO",
            NumeroIntento = 1
        };


        var response = await servicio.AgregaResultadoPruebaAsync(resultado, expediente, muestra);

        if (response.IsSuccessStatusCode)
            Console.WriteLine("Resultado registrado correctamente.");
        else
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode} - {errorContent}");
        }
    }






}


