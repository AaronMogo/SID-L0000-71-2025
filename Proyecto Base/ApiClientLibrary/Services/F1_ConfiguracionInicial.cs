using ApiClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ApiClientLibrary.Services
{
    public class F1_ConfiguracionInicial
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _basePath = "F1_ConfiguracionInicial/";
        public F1_ConfiguracionInicial()
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

        public async Task<HttpResponseMessage> InstrumentoGetAsync()
        {
            return await _httpClient.GetAsync("Instrumento");
        }

        public async Task<HttpResponseMessage> Instrumento(InstrumentoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Instrumento", content);
            return response;
        }

        public async Task<HttpResponseMessage> InstrumentoPutAsync(InstrumentoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Instrumento", content);
            return response;
        }

        ///////////////////////// PROTOTIPO ////////////////////////////////
        public async Task<HttpResponseMessage> PrototipoGetAsync()
        {
            return await _httpClient.GetAsync("Prototipo");
        }

        public async Task<HttpResponseMessage> PrototipoPostAsync(PrototipoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Prototipo", content);
            return response;
        }

        public async Task<HttpResponseMessage> PrototipoPutAsync(PrototipoDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Prototipo", content);
            return response;
        }

        ///////////////////////// Valor Referencia ////////////////////////////////
        public async Task<HttpResponseMessage> ValorReferenciaGetAsync()
        {
            return await _httpClient.GetAsync("ValorReferencia");
        }

        public async Task<HttpResponseMessage> ValorReferenciaPostAsync(ValorReferenciaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("ValorReferencia", content);
            return response;
        }

        public async Task<HttpResponseMessage> ValorReferenciaPutAsync(ValorReferenciaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("ValorReferencia", content);
            return response;
        }

        ///////////////////////// Producto ////////////////////////////////

        public async Task<HttpResponseMessage> ProductoGetAsync()
        {
            return await _httpClient.GetAsync("Producto");
        }

        public async Task<HttpResponseMessage> ProductoPostAsync(ProductoPDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("Producto", content);
        }

        public async Task<HttpResponseMessage> ProductoPutAsync(ProductoPDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Producto", content);
            return response;
        }


        ///////////////////////////////////  NORMA  //////////////////////////////////////
        public async Task<HttpResponseMessage> NormaGetAsync()
        {
            return await _httpClient.GetAsync("Norma");
        }

        public async Task<HttpResponseMessage> NormaPostAsync(NormaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("Norma", content);
        }

        public async Task<HttpResponseMessage> NormaPutAsync(NormaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync("Norma", content);
        }

        ///////////////////////////////////  PRUEBAS  //////////////////////////////////////
        public async Task<HttpResponseMessage> PruebaGetAsync()
        {
            return await _httpClient.GetAsync("Prueba");
        }

        public async Task<HttpResponseMessage> PruebaPostAsync(PruebaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("Prueba", content);
        }

        public async Task<HttpResponseMessage> PruebaPutAsync(PruebaDTO data)
        {
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PutAsync("Prueba", content);
        }


    }
}
