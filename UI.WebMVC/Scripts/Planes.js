listar();
const header = ["Descripción", "Especialidad"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

function listar() {
    $.get("../Planes/getAll", function (data) {
        listadoPlanes(header, data);
    });
}

function listadoPlanes(arrayHeader, data) {
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
        contenido += "<td class='text-center'>" + data[i].DescripcionEsp + "</td>";
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
    $("#tabla-planes").html(contenido);
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
                emptyTable: "No existen planes que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ planes",
                infoEmpty: "Mostrando 0 planes",
                lengthMenu: "Mostrar _MENU_ planes",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroDescripcion').on('input', filtraPlanes);

function filtraPlanes() {
    let descripcion = $("#filtroDescripcion").val();
    $.get("../Planes/FiltraPlanes/?descripcion=" + descripcion, function (data) {
        listadoPlanes(header, data);
    });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar plan");
    limpiarCampos();
    habilitarCampos();
    $.get("../Planes/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#comboEsp").val(data['IDEspecialidad']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar plan");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Planes/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#comboEsp").val(data['IDEspecialidad']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar plan");
    $("#txtID").prop("disabled", "disabled");
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
        if (confirm("¿Seguro que desea eliminar el plan?") == 1) {
            $("#formPlan").attr("action", "/Planes/Delete");
            $("#formPlan").submit();
        }
    } else {
        $("#formPlan").attr("action", "/Planes/Save");
        $("#formPlan").submit();
    }
});