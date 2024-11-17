$(document).ready(function () {
    var listaDatoscampaña = [];

    // Función para cargar las campañas desde la API
    function cargarcampañas() {
        $.getJSON('http://localhost:5078/api/campaña/Obtenercampañas', function (data) {
            listaDatoscampaña = data.result;
            console.log(data);
            $("#gridContainer").dxDataGrid("instance").option("dataSource", listaDatoscampaña);
        }).fail(function () {
            alert('Error al cargar campañas.');
        });
    }

    // Inicializa la tabla de campañas (DataGrid)
    function inicializarGrid() {
        $("#gridContainer").dxDataGrid({
            dataSource: listaDatoscampaña,
            columnAutoWidth: true,
            columns: [
                { dataField: "id", caption: "ID" },
                { dataField: "nombreCampaña", caption: "Nombre de campaña" },
                { dataField: "fase.nombreFase", caption: "Fase" },
                { dataField: "descripcion", caption: "Descripción" },
                { dataField: "fecha_inicial", caption: "Fecha Inicio", dataType: "date" },
                { dataField: "fecha_final", caption: "Fecha Final", dataType: "date" },
                {
                    caption: "Acciones",
                    width: 100,
                    cellTemplate: function (container, options) {
                        var editButton = $("<i>")
                            .addClass("fas fa-edit")
                            .attr("title", "Editar campaña")
                            .css({ "cursor": "pointer", "margin-right": "10px" })
                            .click(function () {
                                editarFilacampaña(options.data);
                            });

                        var deleteButton = $("<i>")
                            .addClass("fas fa-trash")
                            .attr("title", "Eliminar campaña")
                            .css({ "cursor": "pointer", "margin-right": "10px" })
                            .click(function () {
                                eliminarFilacampaña(options.data);
                            });
                            
                            var uploadButton = $("<i>")
                            .addClass("fas fa-file-upload")
                            .attr("title", "Cargar archivo Excel")
                            .css({ "cursor": "pointer", "margin-right": "10px" })
                            .click(function () {
                                // Muestra el modal
                                $('#cargarExcelModal').modal('show');
                        
                                // Guarda el id de la campaña en un atributo data
                                $('#btnCargarExcel').data('campaignId', options.data.id);
                                $('#btnCargarExcel2').data('campaignId', options.data.id);
                            });
                        
                            
                        container.append(editButton).append(deleteButton).append(uploadButton);
                    }
                }
            ],
            paging: {
                pageSize: 5
            },
            pager: {
                showPageSizeSelector: true,
                allowedPageSizes: [5, 10, 20],
                showInfo: true
            },
            filterRow: {
                visible: true
            },
            searchPanel: {
                visible: true,
                placeholder: "Buscar..."
            },
            export: {
                enabled: true,
                fileName: "campañas"
            }
        });
    }

    $('#btnCargarExcel').click(function () {
        var campaignId = $(this).data('campaignId');
        cargarArchivoExcel('laboratorio', campaignId); // Pasamos 'laboratorio' como tipo de carga
        // $('#cargarExcelModal').modal('hide'); // Cierra el modal
    });

    // Evento para el botón de Cargar Excel - Campo
    $('#btnCargarExcel2').click(function () {
        var campaignId = $(this).data('campaignId');
        cargarArchivoExcel('campo', campaignId); // Pasamos 'campo' como tipo de carga
        // $('#cargarExcelModal').modal('hide'); // Cierra el modal
    });

    $('#modalExcel').on('hidden.bs.modal', function () {
        $('#cargarExcelModal').modal('show');
    });

    // Manejo del botón para agregar una nueva campaña
    $('#btnAgregar').click(function () {
        $('#vistaAgregar').show(); // Mostrar vista de agregar
        $('#vistaEditar').hide();   // Ocultar vista de editar
        $('#vistaPrincipal').hide(); // Ocultar tabla de campañas
        $('#formNuevoDato')[0].reset(); // Resetear el formulario de agregar
    });

    // Guardar una nueva campaña
    $('#btnGuardarDato').click(function () {
        // Obtener valores del formulario
        var NombreCampaña = $('#nombreCampaña').val();
        var IdFase = $('#Fase').val();
        var Descripcion = $('#editDescripcion').val();  // Cambiar ID del campo de descripción
        var Fecha_inicial = $('#Fecha_inicio').val();
        var Fecha_final = $('#Fecha_fin').val();

        // Validación con nombres correctos
        if (!NombreCampaña || !Descripcion || !Fecha_inicial || !Fecha_final) {
            alert("Todos los campos son requeridos.");
            return;
        }

        var nuevacampaña = { NombreCampaña, IdFase, Descripcion, Fecha_inicial, Fecha_final };

        // Petición AJAX para guardar la campaña
        $.ajax({
            url: 'http://localhost:5078/api/campaña/AgregarCampaña',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(nuevacampaña),
            success: function (result) {
                Swal.fire({
                    icon: 'success',
                    title: 'Campaña agregada',
                    text: 'La campaña fue agregada exitosamente.'
                });
                cargarcampañas();
                $('#formNuevoDato')[0].reset();
                $('#vistaPrincipal').show();
                $('#vistaAgregar').hide();
            },
            error: function (xhr) {
                Swal.fire({
                    icon: 'error',
                    title: 'Error',
                    text: 'Error al crear campaña en el servidor. Código: ' + xhr.status
                });
            }
        });
    });

    // Función para editar una fila de campaña
    function editarFilacampaña(data) {
        $('#editid').val(data.id); // Almacena el ID en un campo oculto
        $('#editnombreCampaña').val(data.nombreCampaña);
        $('#editFase').val(data.fase.nombreFase); // Usa el ID de fase
        $('#editdescripcion').val(data.descripcion);
        $('#editFecha_inicio').val(data.fecha_inicial.split('T')[0]); // Formato correcto para input date
        $('#editFecha_fin').val(data.fecha_final.split('T')[0]); // Formato correcto para input date

        $('#vistaEditar').show();   // Mostrar vista de edición
        $('#vistaPrincipal').hide(); // Ocultar tabla de campañas
        $('#vistaAgregar').hide();   // Ocultar vista de agregar
    }

    $('#btnActualizarDato').click(function () {
        var id = $('#editid').val();
        var nombreCampaña = $('#editnombreCampaña').val();
        var fase = $('#editFase').val();
        var descripcion = $('#editdescripcion').val();
        var fecha_inicial = $('#editFecha_inicio').val();
        var fecha_final = $('#editFecha_fin').val();

        if (!id) {
            alert('ID de campaña no encontrado.');
            return;
        }

        var campañaActualizada = { id, nombreCampaña, fase, descripcion, fecha_inicial, fecha_final };

        $.ajax({
            url: 'http://localhost:5078/api/campaña/ActualizarCampaña/' + id,
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(campañaActualizada),
            success: function (result) {
                if (result.success) {
                    cargarcampañas();
                    $('#vistaEditar').hide();
                    $('#formEditarDato')[0].reset();
                    $('#vistaPrincipal').show();
                } else {
                    alert('Error al actualizar la campaña.');
                }
            },
            error: function () {
                alert('Error al actualizar la campaña.');
            }
        });
    });

    // Función para eliminar una campaña
    function eliminarFilacampaña(data) {
        Swal.fire({
            title: '¿Estás seguro?',
            text: "¡No podrás revertir esta acción!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: 'http://localhost:5078/api/campaña/Eliminarcampaña/' + data.id,
                    type: 'DELETE',
                    success: function (result) {
                        Swal.fire('Eliminado!', 'El registro ha sido eliminado.', 'success');
                        cargarcampañas();
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'Error al eliminar la campaña.'
                        });
                    }
                });
            }
        });
    }

    var rowsWithErrors = [];

function verificarCodigoEnBackend(codigo) {
    if (!codigo) {
        console.error('Código es undefined o vacío');
        return Promise.resolve({ exists: false });
    }

    return $.ajax({
        url: 'http://localhost:5078/api/estacion/ObtenerEstacionCodigo/' + codigo,
        type: 'GET',
        dataType: 'json'
    }).then(function (response) {
        console.log('Respuesta del backend para el código ' + codigo + ':', response);
        return { exists: response.isSuccess }; // Devuelve si la estación fue encontrada
    }).catch(function (xhr) {
        if (xhr.status === 404) {
            console.error('Código no encontrado:', codigo);
            return { exists: false }; // Devuelve que no existe
        } else {
            console.error('Error al verificar el código:', codigo);
            return { exists: false }; // Manejar otros errores también como no encontrado
        }
    });
}

function verificarCodigosEstacion(excelData) {
    // Limpiar cualquier error anterior
    rowsWithErrors = [];
    
    var verificationPromises = [];
    var errorDetected = false;

    // Para cada fila de datos en el Excel
    excelData.forEach(function (row, index) {
        var codigoEstacion = row.Código;

        if (!codigoEstacion) {
            console.error('El código en la fila ' + index + ' es undefined o vacío. Fila:', row);
            return; // Salta a la siguiente fila si el código es vacío
        }

        var promise = verificarCodigoEnBackend(codigoEstacion).then(function (response) {
            if (!response.exists) {
                console.log('El código no existe:', codigoEstacion);
                rowsWithErrors.push(index); // Guardar el índice de la fila con error
                errorDetected = true;
            }
        }).catch(function () {
            console.error('Error al verificar el código:', codigoEstacion);
            errorDetected = true;
        });

        verificationPromises.push(promise);
    });

    // Esperar a que todas las verificaciones terminen
    $.when.apply($, verificationPromises).done(function () {
        if (errorDetected) {
            alert('Algunas estaciones no están registradas. Corrija el archivo y vuelva a intentarlo.');
            $('#botonProcesar').hide(); // Ocultar el botón de procesar
        } else {
            console.log("Todas las verificaciones completadas sin errores. Mostrando botón.");
            $("#botonProcesar").show(); // Mostrar el botón que procesa los datos
        }
    });
}
    
function agregarInsitu(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/Insitu/AgregarInsitu',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('insitu agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar insitu: ', xhr.status);
        return null;
    });
}

function agregarFisico(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/fisico/AgregarFisico',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('Físico agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar Físico: ', xhr.status);
        return null;
    });
}

function agregarQuimico(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/Quimico/AgregarQuimico',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('Quimico agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar Quimico: ', xhr.status);
        return null;
    });
}

function agregarNutriente(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/Nutriente/AgregarNutriente',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('Nutriente agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar Nutriente: ', xhr.status);
        return null;
    });
}

function agregarMetalAgua(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/MetalAgua/AgregarMetal',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('MetalAgua agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar MetalAgua: ', xhr.status);
        return null;
    });
}

function agregarMetalSedimento(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/MetalSedimental/AgregarMetalSedimental',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('MetalSedimental agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar MetalSedimental: ', xhr.status);
        return null;
    });
}

function agregarBiologico(datos) {
    return $.ajax({
        url: 'http://localhost:5078/api/Biologico/AgregarBiologico',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(datos)
    }).then(function(response) {
        console.log('Biologico agregado exitosamente', response);
        return response;
    }).catch(function(xhr) {
        console.error('Error al agregar Biologico: ', xhr.status);
        return null;
    });
}
    $('#botonProcesar').click(function() {
        // Accede a todos los datos en el dataSource
        var excelData = $("#excelGridContainer").dxDataGrid("instance").option("dataSource");
        procesarDatosPorRango(excelData);
        
        // Cierra la modal
        $('#modalExcel').dialog('close');
        
        // Muestra un mensaje de confirmación
        var campaignId = $('#btnCargarExcel').data('campaignId');
        $('#btnCargarExcel').hide();
        $('#btnCargarExcel').after('<p>Excel de Laboratorio cargado exitosamente</p>');
    });
    
    $('#botonProcesar2').click(function() {
        // Accede a todos los datos en el dataSource
        var excelData = $("#excelGridContainer").dxDataGrid("instance").option("dataSource");
        procesarDatosPorRango2(excelData);
        
        // Cierra la modal
        $('#modalExcel').dialog('close');
        
        // Muestra un mensaje de confirmación
        var campaignId = $('#btnCargarExcel2').data('campaignId');
        $('#btnCargarExcel2').hide();
        $('#btnCargarExcel2').after('<p>Excel de Campo cargado exitosamente</p>');
    });
    

    async function procesarDatosPorRango2(excelData) {
        var campaignId = $('#btnCargarExcel2').data('campaignId');
    
        for (const row of excelData) {
            // Campo
            var Campo = {
                Hora: row["Hora"]|| null || undefined,
                TempAmbiente: row["Temperatura Ambiente (°C)"]|| null || undefined,
                TempAgua: row["Temperatura Agua (°C)"]|| null || undefined,
                Ph: row["pH (U de pH)"]|| null || undefined,
                Od: row["Oxígeno disuelto (mg/L)"]|| null || undefined,
                Conductiviidad_electrica: row["Conductividad eléctrica (µS/cm)"]|| null || undefined,
                Orp: row["Potencial"]|| null || undefined,
                Turb: row["Turbiedad (NTU)"]|| null || undefined,
                Tiempo: row["Estado del tiempo"]|| null || undefined,
                Apariencia: row["Apariencia"]|| null || undefined,
                Olor: row["Olor"]|| null || undefined,
                Color: row["Color"]|| null || undefined,
                Altura: row["Altura (m)"]|| null || '',
                H1: row["H1 (m)"]|| null || '',
                H2: row["H2 (m)"]|| null || '',
                Observacion: row ["Observación"]|| null || ''
            };
            const response = await guardarAgregarResultadoLaboratorio(Campo);
            row.idCampo = response.result.idCampo;
                        console.log(excelData)
        }
    
        // Guardar el array en el local storage
        localStorage.setItem('excelData', JSON.stringify(excelData));
    }

    function guardarAgregarResultadoLaboratorio(datos) {
        return $.ajax({
            url: 'http://localhost:5078/api/ResultadoCampo/AgregarResultadoLaboratorio',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(datos)
        }).then(function(response) {
            console.log(' Laboratorio campo, Datos guardados exitosamente');
            return response;
        }).catch(function(xhr) {
            console.error('Error al guardar datos: ', xhr.status);
            console.error(xhr.responseText);        
        });
    }
    async function procesarDatosPorRango(excelData) {
        var campaignId = $('#btnCargarExcel').data('campaignId');
    
        for (const row of excelData) {
            // Rango Insitu
            var insitu = {
                Temp_ambiente: row["Temperatura Ambiente (°C)"]|| null,
                Tem_agua: row["Temperatura Agua (°C)"]|| null,
                Ph: row["pH (U de pH)"]|| null,
                Oxigeno_disuelto: row["Oxígeno disuelto (mg/L)"]|| null,
                Conductiviidad_electrica: row["Conductividad eléctrica (µS/cm)"]|| null,
                Orp: row["Potencial Redox (mV)"]|| null,
                Turbiedad: row["Turbiedad (NTU)"]|| null
            };
            const response = await agregarInsitu(insitu);
            console.log(response);
            row.IdInsitu = response.result.idInsitu;
            
    
            // Rango Físico
            var VarFisico = {
                Caudal: row["Caudal (m3/s)"] || null, // Asignar directamente, si está vacío, será null
                ClasificacionCaudal: row["Clasificación caudal (Adim)"] || null,
                NumeroVerticales: row["Número de verticales"] || null,
                ColorVerdaderoUPC: row["Color verdadero (UPC)"] || null,
                ColorTriestimular436nm: row["Color triestimular 436 nm"] || null,
                ColorTriestimular525nm: row["Color triestimular 525 nm"] || null,
                ColorTriestimular620nm: row["Color triestimular 620 nm"] || null,
                SolidosSuspendidosTotales: row["Sólidos suspendidos totales (mg/L)"] || null,
                SolidosTotales: row["Sólidos totales (mg/L)"] || null,
                SolidosVolatilesTotales: row["Sólidos volátiles totales (mg/L)"] || null,
                SolidosDisueltosTotales: row["Sólidos disueltos totales (mg/L)"] || null,
                SolidosFijosTotales: row["Sólidos fijos totales (mg/L)"] || null,
                SolidosSedimentables: row["Sólidos sedimentables (ml/L-h)"] || null
            };
            const responseFisico = await agregarFisico(VarFisico);
            row.IdFisico = responseFisico.result.idFisico;
    
            // Rango Químico
            var quimico = {
                Db05: row["DBO5 (mg/L)"] || null,
                Dq0: row["DQO (mg/L)"] || null,
                HierroTotal: row["Hierro total (mg Fe/L)"] || null,
                Sulfatos: row["Sulfatos (mg/L)"] || null,
                Sulfuros: row["Sulfuros (mg/L)"] || null,
                Clororus: row["Clororus (mg/L)"] || null,
                Grasa_Aceite: row["Grasas y/o aceites (mg/L)"] || null,
                sustanciaActivaAzulMetileno: row["SAAM (mg/L)"] || null
            };
            const responseQuimico = await agregarQuimico(quimico);
            row.IdQuimico = responseQuimico.result.idQuimico;
    
            // Rango Nutriente
            var nutriente = {
                Fosforo_total: row["Fósforo total (mg P/L)"] || null,
                Fosfato: row["Fosfato (mg P/L)"] || null,
                Fosforo_organico: row["Fósforo orgánico (mg P/L)"] || null,
                Nitratos: row["Nitratos (mg N/L)"] || null,
                Nitritos: row["Nitritos (mg N/L) "] || null,
                Nitrogeno_organico: row["Nitrógeno orgánico (mg N/L)"] || null,
                Nitrogeno_total_kjeldahl: row["Nitrógeno total Kjeldahl (mg N/L)"] || null
            };
            const responseNutriente = await agregarNutriente(nutriente);
            row.IdNutriente = responseNutriente.result.idNutriente;
    
            // Rango Metal Agua
            var metalAgua = {
                Cadmio: row["Cadmio (mg Cd/L)"] || null,
                Cobre: row["Cobre (mg Cu/L)"] || null,
                Cromo: row["Cromo (mg Cr/L)"] || null,
                Cromo_hexavalente: row["Cromo hexavalente (mg Cr6+/L)"] || null,
                Mercurio: row["Mercurio (mg Hg/L)"] || null,
                Niquel: row["Niquel (mg Ni/L)"] || null,
                Plomo: row["Plomo (mg Pb/L)"] || null
            };
            const responseMetalAgua = await agregarMetalAgua(metalAgua);
            row.IdMetalAgua = responseMetalAgua.result.idMetalAgua;
    
            // Rango Metal Sedimento
            var metalSedimento = {
                Cadmio_sedimentable: row["Cadmio sedimentable (mg Cd/L)"] || null,
                Cobre_sedimentable: row["Cobre sedimentable (mg Cu/L)"] || null,
                Cromo_sedimentable: row["Cromo sedimentable (mg Cr/L)"] || null,
                Mercurio_sedimentable: row["Mercurio sedimentable (mg Hg/L)"] || null,
                Plomo_sedimentable: row["Plomo sedimentable (mg Pb/L)"] || null,
            };
            const responseMetalSedimento = await agregarMetalSedimento(metalSedimento);
            row.idMetalSedimento = responseMetalSedimento.result.idMetalSedimento;
    
            // Rango Biológico
            var biologico = {
                Escherichia_coli: row["Escherichia coli (UFC)"] || null,
                Coliformes_totales_ufc: row["Coliformes totales (UFC)"] || null,
                Escherichia_coli_npm: row["Escherichia coli (NMP/100mL)"] || null,
                Coliformes_totales_npm: row["Coliformes totales (NMP/100mL)"] || null,
                Riquezas_algas: row["Riqueza algas"] || null,
                Indice_biologico: row["Indice biológico BMWP"] || null,
                ClasificacionIBiologico: row["Clasificación Indice biológico BMWP"] || null,
                Observaciones: row ["Observaciones (algas y macroinvertebrados)"] || null
            };
            const responseBiologico = await agregarBiologico(biologico);
            row.IdBiologico = responseBiologico.result.idBiologico;
        }
    
        // Guardar el array en el local storage
        localStorage.setItem('excelData', JSON.stringify(excelData));
    }

    function verificarColumnasExcel(tipoCarga, columnas) {
        var columnasRequeridas = [];
    
        if (tipoCarga === 'laboratorio') {
            columnasRequeridas = [
                "Temperatura Ambiente (°C)",
                "Temperatura Agua (°C)",
                "pH (U de pH)",
                "Oxígeno disuelto (mg/L)",
                "Conductividad eléctrica (µS/cm)",
                "Potencial Redox (mV)",
                "Turbiedad (NTU)",
                "Clasificación caudal (Adim)",
                "Número de verticales",
                "Color verdadero (UPC)",
                "Color triestimular 436 nm",
                "Color triestimular 525 nm",
                "Color triestimular 620 nm",
                "Sólidos suspendidos totales (mg/L)",
                "Sólidos totales (mg/L)",
                "Sólidos volátiles totales (mg/L)",
                "Sólidos disueltos totales (mg/L)",
                "Sólidos fijos totales (mg/L)",
                "Sólidos sedimentables (ml/L-h)",
                "DBO5 (mg/L)",
                "DQO (mg/L)",
                "Hierro total (mg Fe/L)",
                "Sulfatos (mg/L)",
                "Sulfuros (mg/L)",
                "Clororus (mg/L)",
                "Grasas y/o aceites (mg/L)",
                "SAAM (mg/L)",
                "Fósforo total (mg P/L)",
                "Fosfato (mg P/L)",
                "Fósforo orgánico (mg P/L)",
                "Nitratos (mg N/L)",
                "Nitritos (mg N/L)",
                "Nitrógeno orgánico (mg N/L)",
                "Nitrógeno total Kjeldahl (mg N/L)",
                "Cadmio (mg Cd/L)",
                "Cobre (mg Cu/L)",
                "Cromo (mg Cr/L)",
                "Cromo hexavalente (mg Cr6+/L)",
                "Mercurio (mg Hg/L)",
                "Niquel (mg Ni/L)",
                "Plomo (mg Pb/L)",
                "Cadmio sedimentable (mg Cd/L)",
                "Cobre sedimentable (mg Cu/L)",
                "Cromo sedimentable (mg Cr/L)",
                "Mercurio sedimentable (mg Hg/L)",
                "Plomo sedimentable (mg Pb/L)",
                "Escherichia coli (UFC)",
                "Coliformes totales (UFC)",
                "Escherichia coli (NMP/100mL)",
                "Coliformes totales (NMP/100mL)",
                "Riqueza algas",
                "Indice biológico BMWP",
                "Clasificación Indice biológico BMWP",
                "Observaciones (algas y macroinvertebrados)"
            ];
        } else if (tipoCarga === 'campo') {
            columnasRequeridas = [
                "Hora",
                "Temperatura Ambiente (°C)",
                "Temperatura Agua (°C)",
                "pH (U de pH)",
                "Oxígeno disuelto (mg/L)",
                "Conductividad eléctrica (µS/cm)",
                "Potencial",
                "Turbiedad (NTU)",
                "Estado del tiempo",
                "Apariencia",
                "Olor",
                "Color",
                "Altura (m)",
                "H1 (m)",
                "H2 (m)",
                "Observación"
            ];
        }
    
        var columnasFaltantes = columnasRequeridas.filter(function (columna) {
            return !columnas.includes(columna);
        });
    
        if (columnasFaltantes.length > 0) {
            alert("El archivo Excel es incorrecto. Faltan las siguientes columnas: " + columnasFaltantes.join(", "));
            return false;
        }
    
        return true;
    }

    function cargarArchivoExcel(tipoSeleccionado) {
        let tipoCarga = tipoSeleccionado.toLowerCase();  
        console.log('Tipo de carga seleccionada:', tipoCarga);  // Aquí debería ser 'laboratorio' o 'campo'
        
        var input = document.createElement('input');
        input.type = 'file';
        input.accept = '.xlsx, .xls';
        
        input.addEventListener('change', function(event) {
            var file = event.target.files[0];
            if (file) {
                var reader = new FileReader();
                reader.onload = function(e) {
                    var data = new Uint8Array(e.target.result);
                    var workbook = XLSX.read(data, { type: 'array' });
                    
                    var firstSheetName = workbook.SheetNames[0];
                    var worksheet = workbook.Sheets[firstSheetName];
                    var range = XLSX.utils.decode_range(worksheet['!ref']);
                    var columns = [];
                    
                    // Extraer los nombres de las columnas
                    for (var C = range.s.c; C <= range.e.c; ++C) {
                        var cell = worksheet[XLSX.utils.encode_cell({ r: range.s.r, c: C })];
                        columns.push(cell ? cell.v : '');
                    }
                    
                    if (!verificarColumnasExcel(tipoCarga, columns)) {
                        return;
                    }
                    
                    var excelData = [];
                    for (var R = range.s.r + 1; R <= range.e.r; ++R) {
                        var row = {};
                        var isEmptyRow = true;
                        
                        for (var C = range.s.c; C <= range.e.c; ++C) {
                            var cell = worksheet[XLSX.utils.encode_cell({ r: R, c: C })];
                            var columnName = columns[C];
                            var cellValue = (cell && cell.v) ? cell.v : '';
                            
                            var cellValue = '';
                            if (cell) {
                                if (typeof cell.v === 'string' && cell.v.trim() === '#N/A') {
                                    cellValue = '';
                                } else if (typeof cell.v === 'string' && cell.v.trim() === '') {
                                    cellValue = '';
                                } else {
                                    // Manejo de valores de hora
                                    if (columnName === 'Hora' && cell.t === 'n') {
                                        var dateObject = XLSX.SSF.parse_date_code(cell.v);
                                        if (dateObject) {
                                            cellValue = ('0' + dateObject.H).slice(-2) + ':' + ('0' + dateObject.M).slice(-2);
                                        } else {
                                            cellValue = cell.v;
                                        }
                                    } else {
                                        cellValue = cell.v;
                                    }
                                }
                            }
                            
                            row[columnName] = cellValue;
                            
                            if (cellValue !== '') {
                                isEmptyRow = false;
                            }
                        }
                        
                        if (!isEmptyRow) {
                            excelData.push(row);
                        }
                    }
                    
                    console.log('Datos procesados:', excelData);
                    
                    // Configuración del grid y otras funcionalidades
                    verificarCodigosEstacion(excelData);
                    
                    $("#excelGridContainer").empty();
                    
                    var columnas = columns.map(key => ({
                        dataField: key,
                        caption: key,
                        allowFiltering: true,
                        allowSorting: true,
                        dataType: (key === "pH (U. de pH)" ? "number" : "string")
                    }));
                    
                    $("#excelGridContainer").dxDataGrid({
                        dataSource: excelData,
                        columns: columnas,
                        columnAutoWidth: true,
                        wordWrapEnabled: true,
                        showBorders: true,
                        paging: {
                            pageSize: 10
                        },
                        pager: {
                            showPageSizeSelector: true,
                            allowedPageSizes: [5, 10, 20],
                            showInfo: true
                        },
                        filterRow: {
                            visible: true
                        },
                        headerFilter: {
                            visible: true
                        },
                        searchPanel: {
                            visible: true,
                            width: 240,
                            placeholder: "Buscar..."
                        },
                        export: {
                            enabled: true,
                            fileName: "DatosExcel"
                        },
                        onRowPrepared: function(info) {
                            if (info.rowType === "data" && rowsWithErrors.includes(info.rowIndex)) {
                                $(info.rowElement).css("background-color", "red");
                            }
                        }
                    });
    
                    $('#modalExcel').dialog({
                        modal: true,
                        width: '90%',
                        height: 600,
                        title: "Datos del archivo Excel",
                        close: function() {
                            $("#excelGridContainer").dxDataGrid("instance").option("dataSource", []);
                            $('#botonProcesar').hide();
                            $('#botonProcesar2').hide();
                            var dataGridInstance = $("#excelGridContainer").dxDataGrid("instance");
                            if (dataGridInstance) {
                                dataGridInstance.dispose();
                            }
                        }
                    });
    
                    // Mostrar el botón correcto según el tipo de carga (Laboratorio o Campo)
                    if (excelData.length > 0) {
                        console.log('Tipo de carga procesada: ' + tipoCarga);  // Verificar que aquí se imprima 'laboratorio' o 'campo'
    
                        // Depuración para asegurarse de que los botones existan
                        console.log('¿Existe el botón de Laboratorio?', $('#botonProcesar').length > 0);
                        console.log('¿Existe el botón de Campo?', $('#botonProcesar2').length > 0);
    
                        if (tipoCarga === 'laboratorio') {
                            console.log('Mostrando botón de laboratorio');
                            $('#botonProcesar').show();   // Mostrar el botón de Laboratorio
                            $('#botonProcesar2').hide();  // Ocultar el botón de Campo
                        } else if (tipoCarga === 'campo') {
                            console.log('Mostrando botón de campo');
                            $('#botonProcesar2').show();  // Mostrar el botón de Campo
                            $('#botonProcesar').hide();   // Ocultar el botón de Laboratorio
                        }
                    } else {
                        $('#botonProcesar').hide();
                        $('#botonProcesar2').hide();
                    }
                };
                reader.readAsArrayBuffer(file);
            }
        });
    
        input.click();
    }

    $('#terminarAccion').click(function() {
        // Obtener los IDs de los laboratorios y campos
        var insitu = JSON.parse(localStorage.getItem('insitu'));
        var fisico = JSON.parse(localStorage.getItem('fisico'));
        var quimico = JSON.parse(localStorage.getItem('quimico'));
        var nutriente = JSON.parse(localStorage.getItem('nutriente'));
        var metalAgua = JSON.parse(localStorage.getItem('metalAgua'));
        var metalSedimento = JSON.parse(localStorage.getItem('metalSedimento'));
        var biologico = JSON.parse(localStorage.getItem('biologico'));
    
        // Crear un arreglo para guardar los reportes
        var reportes = [];
    
        // Recorrer los IDs de los laboratorios y campos
        for (var i = 0; i < 1; i++) {
            // Crear un reporte para cada laboratorio y campo
            var reporte = {
                IdResultadoCampo: insitu.result.idInsitu,
                IdCampaña: $('#btnCargarExcel').data('campaignId'),
                IdEstacion: obtenerIdEstacion(insitu.result.idInsitu),
                IdInsitu: insitu.result.idInsitu,
                IdNutriente: nutriente.result.idNutriente,
                IdQuimico: quimico.result.idQuimico,
                IdFisico: fisico.result.idFisico,
                IdMetalAgua: metalAgua.result.idMetalAgua,
                IdBiologico: biologico.result.idBiologico
            };
    
            // Agregar el reporte al arreglo
            reportes.push(reporte);
        }
    
        // Guardar los reportes en la tabla REPORTES_LABORATORIO
        $.ajax({
            url: 'http://localhost:5078/api/ReportesLaboratorio/AgregarReporteLaboratorio',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(reportes),
            success: function(result) {
                console.log('Reportes laboratorio agregados exitosamente');
            },
            error: function(xhr) {
                console.error('Error al agregar reportes laboratorio: ', xhr.status);
            }
        });
    });
    // Función para obtener el ID de la estación por código
    function obtenerIdEstacion(codigo) {
        $.ajax({
            url: 'http://localhost:5078/api/estacion/ObtenerEstacionCodigo/' + codigo,
            type: 'GET',
            dataType: 'json'
        }).then(function(response) {
            return response.id;
        }).catch(function(xhr) {
            console.error('Error al obtener ID de estación: ', xhr.status);
            return null;
        });
    }
    // Llamar a la función para cargar campañas al cargar la página
    cargarcampañas();
    inicializarGrid();
});
