jQuery('#btnAddUser').on('click', function () {
    limpiarCamposUser();
});

$("#txtIDPersona").val($.urlParam('nro')); 

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
    $("#btnAceptarUser").removeClass("eliminar");
    $("#txtClave").attr("type", "password");
    $("#txtRepiteClave").attr("type", "password");
    $("#btnVerClave").addClass("oculto");
    $("#iconVerClave").addClass("bi-eye");
    $("#iconVerClave").removeClass("bi-eye-slash");
}