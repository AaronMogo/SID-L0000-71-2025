using ApiClientLibrary.Services;

F1_ConfiguracionInicial servicio = new F1_ConfiguracionInicial();
var estado = new ApiClientLibrary.Models.EstadoSIDDTO
{
    Estado = "EN_ESPERA"

};

//servicio.RegistrarEstadoSID(estado).Wait();

var llamada = servicio.RegistrarEstadoSID(estado).Result;

if (llamada.IsSuccessStatusCode)
{
    Console.WriteLine("= OK REGISTRO ESTADO SID =");

}
else { 

}
// UN REPOSITORIO POR TODAS LAS PRACTICAS