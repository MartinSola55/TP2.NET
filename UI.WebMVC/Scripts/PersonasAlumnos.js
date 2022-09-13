$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

$("#txtTipoUser").val("2");

listarInscripciones();

$.get("../Personas/getOne/?id=" + $.urlParam('nro'), function (data) {
    $("#txtNombre").val(data['Nombre']);
    $("#txtApellido").val(data['Apellido']);
    $("#txtDireccion").val(data['Direccion']);
    $("#txtEmail").val(data['Email']);
    $("#txtTelefono").val(data['Telefono']);
    $("#txtNacimiento").val(data['NacimientoString']);
    $("#txtLegajo").val(data['Legajo']);
    $("#txtPlan").val(data['DescPlan']);
    $("#txtUsuario").val(data['NombreUsuario']);
    if (data['NombreUsuario'] == null) {
        $("#btnAddUser").css("display", "");
    }
});

function listarInscripciones() {
    $.get("../Personas/GetInscripciones?id=" + $.urlParam('nro') + "&tipo=2", function (data) {
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
            tarjeta += "<button class='btn btn-outline-dark' onclick='modalEdit(" + data[i].ID + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop' >Ver</button>"
            tarjeta += "<button class='btn btn-danger' onclick='modalDelete(" + data[i].ID + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop' >Eliminar</button>"
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
    $("#txtIDAlumno").val($.urlParam('nro'));
    $("#comboCursos").val("");
    $("#txtID").prop("disabled", "disabled");
});

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar inscripción");
    limpiarCampos();
    habilitarCampos();
    $.get("../Personas/getInscripcion/?id=" + id + "&tipo=2", function (data) {
        $("#txtID").val(data["ID"]);
        $("#txtIDAlumno").val($.urlParam('nro'));
        $("#txtCondicion").val(data["Condicion"]);
        $("#txtNota").val(data["Nota"]);
        $("#comboCursos").val(data["IDCurso"]);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar inscripción");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Personas/GetInscripcion/?id=" + id + "&tipo=2", function (data) {
        $("#txtID").val(data["ID"]);
        $("#txtIDAlumno").val($.urlParam('nro'));
        $("#txtCondicion").val(data["Condicion"]);
        $("#txtNota").val(data["Nota"]);
        $("#comboCursos").val(data["IDCurso"]);
    });
    let frm = new FormData();
    frm.append("id", id);
}

function limpiarCampos() {
    $(".limpiarCampo").val("");
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $("#btnAceptar").removeClass("eliminar");
}

function habilitarCampos() {
    $(".habilitarCampo").removeAttr("disabled");
}

function deshabilitarCampos() {
    $(".deshabilitarCampo").attr("disabled", "disabled");
}

$('#btnAceptar').on('click', function (e) {
    e.preventDefault();
    if ($("#btnAceptar").hasClass("eliminar")) {
        if (confirm("¿Seguro que desea eliminar la inscripción?") == 1) {
            $("#formInscripcion").attr("action", "/Personas/DeleteInsAl");
            $("#formInscripcion").submit();
        }
    } else {
        $("#formInscripcion").attr("action", "/Personas/SaveInsAl");
        $("#formInscripcion").submit();
    }
});