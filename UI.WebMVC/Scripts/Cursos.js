listar();
const header = ["Año", "Cupo", "Comisión", "Materia"];

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

function listar() {
    $.get("../Cursos/getAll", function (data) {
        listadoCursos(header, data);
    });
}

function listadoCursos(arrayHeader, data) {
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
        contenido += "<td class='text-center'>" + data[i].AnioCalendario + "</td>";
        contenido += "<td class='text-center'>" + data[i].Cupo + "</td>";
        contenido += "<td class='text-center'>" + data[i].ComisionDesc + "</td>";
        contenido += "<td>" + data[i].MateriaDesc + "</td>";
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
    $("#tabla-cursos").html(contenido);
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
                emptyTable: "No existen cursos que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ cursos",
                infoEmpty: "Mostrando 0 cursos",
                lengthMenu: "Mostrar _MENU_ cursos",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar curso");
    limpiarCampos();
    habilitarCampos();
    $.get("../Cursos/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtAnio").val(data['AnioCalendario']);
        $("#txtCupo").val(data['Cupo']);
        $("#comboMaterias").val(data['IDMateria']);
        $("#comboComisiones").val(data['IDComision']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar curso");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Cursos/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtAnio").val(data['AnioCalendario']);
        $("#txtCupo").val(data['Cupo']);
        $("#comboMaterias").val(data['IDMateria']);
        $("#comboComisiones").val(data['IDComision']);
    });
    let frm = new FormData();
    frm.append("id", id);
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar curso");
    $("#comboMaterias").val("");
    $("#comboComisiones").val("");
    $("#txtID").prop("disabled", "disabled");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

function limpiarCampos() {
    $("#txtID").prop("disabled", "");
    $("#txtID").prop("readonly", "readonly");
    $(".limpiarCampo").val("");
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
        if (confirm("¿Seguro que desea eliminar el curso?") == 1) {
            $("#formCurso").attr("action", "/Cursos/Delete");
            $("#formCurso").submit();
        }
    } else {
        $("#formCurso").attr("action", "/Cursos/Save");
        $("#formCurso").submit();
    }
});