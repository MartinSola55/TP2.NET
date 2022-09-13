const inputs = $("#formLogin input[type!=submit]").toArray();

if ($("#txtNotification").html() !== "") {
    $("#NotifContainer").show();
}

setTimeout(function () {
    $('#NotifContainer').fadeOut(1500)
}, 4000)

$("#txtUser").on("input", function () {
    setTimeout(function () {
        muestraError();
    }, 100)
});
$("#txtPass").on("input", function () {
    setTimeout(function () {
        muestraError();
    }, 100)
});

function muestraError() {
    if ($("#lblUser").hasClass("field-validation-valid")) {
        $('#containerUser').removeClass("formContainer-incorrecto");
    } else {
        $('#containerUser').addClass("formContainer-incorrecto");
    }
    if ($("#lblPass").hasClass("field-validation-valid")) {
        $('#containerPass').removeClass("formContainer-incorrecto");
    } else {
        $('#containerPass').addClass("formContainer-incorrecto");
    }
}

$("#btnIngresar").on("click", function () {
    if ($('#txtUser').val() === "" || $('#txtPass').val() === "") {
        $("#errorMessage").show();
        setTimeout(function () {
            $("#errorMessage").fadeOut(1500)
        }, 4000);
    } else {
        $("#errorMessage").fadeOut(1500);
    }
    if ($("#txtUser").hasClass("valid")) {
        $('#containerUser').removeClass("formContainer-incorrecto");
    } else {
        $('#containerUser').addClass("formContainer-incorrecto");
    }
    if ($("#txtPass").hasClass("valid")) {
        $('#containerPass').removeClass("formContainer-incorrecto");
    } else {
        $('#containerPass').addClass("formContainer-incorrecto");
    }
})