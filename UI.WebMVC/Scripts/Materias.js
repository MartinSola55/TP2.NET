listar();
llenarComboPlanes();
let header = ["Descripción", "Hs. Semanales", "Hs. Totales", "Plan - Especialidad"];

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

function llenarComboPlanes() {
    $.get("../Planes/getAll", function (data) {
        let control = $("#comboPlanes");
        let contenido = "";
        contenido += "<option value='0' disabled selected >--Seleccione un plan--</option>";
        for (let i = 0; i < data.length; i++) {
            contenido += "<option value='" + data[i].ID + "'>";
            contenido += data[i].Descripcion;
            contenido += " - ";
            contenido += data[i].DescripcionEsp;
            contenido += "</option>";
        }
        control.html(contenido);
    });
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar materia");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

function limpiarCampos() {
    $(".limpiarCampo").val("");
    $("#comboPlanes").val(0);
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

function validaDatos() {
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
    if (validaDatos()) {
        let frm = new FormData();
        let id = $("#txtID").val();
        let descripcion = $("#txtDescripcion").val();
        let hss = $("#txtHSS").val();
        let hst = $("#txtHST").val();
        let plan = $("#comboPlanes").val();
        frm.append("ID", id);
        frm.append("Descripcion", descripcion);
        frm.append("HSSemanales", hss);
        frm.append("HSTotales", hst);
        frm.append("IDPlan", plan);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar la materia?") == 1) {
                crudPlanes(frm, "Delete");
            }
        } else {
            crudPlanes(frm, "Save");
        }
    }
}

function crudPlanes(frm, action) {
    $.ajax({
        type: "POST",
        url: "../Materias/" + action,
        data: frm,
        contentType: false,
        processData: false,
        success: function (data) {
            alert(data[0]);
            if (data[1] == "1") {
                listar();
                $("#btnCancelar").click();
            }
        }
    });
}