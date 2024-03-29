﻿listar();
const header = ["Descripción", "Año especialidad", "Plan - Especialidad"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

function listar() {
    $.get("../Comisiones/getAll", function (data) {
        listadoComisiones(header, data);
    });
}

function listadoComisiones(arrayHeader, data) {
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
        contenido += "<td class='text-center'>" + data[i].AnioEspecialidad + "</td>";
        contenido += "<td class='text-center'>" + data[i].PlanDesc + "</td>";
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
    $("#tabla-comisiones").html(contenido);
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
                emptyTable: "No existen comisiones que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ comisiones",
                infoEmpty: "Mostrando 0 comisiones",
                lengthMenu: "Mostrar _MENU_ comisiones",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroDescripcion').on('input', filtraComisiones);

function filtraComisiones() {
    let descripcion = $("#filtroDescripcion").val();
    $.get("../Comisiones/FiltraComisiones/?descripcion=" + descripcion, function (data) {
        listadoComisiones(header, data);
    });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar comisión");
    limpiarCampos();
    habilitarCampos();
    $.get("../Comisiones/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#txtAnio").val(data['AnioEspecialidad']);
        $("#comboPlanes").val(data['IDPlan']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar comisión");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Comisiones/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#txtAnio").val(data['AnioEspecialidad']);
        $("#comboPlanes").val(data['IDPlan']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#txtID").prop("disabled", "disabled");
    $("#staticBackdropLabel").text("Agregar comisión");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

function limpiarCampos() {
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $(".limpiarCampo").val("");
    $("#comboPlanes").val("");
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
        if (confirm("¿Seguro que desea eliminar la comisión?") == 1) {
            $("#formComision").attr("action", "/Comisiones/Delete");
            $("#formComision").submit();
        }
    } else {
        $("#formComision").attr("action", "/Comisiones/Save");
        $("#formComision").submit();
    }
});