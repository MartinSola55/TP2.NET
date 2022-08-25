$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}

listarCursos();
listarInscripciones();

$.get("../Personas/getOne/?id=" + $.urlParam('id'), function (data) {
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
    $.get("../Personas/GetInscripciones?id=" + $.urlParam('id') + "&tipo=1", function (data) {
        let contenedor = $('#tarjetasInscripciones');
        let tarjeta = "";
        for (let i = 0; i < data.length; i++) {
            console.log(data);
            tarjeta += "<div class='card me-4 col-3 mb-4' style='width: 18rem;'>";
            tarjeta += "<div class='card-body d-flex flex-column'>"
            tarjeta += "<h5 class='card-title'>Cargo: " + data[i].Cargo + "</h5>"
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
    $("#txtIDDocente").val($.urlParam('id'));
    $("#comboCursos").val("0");
});

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar inscripción");
    limpiarCampos();
    habilitarCampos();
    $.get("../Personas/getInscripcion/?id=" + id + "&tipo=1", function (data) {
        console.log(data);
        $("#txtID").val(data["ID"]);
        $("#txtIDDocente").val($.urlParam('id'));
        $("#txtCargo").val(data["Cargo"]);
        $("#comboCursos").val(data["IDCurso"]);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar inscripción");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Personas/GetInscripcion/?id=" + id + "&tipo=1", function (data) {
        $("#txtID").val(data["ID"]);
        $("#txtIDDocente").val($.urlParam('id'));
        $("#txtCargo").val(data["Cargo"]);
        $("#comboCursos").val(data["IDCurso"]);
    });
    let frm = new FormData();
    frm.append("id", id);
}

function limpiarCampos() {
    $(".limpiarCampo").val("");
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        $("#campo" + i).removeClass("error");
    }
    $("#btnAceptar").removeClass("eliminar");
}

function habilitarCampos() {
    $(".habilitarCampo").removeAttr("disabled");
}

function deshabilitarCampos() {
    $(".deshabilitarCampo").attr("disabled", "disabled");
}

function campoRequired() {
    let valido = true;
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        if (campos[i].value == "" || campos[i].value == "0") {
            valido = false;
            $("#campo" + i).addClass("error");
        } else {
            $("#campo" + i).removeClass("error");
        }
    }
    return valido;
}

function confirmarCambios() {
    if (campoRequired()) {
        let frm = new FormData();
        let id = $("#txtID").val();
        let idDocente = $("#txtIDDocente").val();
        let curso = $("#comboCursos").val();
        let cargo = $("#txtCargo").val();
        frm.append("ID", id);
        frm.append("IDDocente", idDocente);
        frm.append("IDCurso", curso);
        frm.append("Cargo", cargo);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar la inscripción?") == 1) {
                crudInscripcion(frm, "DeleteInsDoc");
            }
        } else {
            crudInscripcion(frm, "SaveInsDoc");
        }
    }
}

function crudInscripcion(frm, action) {
    $.ajax({
        type: "POST",
        url: "../Personas/" + action,
        data: frm,
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