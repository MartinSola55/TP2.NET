listarCursos();
listarInscripciones();

$.get("../InscripcionesAlumno/getOne/?id=" + idPer, function (data) {
    $("#txtNombre").val(data['Nombre']);
    $("#txtApellido").val(data['Apellido']);
    $("#txtDireccion").val(data['Direccion']);
    $("#txtEmail").val(data['Email']);
    $("#txtTelefono").val(data['Telefono']);
    $("#txtNacimiento").val(data['NacimientoString']);
    $("#txtLegajo").val(data['Legajo']);
    $("#txtPlan").val(data['DescPlan']);
});

function listarCursos() {
    $.get("../Cursos/getAll", function (data) {
        let control = $("#comboCursos");
        let contenido = "";
        contenido += "<option value='0' disabled selected >--Seleccione una curso--</option>";
        for (let i = 0; i < data.length; i++) {
            contenido += "<option value='" + data[i].ID + "'>";
            contenido += data[i].AnioCalendario;
            contenido += " - ";
            contenido += data[i].ComisionDesc;
            contenido += " - ";
            contenido += data[i].MateriaDesc;
            contenido += "</option>";
        }
        control.html(contenido);
    });
}

function listarInscripciones() {
    $.get("../InscripcionesAlumno/GetInscripciones?id=" + idPer, function (data) {
        let contenedor = $('#tarjetasInscripciones');
        let tarjeta = "";
        for (let i = 0; i < data.length; i++) {
            tarjeta += "<div class='card me-4 col-3 mb-4' style='width: 18rem;'>";
            tarjeta += "<div class='card-body d-flex flex-column'>"
            tarjeta += "<h5 class='card-title'>Condición: " + data[i].Condicion + "</h5>"
            let nota = data[i].Nota == null ? "" : data[i].Nota;
            if (nota != "") {
                tarjeta += "<h5 class='card-title'>Nota: " + nota + "</h5>"
            }            tarjeta += "<h5 class='card-title'>Nota: " + nota + "</h5>"
            tarjeta += "<p class='card-text'>" + data[i].DescripcionCurso + "</p>"
            tarjeta += "<div class='d-flex justify-content-between mt-auto'>"
            tarjeta += "<button class='btn btn-outline-dark' onclick='modalVer(" + data[i].ID + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop' >Ver</button>"
            tarjeta += "</div>"
            tarjeta += "</div>"
            tarjeta += "</div>"
            tarjeta += "<br/>"
            contenedor.html(tarjeta);
        }
    });
}

jQuery('#btnAgregar').on('click', function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar inscripción");
    $("#txtIDAlumno").val(idPer);
    $("#comboCursos").val("0");
    $("#lblCondicion").css("display", "none");
    $("#txtCondicion").css("display", "none");
    $("#lblNota").css("display", "none");
    $("#txtNota").css("display", "none");
    $("#btnAceptar").css("display", "");
    $("#btnCancelar").html("Cancelar");
});

function modalVer(id) {
    $("#staticBackdropLabel").text("Ver inscripción");
    limpiarCampos();
    deshabilitarCampos();
    $("#lblCondicion").css("display", "");
    $("#txtCondicion").css("display", "");
    $("#lblNota").css("display", "");
    $("#txtNota").css("display", "");
    $("#btnAceptar").css("display", "none");
    $.get("../InscripcionesAlumno/getInscripcion/?id=" + id, function (data) {
        $("#txtID").val(data["ID"]);
        $("#txtIDAlumno").val(idPer);
        $("#txtCondicion").val(data["Condicion"]);
        $("#txtNota").val(data["Nota"]);
        $("#comboCursos").val(data["IDCurso"]);
        $("#btnCancelar").html("Salir");
    });
}

function limpiarCampos() {
    $(".limpiarCampo").val("");
    $("#lblCurso").removeClass("error");
}

function habilitarCampos() {
    $(".habilitarCampo").removeAttr("disabled");
}

function deshabilitarCampos() {
    $(".deshabilitarCampo").attr("disabled", "disabled");
}

function campoRequired() {
    let valido = true;
    if ($("#comboCursos").val() == null) {
        valido = false;
        $("#lblCurso").addClass("error");
    } else {
        $("#lblCurso").removeClass("error");
    }
    return valido;
}

function confirmarCambios() {
    if (campoRequired()) {
        let idAlumno = $("#txtIDAlumno").val();
        let idCurso = $("#comboCursos").val();
        saveInscripcion(idAlumno, idCurso);
    }
}

function saveInscripcion(idAlumno, idCurso) {
    $.ajax({
        type: "POST",
        url: "../InscripcionesAlumno/Save?idAlumno=" + idAlumno + "&idCurso=" + idCurso,
        contentType: false,
        processData: false,
        success: function (data) {
            alert(data[0]);
            if (data[1] == "1") {
                listarInscripciones();
                $("#btnCancelar").click();
            }
        }
    });
}