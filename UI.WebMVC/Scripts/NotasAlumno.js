$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}

const header = ["Alumno", "Condición", "Nota"];

listar();

function listar() {
    $.get("../Docente/GetAlumnosXCurso/?idCurso=" + $.urlParam('curso') + "&idMateria=" + $.urlParam('materia') + "&idComision=" + $.urlParam('com') , function (data) {
        $('#headerNota').html("Notas de " + data[0].DescripcionCurso);
        listadoAlumnos(header, data);
    });
}

function listadoAlumnos(arrayHeader, data) {
    let contenido = "";
    contenido += "<table id='tabla-generic' class='table table-dark table-striped table-bordered table-hover'>";
    contenido += "<thead>";
    contenido += "<tr>";
    for (let i = 0; i < arrayHeader.length; i++) {
        contenido += "<td class='text-center'>";
        contenido += arrayHeader[i];
        contenido += "</td>";
    }
    contenido += "<td class='no-sort text-center'>Editar</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    contenido += "<tbody>";
    for (let i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<td>" + data[i].NombreApellido + "</td>";
        contenido += "<td class='text-center'>" + data[i].Condicion + "</td>";
        let nota = data[i].Nota == null ? "-" : data[i].Nota;
        contenido += "<td class='text-center'>" + nota + "</td>";
        contenido += "<td class='d-flex justify-content-center'>";
        contenido += "<button class='btn btn-outline-success' onclick='modalEdit(" + data[i]["ID"] + ")' data-bs-toggle='modal' data-bs-target='#staticBackdrop'><i class='bi bi-pencil-square'></i></button>";
        contenido += "</td>";
        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    $("#tabla-notas").html(contenido);
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
                emptyTable: "No existen alumnos para esta cátedra",
                info: "Mostrando _START_ a _END_ de _TOTAL_ alumnos",
                infoEmpty: "Mostrando 0 alumnos",
                lengthMenu: "Mostrar _MENU_ alumnos",
            },
            columnDefs: [{
                orderable: false,
                targets: "no-sort"
            }]
        }
    )
    $("#tabla-generic").removeAttr("style");
}

function modalEdit(idIns) {
    $("#staticBackdropLabel").text("Editar condición");
    limpiarCampos();
    $.get("../Docente/GetInscripcionAlumno/?id=" + idIns, function (data) {
        $("#txtIDAlumno").val(data['IDAlumno']);
        $("#txtID").val(data['ID']);
        $("#txtAlumno").val(data['NombreApellido']);
        $("#txtCondicion").val(data['Condicion']);
        $("#txtNota").val(data['Nota']);
    });
}

function limpiarCampos() {
    $(".limpiarCampo").val("");
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        $("#campo" + i).removeClass("error");
    }
    $("#btnAceptar").removeClass("eliminar");
}

function validaDatos() {
    let valido = true;
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        if (campos[i].value == "") {
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
        let idAlumno = $("#txtIDAlumno").val();
        let nota = $("#txtNota").val();
        let condicion = $("#txtCondicion").val();
        frm.append("ID", id);
        frm.append("IDAlumno", idAlumno);
        frm.append("Nota", nota);
        frm.append("Condicion", condicion);
        actualizaCondicion(frm);
    }
}

function actualizaCondicion(frm) {
    $.ajax({
        type: "POST",
        url: "../Docente/SaveCondicion",
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