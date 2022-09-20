listarCargos();

$.get("../Docente/getOne/?id=" + idPer, function (data) {
    $("#txtNombre").val(data['Nombre']);
    $("#txtApellido").val(data['Apellido']);
    $("#txtDireccion").val(data['Direccion']);
    $("#txtEmail").val(data['Email']);
    $("#txtTelefono").val(data['Telefono']);
    $("#txtNacimiento").val(data['NacimientoString']);
    $("#txtLegajo").val(data['Legajo']);
    $("#txtPlan").val(data['DescPlan']);
});

function listarCargos() {
    $.get("../Docente/GetInscripciones?id=" + idPer, function (data) {
        let contenedor = $('#tarjetasCargos');
        let tarjeta = "";
        for (let i = 0; i < data.length; i++) {
            tarjeta += "<div class='card me-4 col-3 mb-4' style='width: 18rem;'>";
            tarjeta += "<div class='card-body d-flex flex-column'>"
            tarjeta += "<h5 class='card-title'>Cargo: " + data[i].DescripcionCargo + "</h5>"
            tarjeta += "<p class='card-text'>" + data[i].DescripcionCurso + "</p>"
            tarjeta += "<div class='d-flex justify-content-end mt-auto'>"
            tarjeta += "<button class='btn btn-outline-dark' onclick='selectDictado(" + data[i]["IDCurso"] + ", " + data[i]["IDMateria"] + ", " + data[i]["IDComision"] +  ")'>Seleccionar</button>";
            tarjeta += "</div>"
            tarjeta += "</div>"
            tarjeta += "</div>"
            tarjeta += "<br/>"
            contenedor.html(tarjeta);
        }
    });
}

function selectDictado(curso, materia, comision) {
    window.location.href = "Docente/Notas?curso=" + curso + "&materia=" + materia + "&com=" + comision;
}