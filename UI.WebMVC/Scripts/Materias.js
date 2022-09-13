listar();
const header = ["Descripción", "Hs. Semanales", "Hs. Totales", "Plan - Especialidad"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

function listar() {
    $.get("../Materias/getAll", function (data) {
        listadoMaterias(header, data);
    });
}

function listadoMaterias(arrayHeader, data) {
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
        contenido += "<td>" + data[i].Descripcion + "</td>";
        contenido += "<td class='text-center'>" + data[i].HSSemanales + "</td>";
        contenido += "<td class='text-center'>" + data[i].HSTotales + "</td>";
        contenido += "<td class='text-center'>" + data[i].DescripcionPlan + "</td>";
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
    $("#tabla-materias").html(contenido);
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
                emptyTable: "No existen materias que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ materias",
                infoEmpty: "Mostrando 0 materias",
                lengthMenu: "Mostrar _MENU_ materias",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroDescripcion').on('input', filtraMaterias);

function filtraMaterias() {
    let descripcion = $("#filtroDescripcion").val();
    $.get("../Materias/FiltraMaterias/?descripcion=" + descripcion, function (data) {
        listadoMaterias(header, data);
    });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar materia");
    limpiarCampos();
    habilitarCampos();
    $.get("../Materias/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#txtHSS").val(data['HSSemanales']);
        $("#txtHST").val(data['HSTotales']);
        $("#comboPlanes").val(data['IDPlan']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar materia");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Materias/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtDescripcion").val(data['Descripcion']);
        $("#txtHSS").val(data['HSSemanales']);
        $("#txtHST").val(data['HSTotales']);
        $("#comboPlanes").val(data['IDPlan']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#comboPlanes").val("");
    $("#txtID").prop("disabled", "disabled");
    $("#staticBackdropLabel").text("Agregar materia");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

function limpiarCampos() {
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $(".limpiarCampo").val("");
    $("#comboPlanes").val(0);
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
        if (confirm("¿Seguro que desea eliminar la materia?") == 1) {
            $("#formMateria").attr("action", "/Materias/Delete");
            $("#formMateria").submit();
        }
    } else {
        $("#formMateria").attr("action", "/Materias/Save");
        $("#formMateria").submit();
    }
});