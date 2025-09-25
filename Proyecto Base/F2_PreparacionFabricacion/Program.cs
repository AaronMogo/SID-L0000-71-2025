using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System.Text.Json;

F2_PreparacionFabricacion servicio = new F2_PreparacionFabricacion();

while (true)
{
    Console.WriteLine("\n F2 - MENÚ");

    Console.WriteLine("1. Get Contratos");
    Console.WriteLine("2. Post Contratos");
    Console.WriteLine("3. Put Contratos");
    Console.WriteLine("------------------");
    Console.WriteLine("4. Get OrdenFabricacion");
    Console.WriteLine("5. Post OrdenFabricacion (Necesitas: IdProducto, ContratoId, TipoContrato)");
    Console.WriteLine("6. Put OrdenFabricacion");
    Console.WriteLine("------------------"); 
    Console.WriteLine("7. Get Paginacion ExpedientePruebas");
    Console.WriteLine("8. Get ExpedientePruebas  (clave expediente)");
    Console.WriteLine("9. Post ExpedientePruebas");
    Console.WriteLine("10. Put ExpedientePruebas");
    Console.WriteLine("------------------");

    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");
    var opcion = Console.ReadLine();

    if (opcion == "0") break;

    if (opcion == "1") // GET CONTRATOS
    {
        var respuesta = await servicio.ContratosGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var contratosResponse = JsonSerializer.Deserialize<ContratosResponseDTO>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("|||||||||||||||||||||||||||||");
            Console.WriteLine("\n--- CONTRATOS REGISTRADOS ---");
            foreach (var c in contratosResponse.Contratos)
            {
                Console.WriteLine($"ID: {c.Id}");
                Console.WriteLine($"Tipo: {c.Tipo}");
                Console.WriteLine($"NoContrato: {c.NoContrato}");
                Console.WriteLine($"Estatus: {c.Estatus}");
                if (c.DetalleContrato != null)
                {
                    foreach (var d in c.DetalleContrato)
                    {
                        Console.WriteLine($"  Partida: {d.PartidaContrato}, Descripción: {d.DescripcionAviso}, Cant: {d.Cantidad}, Unidad: {d.Unidad}, Importe: {d.ImporteTotal}");
                    }
                }
                Console.WriteLine("|||||||||||||||||||||||||||||");
            }
        }
        else
        {
            Console.WriteLine("Error GET: " + await respuesta.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "2") // POST CONTRATO
    {
        //var contrato = new ContratoDTO
        //{
        //    Tipo = "ContratoCFE",
        //    Id = "",
        //    TipoContrato = "ContratoCFE",
        //    NoContrato = "CFE 9300048923",
        //    Estatus = "ACTIVO",
        //    DetalleContrato = new List<DetalleContratoDTO>
        //    {
        //        new DetalleContratoDTO
        //        {
        //            PartidaContrato = "415",
        //            DescripcionAviso = "TRANSFORMADOR POSTE 10KVA 13200V/240V",
        //            AreaDestinoCFE = "CFE",
        //            Cantidad = 2,
        //            Unidad = "pz",
        //            ImporteTotal = 450000.00M

        //        }
        //    },
        //    UrlArchivo = "https://www.cfe.mx",
        //    MD5 = "",
        //    FechaEntregaCFE = DateTime.UtcNow 
        //};

        //var contrato = new ContratoDTO
        //{
        //    Tipo = "ContratoCFE",
        //    Id = "",
        //    TipoContrato = "ContratoCFE",
        //    NoContrato = "CFE 9300048923",
        //    Estatus = "ACTIVO",
        //    DetalleContrato = new List<DetalleContratoDTO>
        //    {
        //        new DetalleContratoDTO
        //             {
        //            PartidaContrato = "523",
        //            DescripcionAviso = "TRANSFORMADOR POSTE 10KVA 13200V/240V",
        //            AreaDestinoCFE = "CFE",
        //            Cantidad = 2,
        //            Unidad = "pz",
        //            ImporteTotal = 750000.00M
        //            }
        //    },
        //    UrlArchivo = "https://www.cfe.mx",
        //    MD5 = "",
        //    FechaEntregaCFE = DateTime.UtcNow
        //};

        var contrato = new ContratoDTO
        {
                Tipo = "ContratoParticular",
                Id = "",
                TipoContrato = "ContratoParticular",
                NoContrato = "002",
                Estatus = "ACTIVO",
                DetalleContrato = new List<DetalleContratoDTO>
            {
                new DetalleContratoDTO
                {
                    PartidaContrato = "1",
                    DescripcionAviso = "TRANSFORMADOR POSTE 10KVA 13200V/240V",
                    Cantidad = 1,
                    Unidad = "pz",
                    ImporteTotal = 1
                }
             }
        };




        var llamada = await servicio.ContratosPostAsync(contrato);

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Contrato registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Error POST: " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "3") // PUT CONTRATO
    {
        Console.Write("Ingresa el ID del contrato a actualizar: ");
        var id = Console.ReadLine();

        var contrato = new ContratoDTO
        {
            Tipo = "ContratoParticular",
            Id = id,
            TipoContrato = "ContratoParticular",
            NoContrato = "PART0001",
            Estatus = "ACTIVO",
            DetalleContrato = new List<DetalleContratoDTO>
        {
            new DetalleContratoDTO
            {
                PartidaContrato = "1",
                DescripcionAviso = "Transformador",
                Cantidad = 5,
                Unidad = "pz",
                ImporteTotal = 5
            }
        }
        };

        var respuesta = await servicio.ContratosPutAsync(contrato);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Contrato actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Error PUT: " + await respuesta.Content.ReadAsStringAsync());
        }
    }

    /////////////////////////////////// ORDEN DE FABRICACION /////////////////////////////////////////////////
    else if (opcion == "4") // GET ORDEN FABRICACION
    {
        Console.Write("Ingresa el ID de la orden de fabricación: ");
        var id = Console.ReadLine();

        var respuesta = await servicio.OrdenFabricacionGetAsync(id);

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine("\n--- JSON RECIBIDO ---");
            Console.WriteLine(contenido);

            try
            {
                // Deserializa como lista
                var ordenes = JsonSerializer.Deserialize<List<OrdenFabricacionDTO>>(contenido,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (ordenes != null && ordenes.Count > 0)
                {
                    var orden = ordenes[0]; // Tomamos la primera

                    Console.WriteLine("\n--- ORDEN DE FABRICACION ---");
                    Console.WriteLine($"ID: {orden.Id}");
                    Console.WriteLine($"Clave OF: {orden.ClaveOrdenFabricacion}");
                    Console.WriteLine($"Lote: {orden.LoteFabricacion}");
                    Console.WriteLine($"ProductoId: {orden.IdProducto}");

                    if (orden.DetalleFabricacion != null)
                    {
                        foreach (var d in orden.DetalleFabricacion)
                        {
                            Console.WriteLine($"  ContratoId: {d.ContratoId}, Tipo: {d.TipoContrato}, " +
                                              $"Partida: {d.PartidaContratoId}, Desc: {d.DescripcionPartida}, " +
                                              $"CantOrig: {d.CantidadOriginalContrato}, " +
                                              $"CantFab: {d.CantidadAFabricar}, Unidad: {d.Unidad}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" No se encontraron órdenes de fabricación.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine("\n Error al deserializar:");
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Error GET: " + await respuesta.Content.ReadAsStringAsync());
        }
    }


    else if (opcion == "5") // POST ORDEN FABRICACION
    {
        var orden = new OrdenFabricacionDTO
        {
            Id = "",
            ClaveOrdenFabricacion = "OF-2025-CFE-9560",
            LoteFabricacion = "TRF00789234",
            IdProducto = "68d56ac5997c4a1351387b11",
            DetalleFabricacion = new List<DetalleFabricacionDTO>
            {
                new DetalleFabricacionDTO
                {
                    ContratoId = "68d57421997c4a1351387b99",
                    TipoContrato = "ContratoCFE",
                    PartidaContratoId = "415",
                    DescripcionPartida = "TRANSFORMADOR POSTE 10KVA 13200V/240V", //contra descripcion de contrato tiene que coincidir
                    Unidad = "pz",
                    CantidadOriginalContrato = 2,
                    CantidadAFabricar = 2
                },
                new DetalleFabricacionDTO
                {
                    ContratoId = "68d574c6997c4a1351387ba2",
                    TipoContrato = "ContratoCFE",
                    PartidaContratoId = "523",
                    DescripcionPartida = "TRANSFORMADOR POSTE 10KVA 13200V/240V",
                    Unidad = "pz",
                    CantidadOriginalContrato = 2,
                    CantidadAFabricar = 2
                },
                new DetalleFabricacionDTO
                {
                    ContratoId = "68d57546997c4a1351387ba3",
                    TipoContrato = "ContratoParticular",
                    PartidaContratoId = "1",
                    DescripcionPartida = "TRANSFORMADOR POSTE 10KVA 13200V/240V",
                    Unidad = "pz",
                    CantidadOriginalContrato = 1,
                    CantidadAFabricar = 1
                }
            }
        };

        var llamada = await servicio.OrdenFabricacionPostAsync(orden);
        var contenidoRespuesta = await llamada.Content.ReadAsStringAsync();

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Orden de fabricación registrada correctamente.");
            Console.WriteLine("\n--- Response Body ---");
            Console.WriteLine(contenidoRespuesta);

        }
        else
        {
            Console.WriteLine("Error POST: " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "6") // PUT ORDEN FABRICACION
    {
        Console.Write("Ingresa el ID de la orden de fabricación a actualizar: ");
        var id = Console.ReadLine();

        var orden = new OrdenFabricacionDTO
        {
            Id = id,
            ClaveOrdenFabricacion = "OF20266",
            LoteFabricacion = "LOTE2026",
            IdProducto = "68d2f021ce3b00aacea97213",
            DetalleFabricacion = new List<DetalleFabricacionDTO>
            {
                new DetalleFabricacionDTO
                {
                    ContratoId = "68d30295ce3b00aacea97250",
                    TipoContrato = "ContratoCFEConGarantia",
                    PartidaContratoId = "1",
                    DescripcionPartida = "Transformador",
                    Unidad = "pz",
                    CantidadOriginalContrato = 5,
                    CantidadAFabricar = 5
                }
            }
        };

        var respuesta = await servicio.OrdenFabricacionPutAsync(id, orden);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Orden de fabricación actualizada correctamente.");
        }
        else
        {
            Console.WriteLine("Error PUT: " + await respuesta.Content.ReadAsStringAsync());
        }
    }
    /////////////////////////////////////// EXPEDIENTE PRUEBAS ////////////////////////////////////////////////////

    else if (opcion == "7") // GET TODOS LOS EXPEDIENTES
    {
        var respuesta = await servicio.ExpedientePruebasGetAsync(pageNumber: 1, pageSize: 20);
        var contenido = await respuesta.Content.ReadAsStringAsync();
        Console.WriteLine(contenido); // Muestra todo el JSON
    }

    else if (opcion == "8") // GET EXPEDIENTE POR ID
    {
        Console.Write("Ingresa el ID del expediente: ");
        var id = Console.ReadLine();
        var respuesta = await servicio.ExpedientePruebasGetByIdAsync(id);
        var contenido = await respuesta.Content.ReadAsStringAsync();
        Console.WriteLine(contenido); // Muestra todo el JSON
    }

    else if (opcion == "9") // POST EXPEDIENTE
    {

        var expediente = new ExpedientePruebasDTO
        {
            Id = "",
            ClaveExpediente = "FGW-2025-00378",
            OrdenFabricacion = "68d57973997c4a1351387bb6",
            CantidadMuestras = 5,
            MaximoRechazos = 0,
            Muestras = new List<string>
        {
            "TRF-00378-01",
            "TRF-00378-02",
            "TRF-00378-03",
            "TRF-00378-04",
            "TRF-00378-05"
        }
        };
        //var expediente = new ExpedientePruebasDTO
        //{
        //    Id = "",
        //    ClaveExpediente = "FGW-2025-00378",
        //    TamanioMuestra = 5,
        //    MaximoRechazos = 0,
        //    TipoMuestreo = "100%",
        //    AvisosPrueba = new List<string> { "11" },
        //    EstatusPruebas = "CERRADO",
        //    ResultadoExpediente = "SATISFACTORIO",
        //    InicioPruebas = DateTime.UtcNow,
        //    FinPruebas = DateTime.UtcNow,
        //    FechaRegistro = DateTime.UtcNow
        //};

        var llamada = await servicio.ExpedientePruebasPostAsync(expediente);
        var contenidoRespuesta = await llamada.Content.ReadAsStringAsync();
        Console.WriteLine(contenidoRespuesta);
    }

    else if (opcion == "10") // PUT EXPEDIENTE
    {
        Console.Write("Ingresa el ID del expediente a actualizar: ");
        var id = Console.ReadLine();

        var expediente = new ExpedientePruebasDTO
        {
            Id = "",
            ClaveExpediente = "FGW-2025-00378",
            OrdenFabricacion = "68d57973997c4a1351387bb6",
            CantidadMuestras = 5,
            MaximoRechazos = 0,
            Muestras = new List<string>
        {
            "TRF-00378-01",
            "TRF-00378-02",
            "TRF-00378-03",
            "TRF-00378-04",
            "TRF-00378-05"
        }
        };

        //var expediente = new ExpedientePruebasDTO
        //{
        //    Id = id,
        //    ClaveExpediente = "EXP-2025_MOD",
        //    TamanioMuestra = 3,
        //    MaximoRechazos = 3,
        //    TipoMuestreo = "100%",
        //    AvisosPrueba = new List<string> { "11" },
        //    EstatusPruebas = "CERRADO",
        //    ResultadoExpediente = "SATISFACTORIO",
        //    InicioPruebas = DateTime.UtcNow,
        //    FinPruebas = DateTime.UtcNow,
        //    FechaRegistro = DateTime.UtcNow
        //};

        var respuesta = await servicio.ExpedientePruebasPutAsync(id, expediente);
        var contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
        Console.WriteLine(contenidoRespuesta);
    }






}


