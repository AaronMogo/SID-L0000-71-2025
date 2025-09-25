using ApiClientLibrary.Models;
using ApiClientLibrary.Services;
using System.Text.Json;

F1_ConfiguracionInicial servicio = new F1_ConfiguracionInicial();

while (true)
{
    Console.WriteLine("\n F1 - MENÚ");
    Console.WriteLine("1. Get Instrumento");
    Console.WriteLine("2. Post Instrumento");
    Console.WriteLine("3. Put Instrumento");
    Console.WriteLine("------------------");
    Console.WriteLine("4. Get Prototipo");
    Console.WriteLine("5. Post Prototipo (Congruencia en fechas)");
    Console.WriteLine("6. Put Prototipo");
    Console.WriteLine("------------------");


    Console.WriteLine("7. Get Norma");
    Console.WriteLine("7. Get Norma CFE");
    Console.WriteLine("8. Post Norma");
    Console.WriteLine("9. Put Norma");
    Console.WriteLine("------------------");

    Console.WriteLine("10. Get Producto");
    Console.WriteLine("11. Post Producto");
    Console.WriteLine("12. Put Producto");
    Console.WriteLine("------------------");

    Console.WriteLine("13. Get Prueba");
    Console.WriteLine("14. Post Prueba");
    Console.WriteLine("15. Put Prueba");
    Console.WriteLine("------------------");

    Console.WriteLine("16. Get ValorReferencia");
    Console.WriteLine("17. Post ValorReferencia (se necesita IdProducto, IdPrueba)");
    Console.WriteLine("18. Put ValorReferencia");
    Console.WriteLine("------------------");

    Console.WriteLine("19. Get Contratos");
    Console.WriteLine("20. Post Contratos)");
    Console.WriteLine("21. Put Contratos");
    Console.WriteLine("------------------");





    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");
    var opcion = Console.ReadLine();

    if (opcion == "0") break;

    if (opcion == "1")
    {

        var respuesta = await servicio.InstrumentoGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            // Mostrar de forma legible
            var instrumentos = JsonSerializer.Deserialize<List<InstrumentoDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("\n--- INSTRUMENTOS REGISTRADOS ---");
            foreach (var inst in instrumentos)
            {
                Console.WriteLine($"ID: {inst.Id}");
                Console.WriteLine($"Nombre: {inst.Nombre}");
                Console.WriteLine($"Número de Serie: {inst.NumeroSerie}");
                Console.WriteLine($"Fecha Calibración: {inst.FechaCalibracion}");
                Console.WriteLine($"Fecha Vencimiento: {inst.FechaVencimientoCalibracion}");
                Console.WriteLine($"Archivo: {inst.UrlArchivo}");
                Console.WriteLine($"MD5: {inst.MD5}");
                Console.WriteLine($"Estatus: {inst.Estatus}");
                Console.WriteLine($"Fecha Registro: {inst.FechaRegistro}");
                Console.WriteLine("---------------------------");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener instrumentos. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }


    }
    else if (opcion == "2")
    {

        var instrumento = new ApiClientLibrary.Models.InstrumentoDTO
        {
            Id = "",
            Nombre = "Analizador de transformadores trifasico",
            NumeroSerie = "TRF784512",
            FechaCalibracion = DateTime.Parse("2025-09-25T18:09:22.152Z"),
            FechaVencimientoCalibracion = DateTime.Parse("2025-09-30T18:09:22.152Z"),
            UrlArchivo = "https://www.megger.com/es/producto/analizador-trifasico-verdadero-de-devanados-de-transformadores-tau3",
            MD5 = "1e59cd6d620e43541f71a0d74b0dbdec",
            Estatus = "ACTIVO",
            FechaRegistro = DateTime.UtcNow
        };

        //var instrumento = new ApiClientLibrary.Models.InstrumentoDTO
        //{
        //    Id = "",
        //    Nombre = "Megohmetro de 10kv",
        //    NumeroSerie = "MEG556218",
        //    FechaCalibracion = DateTime.Parse("2025-09-25T18:09:22.152Z"),
        //    FechaVencimientoCalibracion = DateTime.Parse("2025-09-30T18:09:22.152Z"),
        //    UrlArchivo = "https://www.megabras.com/es/get.php?file=MD10KVx.pdf",
        //    MD5 = "f72a3114c2c69f3cbc4200466793fa73",
        //    Estatus = "ACTIVO",
        //    FechaRegistro = DateTime.Parse("2025-09-25T18:09:22.152Z")
        //};

        //var instrumento = new ApiClientLibrary.Models.InstrumentoDTO
        //{
        //    Id = "",
        //    Nombre = "Puente de medicion de relacion de transformacion",
        //    NumeroSerie = "PBT334567",
        //    FechaCalibracion = DateTime.Parse("2025-09-25T18:09:22.152Z"),
        //    FechaVencimientoCalibracion = DateTime.Parse("2025-09-30T18:09:22.152Z"),
        //    UrlArchivo = "https://www.supertransporte.gov.co/documentos/2016/CertificadosCalibracion/27RutaDelSolSector3/2015/Certificado%20de%20Calibracion%202015.pdf",
        //    MD5 = "2b4d37b09773da60e5f3f443d3d8bc87",
        //    Estatus = "ACTIVO",
        //    FechaRegistro = DateTime.Parse("2025-09-25T18:09:22.152Z")
        //};


        var llamadaInstrumento = servicio.Instrumento(instrumento);

        if (llamadaInstrumento.Result.IsSuccessStatusCode)
        {
            Console.WriteLine("llamada realizada correctamente");
        }
        else
        {
            Console.WriteLine("Error llamada " + llamadaInstrumento.Result.Content.ReadAsStringAsync().Result);
        }
    }

    else if (opcion == "3")
    {
        Console.Write("Ingresa el ID del instrumento a actualizar: ");
        var id = Console.ReadLine();

        var instrumento = new InstrumentoDTO
        {
            Id = id,
            Nombre = "Analizador de transformadores trifasico",
            NumeroSerie = "TRF784512",
            FechaCalibracion = DateTime.UtcNow,
            FechaVencimientoCalibracion = DateTime.UtcNow.AddYears(1),
            UrlArchivo = "https://www.google.com/test.pdf", //la url tiene que existir sino marca error
            MD5 = "85f621081b168c9e6833acbe4855c3d8",
            Estatus = "INACTIVO",
            FechaRegistro = DateTime.UtcNow
        };

        var respuesta = await servicio.InstrumentoPutAsync(instrumento);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Instrumento actualizado correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar instrumento. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }

    /////////////////// Prototipo ///////////////////////
    else if (opcion == "4")
    {
        var respuesta = await servicio.PrototipoGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var prototipos = JsonSerializer.Deserialize<List<PrototipoDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("\n--- PROTOTIPOS REGISTRADOS ---");
            foreach (var prot in prototipos)
            {
                Console.WriteLine($"ID: {prot.Id}");
                Console.WriteLine($"Número: {prot.Numero}");
                Console.WriteLine($"Fecha Emisión: {prot.FechaEmision}");
                Console.WriteLine($"Fecha Vencimiento: {prot.FechaVencimiento}");
                Console.WriteLine($"Archivo: {prot.UrlArchivo}");
                Console.WriteLine($"MD5: {prot.MD5}");
                Console.WriteLine($"Estatus: {prot.Estatus}");
                Console.WriteLine($"Fecha Registro: {prot.FechaRegistro}");
                Console.WriteLine("---------------------------");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener prototipos. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    else if (opcion == "5") //POST
    {
        var prototipo = new PrototipoDTO
        {
            Id = "",
            Numero = "CEP-0SF2025",
            FechaEmision = DateTime.Parse("2025-09-25T18:43:28.299Z"),
            FechaVencimiento = DateTime.Parse("2025-09-30T18:43:28.299Z"),
            UrlArchivo = "https://www.google.com", // importante: que la URL sea válida
            MD5 = "0cf113fe8274b932ddd7c999d5f7863d",
            Estatus = "ACTIVO",
            FechaRegistro = DateTime.Parse("2025-09-25T18:43:28.299Z")
        };

        var llamadaPrototipo = await servicio.PrototipoPostAsync(prototipo);

        if (llamadaPrototipo.IsSuccessStatusCode)
        {
            Console.WriteLine(" Prototipo registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Error llamada " + await llamadaPrototipo.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "6") // PUT
    {
        Console.Write("Ingresa el ID del prototipo a actualizar: ");
        var id = Console.ReadLine();

        var prototipo = new PrototipoDTO
        {
            Id = id,
            Numero = "CEP-0SF2025",
            FechaEmision = DateTime.UtcNow,
            FechaVencimiento = DateTime.UtcNow.AddYears(1),
            UrlArchivo = "https://www.google.com/test.pdf", // debe ser accesible
            MD5 = "1234567890abcdef1234567890abcdef",
            Estatus = "INACTIVO",
            FechaRegistro = DateTime.UtcNow
        };

        var respuesta = await servicio.PrototipoPutAsync(prototipo);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Prototipo actualizado correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar prototipo. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    ////////////////////////////////////// NORMA ///////////////////////////////////
    else if (opcion == "7") // GET NORMA
    {
        var respuesta = await servicio.NormaGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var normas = JsonSerializer.Deserialize<List<NormaDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("\n--- NORMAS REGISTRADAS ---");
            foreach (var n in normas)
            {
                Console.WriteLine($"ID: {n.Id}");
                Console.WriteLine($"Clave: {n.Clave}");
                Console.WriteLine($"Nombre: {n.Nombre}");
                Console.WriteLine($"Edición: {n.Edicion}");
                Console.WriteLine($"Estatus: {n.Estatus}");
                Console.WriteLine($"Es CFE: {n.EsCFE}");
                Console.WriteLine($"Fecha Registro: {n.FechaRegistro}");
                Console.WriteLine("---------------------------");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener normas. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    else if (opcion == "8") // POST NORMA
    {
        var norma = new NormaDTO
        {
            Id = "",
            Clave = "E0000-78",
            Nombre = "CFE",
            Edicion = "edicion 2024",
            Estatus = "VIGENTE",
            EsCFE = true,
            FechaRegistro = DateTime.UtcNow
        };

        var llamada = await servicio.NormaPostAsync(norma);

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Norma registrada correctamente.");
        }
        else
        {
            Console.WriteLine("Error llamada " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "9") // PUT NORMA
    {
        Console.Write("Ingresa el ID de la norma a actualizar: ");
        var id = Console.ReadLine();

        var norma = new NormaDTO
        {
            Id = id,
            Clave = "E0000-78",
            Nombre = "CFE",
            Edicion = "edicion 2024",
            Estatus = "VIGENTE",
            EsCFE = true,
            FechaRegistro = DateTime.UtcNow
        };

        var respuesta = await servicio.NormaPutAsync(norma);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Norma actualizada correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar norma. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }




    ///////////////////////// PRODUCTO ////////////////////////////////////
    else if (opcion == "10") // GET PRODUCTO
    {
        var respuesta = await servicio.ProductoGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var productos = JsonSerializer.Deserialize<List<ProductoDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("\n--- PRODUCTOS REGISTRADOS ---");
            foreach (var p in productos)
            {
                Console.WriteLine($"ID: {p.Id}");
                Console.WriteLine($"Código Fabricante: {p.CodigoFabricante}");
                Console.WriteLine($"Descripción: {p.Descripcion}");
                Console.WriteLine($"Descripción Corta: {p.DescripcionCorta}");
                Console.WriteLine($"Tipo Fabricación: {p.TipoFabricacion}");
                Console.WriteLine($"Unidad: {p.Unidad}");

                // Accediendo a propiedades internas
                Console.WriteLine($"* Norma: {p.Norma?.Clave} - {p.Norma?.Nombre}");
                Console.WriteLine($"* Prototipo: {p.Prototipo?.Numero} - {p.Prototipo?.Estatus}");

                Console.WriteLine($"Estatus: {p.Estatus}");
                Console.WriteLine($"Fecha Registro: {p.FechaRegistro}");

                // Para la lista de pruebas
                if (p.Pruebas != null && p.Pruebas.Count > 0)
                {
                    Console.WriteLine("* Pruebas: " + string.Join(", ", p.Pruebas.Select(x => x.Nombre)));
                }
                else
                {
                    Console.WriteLine("Pruebas: -");
                }

                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener productos. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    else if (opcion == "11") // POST PRODUCTO
    {
        var producto = new ProductoPDTO
        {
            Id = "",
            CodigoFabricante = "0002",
            Descripcion = "TRANSFORMADOR DE DISTRIBUCION TIPO POSTE 10 KVA",
            DescripcionCorta = "TRANSFORMADOR DC3 15 13200 220-127",
            TipoFabricacion = "LOTE",
            Unidad = "pz",
            Norma = "68d56748997c4a1351387aec",
            Prototipo = "68d5679c997c4a1351387af2",
            Estatus = "ACTIVO",
            FechaRegistro = DateTime.UtcNow,
            Pruebas = new List<string> { "68d56892997c4a1351387afc", "68d568af997c4a1351387afd", "68d568c2997c4a1351387aff" } // solo los IDs
        };

        var llamada = await servicio.ProductoPostAsync(producto);

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Producto registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Error llamada " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "12") // PUT PRODUCTO
    {
        Console.Write("Ingresa el ID del producto a actualizar: ");
        var id = Console.ReadLine();

        var producto = new ProductoPDTO
        {
            Id = id,
            CodigoFabricante = "0001",
            Descripcion = "Alambre TWD",
            DescripcionCorta = "ACSR 3/0",
            TipoFabricacion = "SERIE",
            Unidad = "kg",
            Norma = "68d2ecafce3b00aacea971f8",        
            Prototipo = "68d2eb10ce3b00aacea971e9",   
            Estatus = "INACTIVO",
            FechaRegistro = DateTime.UtcNow,
            Pruebas = new List<string> { "68d2eec0ce3b00aacea97203" } 
        };

        var respuesta = await servicio.ProductoPutAsync(producto);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Producto actualizado correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar producto. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }


    ///////////////////// PRUEBA ///////////////////////
    else if (opcion == "13") // GET PRUEBA
    {
        var respuesta = await servicio.PruebaGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var pruebas = JsonSerializer.Deserialize<List<PruebaDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("\n--- PRUEBAS REGISTRADAS ---");
            foreach (var p in pruebas)
            {
                Console.WriteLine($"ID: {p.Id}");
                Console.WriteLine($"Nombre: {p.Nombre}");
                Console.WriteLine($"Estatus: {p.Estatus}");
                Console.WriteLine($"Tipo Prueba: {p.TipoPrueba}");
                Console.WriteLine($"Tipo Resultado: {p.TipoResultado}");
                Console.WriteLine($"Fecha Registro: {p.FechaRegistro}");
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener pruebas. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    else if (opcion == "14") // POST PRUEBA
    {
        //var prueba = new PruebaDTO
        //{
        //    Id = "",
        //    Nombre = "Resistencia de aislamiento entre devanados",
        //    Estatus = "ACTIVA",
        //    TipoPrueba = "ACEPTACION",
        //    TipoResultado = "PASA/NO-PASA",
        //    FechaRegistro = DateTime.UtcNow
        //};

        //var prueba = new PruebaDTO
        //{
        //    Id = "",
        //    Nombre = "Perdidas en vacio y carga nominal",
        //    Estatus = "ACTIVA",
        //    TipoPrueba = "ACEPTACION",
        //    TipoResultado = "PASA/NO-PASA",
        //    FechaRegistro = DateTime.UtcNow
        //};

        var prueba = new PruebaDTO
        {
            Id = "",
            Nombre = "Prueba dielectrica entre devanados",
            Estatus = "ACTIVA",
            TipoPrueba = "ACEPTACION",
            TipoResultado = "PASA/NO-PASA",
            FechaRegistro = DateTime.UtcNow
        };

        var llamada = await servicio.PruebaPostAsync(prueba);

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Prueba registrada correctamente.");
        }
        else
        {
            Console.WriteLine("Error llamada " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "15") // PUT PRUEBA
    {
        Console.Write("Ingresa el ID de la prueba a actualizar: ");
        var id = Console.ReadLine();

        var prueba = new PruebaDTO
        {
            Id = id,
            Nombre = "Cobre",
            Estatus = "ACTIVA",
            TipoPrueba = "ACEPTACION",
            TipoResultado = "VALOR_REFERENCIA",
            FechaRegistro = DateTime.UtcNow
        };

        var respuesta = await servicio.PruebaPutAsync(prueba);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Prueba actualizada correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar prueba. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }


    /////////////////// ValorReferencia ///////////////////////
    else if (opcion == "16")
    {
        var respuesta = await servicio.ValorReferenciaGetAsync();

        if (respuesta.IsSuccessStatusCode)
        {
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var valores = JsonSerializer.Deserialize<List<ValorReferenciaDTO>>(contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Console.WriteLine("\n--- VALORES DE REFERENCIA ---");
            foreach (var v in valores)
            {
                Console.WriteLine($"ID: {v.Id}");
                Console.WriteLine($"IdProducto: {v.IdProducto}");
                Console.WriteLine($"IdPrueba: {v.IdPrueba}");
                Console.WriteLine($"Valor: {v.Valor}");
                Console.WriteLine($"Valor2: {v.Valor2}");
                Console.WriteLine($"Unidad: {v.Unidad}");
                Console.WriteLine($"Comparación: {v.Comparacion}");
                Console.WriteLine($"Fecha Registro: {v.FechaRegistro}");
                Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||");
            }
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($"X Error al obtener valores de referencia. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }
    else if (opcion == "17")
    {
        //var valor = new ValorReferenciaDTO
        //{
        //    Id = "",
        //    IdProducto = "68d56ac5997c4a1351387b11",
        //    IdPrueba = "68d56892997c4a1351387afc", //Resistencia de aislamiento entre devanados
        //    Valor = 1000,
        //    Valor2 = 10,
        //    Unidad = "ohm/kv",
        //    Comparacion = "VALOR_MINIMO",
        //    FechaRegistro = DateTime.UtcNow //DateTime.Parse("2025-09-24T20:32:55.545Z")
        //};

        //var valor = new ValorReferenciaDTO
        //{
        //    Id = "",
        //    IdProducto = "68d56ac5997c4a1351387b11",
        //    IdPrueba = "68d568af997c4a1351387afd",   //Perdidas en vacio y carga nominal
        //    Valor = 70,
        //    Valor2 = 0,
        //    Unidad = "w",
        //    Comparacion = "VALOR_MAXIMO",
        //    FechaRegistro = DateTime.UtcNow //DateTime.Parse("2025-09-24T20:32:55.545Z")
        //};

        var valor = new ValorReferenciaDTO
        {
            Id = "",
            IdProducto = "68d56ac5997c4a1351387b11",
            IdPrueba = "68d568c2997c4a1351387aff", // Prueba dielectrica entre devanados
            Valor = 35,
            Valor2 = 0,
            Unidad = "kva",
            Comparacion = "NO_COMPARAR",
            FechaRegistro = DateTime.UtcNow //DateTime.Parse("2025-09-24T20:32:55.545Z")
        };

        var llamada = await servicio.ValorReferenciaPostAsync(valor);

        if (llamada.IsSuccessStatusCode)
        {
            Console.WriteLine(" Valor de referencia registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Error llamada " + await llamada.Content.ReadAsStringAsync());
        }
    }
    else if (opcion == "18") //PUT
    {
        Console.Write("Ingresa el ID del valor de referencia a actualizar: ");
        var id = Console.ReadLine();

        var valor = new ValorReferenciaDTO
        {
            Id = id,
            IdProducto = "68d2f021ce3b00aacea97213",
            IdPrueba = "68d2eec0ce3b00aacea97203",
            Valor = 10,
            Valor2 = 0,
            Unidad = "ohm/km",
            Comparacion = "VALOR_MINIMO",
            FechaRegistro = DateTime.UtcNow
        };

        var respuesta = await servicio.ValorReferenciaPutAsync(valor);

        if (respuesta.IsSuccessStatusCode)
        {
            Console.WriteLine(" Valor de referencia actualizado correctamente.");
        }
        else
        {
            var error = await respuesta.Content.ReadAsStringAsync();
            Console.WriteLine($" Error al actualizar valor de referencia. Código: {respuesta.StatusCode}");
            Console.WriteLine($"Detalle: {error}");
        }
    }

  










}


