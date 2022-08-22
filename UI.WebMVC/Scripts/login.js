$('#btnIngresar').on('click', function () {
    if (campoRequired()) {
        let user = $("#txtUser").val();
        let pass = $("#txtPass").val();
        $.get("../Login/Validar/?user=" + user + "&pass=" + pass, function (data) {
            if (data == 'True') {
                document.location.href = "../Home";
            } else {
                alert("Usuario y/o contraseña incorrectos");
            }
        });
    }
});

const inputs = $("#formLogin input[type!=button]").toArray();

const expresiones = {
    usuario: /^[a-zA-Z0-9\_\-]{1,16}$/, // Letras, numeros, guion y guion_bajo
    password: /^.{1,20}$/, // 4 a 20 digitos.
}

const campos = {
    user: false,
    pass: false,
}

const validaLogin = (e) => {
    switch (e.target.id) {
        case "txtUser": {
            if (validaCampos(expresiones.usuario, e.target, 'User')) {
                campos['user'] = true;
            } else {
                campos['user'] = false;
            };
            break;
        }
        case "txtPass": {
            if (validaCampos(expresiones.password, e.target, 'Pass')) {
                campos['pass'] = true;
            } else {
                campos['pass'] = false;
            };
            break;
        }

    }
}

let validaCampos = (expresion, input, campo) => {
    if (input.value === "") {
        $(`#container${campo}`).removeClass("formContainer-incorrecto");
        $(`#container${campo} .informaError`).css("display", "none");
        return false;
    }
    if (expresion.test(input.value)) {
        $(`#container${campo}`).removeClass("formContainer-incorrecto");
        $(`#container${campo} i`).removeClass("bi-x-circle-fill");
        $(`#container${campo} .informaError`).css("display", "none");
        return true;
    } else {
        $(`#container${campo}`).addClass("formContainer-incorrecto");
        $(`#container${campo} i`).addClass("bi-x-circle-fill");
        $(`#container${campo} .informaError`).css("display", "block");
    }
    return false;
};

inputs.forEach((input) => {
    input.addEventListener('keyup', validaLogin);
    input.addEventListener('change', validaLogin);
});

function campoRequired() {
    if (campos.user && campos.pass) {
        $("#errorMessage").removeClass("errorMessage-activo");
        return true;
    }
    $("#errorMessage").addClass("errorMessage-activo");
    return false;
}