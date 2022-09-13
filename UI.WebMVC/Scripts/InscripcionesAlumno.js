listarInscripciones();

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

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
            }
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
    $("#txtID").prop("disabled", "disabled");
    $("#staticBackdropLabel").text("Agregar inscripción");
    $("#txtIDAlumno").val(idPer);
    $("#comboCursos").val("");
    $("#lblCondicion").css("display", "none");
    $("#txtCondicion").css("display", "none");
    $("#lblNota").css("display", "none");
    $("#txtNota").css("display", "none");
    $(".hide").css("display", "none");
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
    $(".hide").css("display", "");
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
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $("#lblCurso").removeClass("error");
}

function habilitarCampos() {
    $(".habilitarCampo").removeAttr("disabled");
}

function deshabilitarCampos() {
    $(".deshabilitarCampo").attr("disabled", "disabled");
}

$('#btnAceptar').on('click', function (e) {
    e.preventDefault();
    $("#formInscripcion").attr("action", "/InscripcionesAlumno/Save");
    $("#formInscripcion").submit();
});