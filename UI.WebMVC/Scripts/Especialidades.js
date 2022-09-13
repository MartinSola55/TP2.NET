listar();
const header = ["Descripción"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

function listar() {
    $.get("../Especialidades/getAll", function (data) {
        listadoEspecialidades(header, data);
    });
}

function listadoEspecialidades(arrayHeader, data) {
    let contenido = "";
    contenido += "<table id='tabla-generic' class='table table-dark table-striped table-bordered table-hover'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (let i = 0; i < arrayHeader.length; i++) {
        contenido += "<td class='text-center'>";
        contenido += arrayHeader[i];
        contenido += "</td>";
    }
    contenido += tipoUsr == "3" ? "<td class='no-sort text-center'>Acción</td>" : "";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (let i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<td class='text-center'>" + data[i].Descripcion + "</td>";
        if (tipoUsr == "3") {
            contenido += "<td class='d-flex justify-content-center'>";
            contenido += "<button class='btn btn-outline-success me-4' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
            contenido += "<button class='btn btn-outline-danger ms-4' onclick='modalDelete(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-trash3'></i></button>";
            contenido += "</td>";
        }
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    $("#tabla-especialidades").html(contenido);
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
                emptyTable: "No existen especialidades que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ especialidades",
                infoEmpty: "Mostrando 0 especialidades",
                lengthMenu: "Mostrar _MENU_ especialidades",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroDescripcion').on('input', filtraEspecialidades);

function filtraEspecialidades() {
    let descripcion = $("#filtroDescripcion").val();
    $.get("../Especialidades/FiltraEspecialidades/?descripcion=" + descripcion, function (data) {
        listadoEspecialidades(header, data);
        });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar especialidad");
    limpiarCampos();
    habilitarCampos();
    $.get("../Especialidades/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar especialidad");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Especialidades/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#txtID").prop("disabled", "disabled");
    $("#staticBackdropLabel").text("Agregar especialidad");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

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
        if (confirm("¿Seguro que desea eliminar la especialidad?") == 1) {
            $("#formEspecialidad").attr("action", "/Especialidades/Delete");
            $("#formEspecialidad").submit();
        }
    } else {
        $("#formEspecialidad").attr("action", "/Especialidades/Save");
        $("#formEspecialidad").submit();
    }
});