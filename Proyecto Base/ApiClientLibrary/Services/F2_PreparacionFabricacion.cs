using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F2_PreparacionFabricacion
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F2_PreparacionFabricacion/";
        public F2_PreparacionFabricacion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{_configuration["ApiSettings:BaseUrl"]}{_basePath}")
            };

            var token = _configuration["ApiSettings:Token"];
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }

        /// <summary>
        /// Permite cambiar manualmente el token de autorización (ej. para pruebas).
        /// </summary>
        public void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<HttpResponseMessage> RegistrarEstadoSID(EstadoSIDDTO estado)
        {
            var json = JsonSerializer.Serialize(estado);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("EstadoSID", content);
            return response;
        }

        ///////////////////////////////////  CONTRATOS  //////////////////////////////////////
        // GET
        public async Task<HttpResponseMessage> ContratosGetAsync()
        {
            return await _httpClient.GetAsync("Contratos");
        }

        // POST
        public async Task<HttpResponseMessage> ContratosPostAsync(ContratoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("Contratos", content);
        }

        // PUT
        public async Task<HttpResponseMessage> ContratosPutAsync(ContratoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync("Contratos", content);
        }

        ///////////////////////////////////  ORDEN FABRICACION  //////////////////////////////////////

        public async Task<HttpResponseMessage> OrdenFabricacionGetAsync(string idOrdenFabricacion)
        {
            return await _httpClient.GetAsync($"OrdenFabricacion/{idOrdenFabricacion}");
        }

        public async Task<HttpResponseMessage> OrdenFabricacionPostAsync(OrdenFabricacionDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("OrdenFabricacion", content);
        }

        public async Task<HttpResponseMessage> OrdenFabricacionPutAsync(string idOrdenFabricacion, OrdenFabricacionDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"OrdenFabricacion/{idOrdenFabricacion}", content);
        }

        /////////////////////////////////////////// EXPEDIENTE PRUEBAS //////////////////////////////////

        // GET con paginación
        public async Task<HttpResponseMessage> ExpedientePruebasGetAsync(int pageNumber = 1, int pageSize = 20)
        {
            return await _httpClient.GetAsync($"ExpedientePruebas?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        // GET por ID de expediente
        public async Task<HttpResponseMessage> ExpedientePruebasGetByIdAsync(string idExpediente)
        {
            return await _httpClient.GetAsync($"ExpedientePruebas/{idExpediente}");
        }

        // POST
        public async Task<HttpResponseMessage> ExpedientePruebasPostAsync(ExpedientePruebasDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("ExpedientePruebas", content);
        }

        // PUT
        public async Task<HttpResponseMessage> ExpedientePruebasPutAsync(string idExpediente, ExpedientePruebasDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync($"ExpedientePruebas/{idExpediente}", content);
        }


        /////////////////////////////////////////// AGREGAR MUESTRA EXPEDIENTE //////////////////////////////////



    }
}
