listar();
llenarComboEsp();
let header = ["Descripción", "Especialidad"];

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
    contenido += "<td class='no-sort text-center'>Acción</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (let i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<td class='text-center'>" + data[i].Descripcion + "</td>";
        contenido += "<td class='text-center'>" + data[i].DescripcionEsp + "</td>";
        contenido += "<td class='d-flex justify-content-center'>";
        contenido += "<button class='btn btn-outline-success me-4' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
        contenido += "<button class='btn btn-outline-danger ms-4' onclick='modalDelete(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-trash3'></i></button>";
        contenido += "</td>";
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

function llenarComboEsp() {
    $.get("../Especialidades/getAll", function (data) {
        let control = $("#comboEsp");
        let contenido = "";
        contenido += "<option value='0' disabled selected >--Seleccione una especialidad--</option>";
        for (let i = 0; i < data.length; i++) {
            contenido += "<option value='" + data[i].ID + "'>";
            contenido += data[i].Descripcion;
            contenido += "</option>";
        }
        control.html(contenido);
    });
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar plan");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroDescripcion").val("");
});

function limpiarCampos() {
    $(".limpiarCampo").val("");
    $("#comboEsp").val(0);
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
        let esp = $("#comboEsp").val();
        frm.append("ID", id);
        frm.append("Descripcion", descripcion);
        frm.append("IDEspecialidad", esp);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar el plan?") == 1) {
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
        url: "../Planes/" + action,
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