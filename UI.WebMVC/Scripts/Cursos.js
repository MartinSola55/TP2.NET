listar();
llenarComboMaterias();
llenarComboComisiones();
let header = ["Año", "Cupo", "Comisión", "Materia"];

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
    contenido += "<td class='no-sort text-center'>Acción</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (let i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<td class='text-center'>" + data[i].AnioCalendario + "</td>";
        contenido += "<td class='text-center'>" + data[i].Cupo + "</td>";
        contenido += "<td class='text-center'>" + data[i].ComisionDesc + "</td>";
        contenido += "<td>" + data[i].MateriaDesc + "</td>";
        contenido += "<td class='d-flex justify-content-center'>";
        contenido += "<button class='btn btn-outline-success me-4' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
        contenido += "<button class='btn btn-outline-danger ms-4' onclick='modalDelete(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-trash3'></i></button>";
        contenido += "</td>";
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

function llenarComboMaterias() {
    $.get("../Materias/getAll", function (data) {
        let control = $("#comboMaterias");
        let contenido = "";
        contenido += "<option value='0' disabled selected >--Seleccione una materia--</option>";
        for (let i = 0; i < data.length; i++) {
            contenido += "<option value='" + data[i].ID + "'>";
            contenido += data[i].Descripcion;
            contenido += " - ";
            contenido += data[i].DescripcionPlan;
            contenido += "</option>";
        }
        control.html(contenido);
    });
}

function llenarComboComisiones() {
    $.get("../Comisiones/getAll", function (data) {
        let control = $("#comboComisiones");
        let contenido = "";
        contenido += "<option value='0' disabled selected >--Seleccione una comisión--</option>";
        for (let i = 0; i < data.length; i++) {
            contenido += "<option value='" + data[i].ID + "'>";
            contenido += data[i].Descripcion;
            contenido += " - ";
            contenido += data[i].PlanDesc;
            contenido += "</option>";
        }
        control.html(contenido);
    });
}

$("#btnAgregar").click(function () {
    limpiarCampos();
    habilitarCampos();
    $("#staticBackdropLabel").text("Agregar curso");
    $("#comboMaterias").val("0");
    $("#comboComisiones").val("0");
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
        $(".campo" + i).removeClass("error");
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
        if (campos[i].value == "") {
            valido = false;
            $(".campo" + i).addClass("error");
        } else {
            $(".campo" + i).removeClass("error");
        }
    }
    return valido;
}

function confirmarCambios() {
    if (validaDatos()) {
        let frm = new FormData();
        let id = $("#txtID").val();
        let cupo = $("#txtCupo").val();
        let anio = $("#txtAnio").val();
        let materia = $("#comboMaterias").val();
        let comision = $("#comboComisiones").val();
        frm.append("ID", id);
        frm.append("Cupo", cupo);
        frm.append("AnioCalendario", anio);
        frm.append("IDMateria", materia);
        frm.append("IDComision", comision);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar el curso?") == 1) {
                crudCursos(frm, "Delete");
            }
        } else {
            crudCursos(frm, "Save");
        }
    }
}

function crudCursos(frm, action) {
    $.ajax({
        type: "POST",
        url: "../Cursos/" + action,
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