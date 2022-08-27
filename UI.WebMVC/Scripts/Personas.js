listar();
llenarComboPlanes();
moment.locale('es');
let header = ["Apellido", "Nombre", "Teléfono", "Nacimiento", "Legajo", "Tipo", "Plan"];
let maxDia = new Date();

$(function () {
    $('#txtNacimiento').daterangepicker({
        "autoApply": true,
        "locale": {
            "applyLabel": "Aplicar",
            "cancelLabel": "Cancelar",
            "fromLabel": "Hasta",
            "toLabel": "Desde",
        },
        "showDropdowns": true,
        "minYear": 1900,
        singleDatePicker: true,
        maxDate: maxDia,
        opens: 'right',
    })
});

function listar() {
    $.get("../Personas/getAll", function (data) {
        listadoPersonas(header, data);
    });
}

function listadoPersonas(arrayHeader, data) {
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
        contenido += "<td>" + data[i].Apellido + "</td>";
        contenido += "<td>" + data[i].Nombre + "</td>";
        contenido += "<td>" + data[i].Telefono + "</td>";
        contenido += "<td class='text-center'>" + data[i].NacimientoString + "</td>";
        contenido += "<td class='text-center'>" + data[i].Legajo + "</td>";
        let tipo = "-";
        if (data[i].TipoPersona == "1") {
            tipo = "Docente";
        } else if (data[i].TipoPersona == "2") {
            tipo = "Alumno";
        } else if (data[i].TipoPersona == "3") {
            tipo = "Administrador";
        }
        contenido += "<td class='text-center'>" + tipo + "</td>";
        contenido += "<td class='text-center'>" + data[i].DescPlan + "</td>";
        contenido += "<td class='d-flex justify-content-center'>";
        contenido += "<button class='btn btn-outline-success me-2 py-1' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
        contenido += "<button class='btn btn-outline-danger mx-2' onclick='modalDelete(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-trash3'></i></button>";
        contenido += "<button class='btn btn-outline-light ms-2' onclick='selectPersona(" + data[i]["ID"] + ", " + data[i].TipoPersona + ")'>Seleccionar</button>";
        contenido += "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    $("#tabla-personas").html(contenido);
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
                emptyTable: "No existen personas que coincidan con la búsqueda",
                info: "Mostrando _START_ a _END_ de _TOTAL_ personas",
                infoEmpty: "Mostrando 0 personas",
                lengthMenu: "Mostrar _MENU_ personas",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

jQuery('#filtroNombre').on('input', filtraPersonas);
jQuery('#filtroApellido').on('input', filtraPersonas);
jQuery('#filtroLegajo').on('input', filtraPersonas);

function filtraPersonas() {
    let nombre = $("#filtroNombre").val();
    let apellido = $("#filtroApellido").val();
    let legajo = $("#filtroLegajo").val();
    $.get("../Personas/FiltraPersonas/?nombre=" + nombre + "&apellido=" + apellido + "&legajo=" + legajo, function (data) {
        listadoPersonas(header, data);
    });
}

function modalEdit(id) {
    $("#staticBackdropLabel").text("Editar persona");
    limpiarCampos();
    habilitarCampos();
    $.get("../Personas/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtNombre").val(data['Nombre']);
        $("#txtApellido").val(data['Apellido']);
        $("#txtDireccion").val(data['Direccion']);
        $("#txtEmail").val(data['Email']);
        $("#txtTelefono").val(data['Telefono']);
        $("#txtNacimiento").val(data['NacimientoString']);
        $("#txtLegajo").val(data['Legajo']);
        $("#comboTipo").val(data['TipoPersona']);
        $("#comboPlanes").val(data['IDPlan']);
    });
}

function modalDelete(id) {
    $("#staticBackdropLabel").text("Eliminar persona");
    limpiarCampos();
    deshabilitarCampos();
    $("#btnAceptar").addClass("eliminar");
    $.get("../Personas/getOne/?id=" + id, function (data) {
        $("#txtID").val(data['ID']);
        $("#txtNombre").val(data['Nombre']);
        $("#txtApellido").val(data['Apellido']);
        $("#txtDireccion").val(data['Direccion']);
        $("#txtEmail").val(data['Email']);
        $("#txtTelefono").val(data['Telefono']);
        $("#txtNacimiento").val(data['NacimientoString']);
        $("#txtLegajo").val(data['Legajo']);
        $("#comboTipo").val(data['TipoPersona']);
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
    $("#staticBackdropLabel").text("Agregar persona");
});

jQuery('#limpia-filtro').on('click', function () {
    listar();
    $("#filtroNombre").val("");
    $("#filtroApellido").val("");
    $("#filtroLegajo").val("");
});

function limpiarCampos() {
    $(".limpiarCampo").val("");
    $("#comboTipo").val(0);
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
        let nombre = $("#txtNombre").val();
        let apellido = $("#txtApellido").val();
        let direccion = $("#txtDireccion").val();
        let email = $("#txtEmail").val();
        let tel = $("#txtTelefono").val();
        let nacimiento = $("#txtNacimiento").val();
        let legajo = $("#txtLegajo").val();
        let tipo_per = $("#comboTipo").val();
        let plan = $("#comboPlanes").val();
        frm.append("ID", id);
        frm.append("Nombre", nombre);
        frm.append("Apellido", apellido);
        frm.append("Direccion", direccion);
        frm.append("Email", email);
        frm.append("Telefono", tel);
        frm.append("FechaNacimiento", nacimiento);
        frm.append("Legajo", legajo);
        frm.append("TipoPersona", tipo_per);
        frm.append("IDPlan", plan);
        if ($("#btnAceptar").hasClass("eliminar")) {
            if (confirm("¿Seguro que desea eliminar la persona?") == 1) {
                crudPersonas(frm, "Delete");
            }
        } else {
            crudPersonas(frm, "Save");
        }
    }
}

function crudPersonas(frm, action) {
    $.ajax({
        type: "POST",
        url: "../Personas/" + action,
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

function selectPersona(id, tipo) {
    if (tipo == 1) {
        window.location.href = "Personas/InscripcionesDocente?id=" + id;
    } else if (tipo == 2) {
        window.location.href = "Personas/InscripcionesAlumno?id=" + id;
    }
}