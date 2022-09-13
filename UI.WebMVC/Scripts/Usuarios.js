listar();
const header = ["Usuario", "Email", "Habilitado"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

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
        contenido += "<td>" + data[i].NombreUsuario + "</td>";
        contenido += "<td>" + data[i].Email + "</td>";
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

jQuery('#filtroUsuario').on('input', filtraUsuario);
jQuery('#filtroMail').on('input', filtraUsuario);

function filtraUsuario() {
    let usuario = $("#filtroUsuario").val();
    let mail = $("#filtroMail").val();
    $.get("../Usuarios/FiltraUsuarios/?usr=" + usuario + "&mail=" + mail, function (data) {
        listadoUsuarios(header, data);
    });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar usuario");
    limpiarCampos();
    habilitarCampos();
    $.get("../Usuarios/getOne/?id=" + id, function (data) {
        $("#txtID").val(data[0]['ID']);
        $("#txtNombreUsuario").val(data[0]['NombreUsuario']);
        $("#txtClave").val(data[0]['Clave']);
        $("#checkHabilitado").prop('checked', data[0]['Habilitado']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar usuario");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Usuarios/getOne/?id=" + id, function (data) {
        $("#txtID").val(data[0]['ID']);
        $("#txtNombreUsuario").val(data[0]['NombreUsuario']);
        $("#txtClave").val(data[0]['Clave']);
        $("#txtRepiteClave").val(data[0]['Clave']);
        $("#checkHabilitado").prop('checked', data[0]['Habilitado']);
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

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroUsuario").val("");
    $("#filtroMail").val("");
});

function limpiarCampos() {
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $(".limpiarCampo").val("");
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

$('#btnAceptar').on('click', function (e) {
    e.preventDefault();
    if ($("#btnAceptar").hasClass("eliminar")) {
        if (confirm("¿Seguro que desea eliminar el usuario?") == 1) {
            $("#formUsuario").attr("action", "/Usuarios/Delete");
            $("#formUsuario").submit();
        }
    } else {
        $("#formUsuario").attr("action", "/Usuarios/Save");
        $("#formUsuario").submit();
    }
});