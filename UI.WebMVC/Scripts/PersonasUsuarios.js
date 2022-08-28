jQuery('#btnAddUser').on('click', function () {
    limpiarCamposUser();
});

$("#btnVerClave").click(function () {
    if ($("#btnVerClave").hasClass("oculto")) {
        $("#txtClave").attr("type", "text");
        $("#txtRepiteClave").attr("type", "text");
        $("#btnVerClave").removeClass("oculto");
        $("#iconVerClave").removeClass("bi-eye");
        $("#iconVerClave").addClass("bi-eye-slash");
    } else {
        $("#txtClave").attr("type", "password");
        $("#txtRepiteClave").attr("type", "password");
        $("#btnVerClave").addClass("oculto");
        $("#iconVerClave").addClass("bi-eye");
        $("#iconVerClave").removeClass("bi-eye-slash");
    }
});

function limpiarCamposUser() {
    $("#txtNombreUsuario").val("");
    $("#checkHabilitado").prop('checked', 0);
    $("#txtClave").val("");
    $("#txtRepiteClave").val("");
    campos = $(".required");
    for (let i = 0; i < campos.length; i++) {
        $(".campo" + i).removeClass("error");
    }
    $("#btnAceptarUser").removeClass("eliminar");
    $("#txtClave").attr("type", "password");
    $("#txtRepiteClave").attr("type", "password");
    $("#btnVerClave").addClass("oculto");
    $("#iconVerClave").addClass("bi-eye");
    $("#iconVerClave").removeClass("bi-eye-slash");
}

function validaDatosUser() {
    let valido = true;
    if ($("#txtNombreUsuario").val() == "") {
        $("#lblUsuario").addClass("error");
    } else {
        $("#lblUsuario").removeClass("error");
    }
    if ($("#txtClave").val() != $("#txtRepiteClave").val() || $("#txtClave").val() == "" || $("#txtRepiteClave").val() == "") {
        valido = false;
        $("#lblClave").addClass("error");
        $("#lblRepiteClave").addClass("error");
    } else {
        $("#lblClave").removeClass("error");
        $("#lblRepiteClave").removeClass("error");
    }
    return valido;
}

function confirmarCambiosUser() {
    if (validaDatosUser()) {
        let frm = new FormData();
        let id = $("#txtID").val();
        let usuario = $("#txtNombreUsuario").val();
        let idAlumno = $.urlParam('id');
        let clave = $("#txtClave").val();
        let check = $("#checkHabilitado").is(':checked');
        frm.append("ID", id);
        frm.append("IDPersona", idAlumno);
        frm.append("NombreUsuario", usuario);
        frm.append("Clave", clave);
        frm.append("Habilitado", check);
        saveUsuario(frm);
    }
}

function saveUsuario(frm) {
    $.ajax({
        type: "POST",
        url: "../Personas/SaveUser",
        data: frm,
        contentType: false,
        processData: false,
        success: function (data) {
            alert(data[0]);
            if (data[1] == "1") {
                location.reload();
            }
        }
    });
}