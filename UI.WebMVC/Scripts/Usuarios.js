listar();
let header = ["Nombre", "Apellido", "Email", "Usuario", "Habilitado"];

function listar() {
    $.get("../Usuarios/getAll", function (data) {
        listadoUsuarios(header, data);
    });
}

function listadoUsuarios(arrayHeader, data) {
    let contenido = "";
    contenido += "<table id='tabla-generic' class='table table-dark table-striped table-bordered table-hover'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (let i = 0; i < arrayHeader.length; i++) {
        contenido += "<td class='text-center'>";
        contenido += arrayHeader[i];
        contenido += "</td>";
    }
    contenido += "<td class='no-sort text-center'>Acción</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (let i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<td>" + data[i].Nombre + "</td>";
        contenido += "<td>" + data[i].Apellido + "</td>";
        contenido += "<td>" + data[i].Email + "</td>";
        contenido += "<td>" + data[i].NombreUsuario + "</td>";
        let habilitado = data[i].Habilitado == 1 ? "Sí" : "No";
        contenido += "<td class='text-center'>" + habilitado + "</td>";
        contenido += "<td class='d-flex justify-content-center'>";
        contenido += "<button class='btn btn-outline-success me-4' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
        contenido += "<button class='btn btn-outline-danger ms-4' onclick='modalDelete(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-trash3'></i></button>";
        contenido += "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    $("#tabla-usuarios").html(contenido);
    $('#tabla-generic').DataTable(
        {
            searching: false,
            "language": {
                paginate: {
                    "first": "Primero",
                    "last": "Último",
                    "next": "Siguiente",
                    "previous": "Anterior"
                },
                emptyTable: "No existen usuarios que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ usuarios",
                infoEmpty: "Mostrando 0 usuarios",
                lengthMenu: "Mostrar _MENU_ usuarios",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroNombre').on('input', filtraUsuario);
jQuery('#filtroApellido').on('input', filtraUsuario);
jQuery('#filtroUsuario').on('input', filtraUsuario);
jQuery('#filtroMail').on('input', filtraUsuario);

function filtraUsuario() {
    let nombre = $("#filtroNombre").val();
    let apellido = $("#filtroApellido").val();
    let usuario = $("#filtroUsuario").val();
    let mail = $("#filtroMail").val();
    $.get("../Usuarios/FiltraUsuarios/?nombre=" + nombre + "&apellido=" + apellido + "&usr="
        + usuario + "&mail=" + mail, function (data) {
            listadoUsuarios(header, data);
        });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar usuario");
    limpiarCampos();
    habilitarCampos();
    $.get("../Usuarios/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtNombre").val(data['Nombre']);
        $("#txtApellido").val(data['Apellido']);
        $("#txtEmail").val(data['Email']);
        $("#txtNombreUsuario").val(data['NombreUsuario']);
        $("#txtClave").val(data['Clave']);
        $("#checkHabilitado").prop('checked', data['Habilitado']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar usuario");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Usuarios/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtNombre").val(data['Nombre']);
        $("#txtApellido").val(data['Apellido']);
        $("#txtEmail").val(data['Email']);
        $("#txtNombreUsuario").val(data['NombreUsuario']);
        $("#txtClave").val(data['Clave']);
        $("#txtRepiteClave").val(data['Clave']);
        $("#checkHabilitado").prop('checked', data['Habilitado']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnVerClave").click(function () {
    if ($("#btnVerClave").hasClass("oculto")) {
        $("#txtClave").attr("type", "text");
        $("#txtRepiteClave").attr("type", "text");
        $("#btnVerClave").removeClass("oculto");
        $("#iconVerClave").removeClass("bi-eye");
        $("#iconVerClave").addClass("bi-eye-slash");
    } else {
        $("#txtClave").attr("type", "password");
        $("#txtRepiteClave").attr("type", "password");
        $("#btnVerClave").addClass("oculto");
        $("#iconVerClave").addClass("bi-eye");
        $("#iconVerClave").removeClass("bi-eye-slash");
    }
});


$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar usuario");
    $("#checkHabilitada").prop('checked', false);
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroNombre").val("");
    $("#filtroApellido").val("");
    $("#filtroUsuario").val("");
    $("#filtroMail").val("");
});

function limpiarCampos() {
    $(".limpiarCampo").val("");
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        $(".campo" + i).removeClass("error");
    }
    $("#btnAceptar").removeClass("eliminar");
    $("#txtClave").attr("type", "password");
    $("#txtRepiteClave").attr("type", "password");
    $("#btnVerClave").addClass("oculto");
    $("#iconVerClave").addClass("bi-eye");
    $("#iconVerClave").removeClass("bi-eye-slash");
}

function habilitarCampos() {
    $(".habilitarCampo").removeAttr("disabled");
    $("#txtClave").removeAttr("hidden");
    $("#lblClave").removeAttr("hidden");
    $("#txtRepiteClave").removeAttr("hidden");
    $("#lblRepiteClave").removeAttr("hidden");
    $("#btnVerClave").removeAttr("hidden");
}

function deshabilitarCampos() {
    $(".deshabilitarCampo").attr("disabled", "disabled");
    $("#txtClave").attr("hidden", "hidden");
    $("#lblClave").attr("hidden", "hidden");
    $("#txtRepiteClave").attr("hidden", "hidden");
    $("#lblRepiteClave").attr("hidden", "hidden");
    $("#btnVerClave").attr("hidden", "hidden");
}

function validaDatos() {
    let valido = true;
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        if (campos[i].value == "") {
            valido = false;
            $(".campo" + i).addClass("error");
        } else {
            $(".campo" + i).removeClass("error");
        }
    }
    if ($("#txtClave").val() != $("#txtRepiteClave").val() || $("#txtClave").val() == "" || $("#txtRepiteClave").val() == "") {
        valido = false;
        $("#lblClave").addClass("error");
        $("#lblRepiteClave").addClass("error");
    } else {
        $("#lblClave").removeClass("error");
        $("#lblRepiteClave").removeClass("error");
    }
    return valido;
}

function confirmarCambios() {
    if (validaDatos()) {
        let frm = new FormData();
        let id = $("#txtID").val();
        let nombre = $("#txtNombre").val();
        let apellido = $("#txtApellido").val();
        let email = $("#txtEmail").val();
        let usuario = $("#txtNombreUsuario").val();
        let clave = $("#txtClave").val();
        let check = $("#checkHabilitado").is(':checked');
        frm.append("ID", id);
        frm.append("Nombre", nombre);
        frm.append("Apellido", apellido);
        frm.append("Email", email);
        frm.append("NombreUsuario", usuario);
        frm.append("Clave", clave);
        frm.append("Habilitado", check);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar el usuario?") == 1) {
                crudUsuarios(frm, "Delete");
            }
        } else {
            crudUsuarios(frm, "Save");
        }
    }
}

function crudUsuarios(frm, action) {
    $.ajax({
        type: "POST",
        url: "../Usuarios/" + action,
        data: frm,
        contentType: false,
        processData: false,
        success: function (data) {
            listar();
            alert(data);
            $("#btnCancelar").click();
        }
    });
}