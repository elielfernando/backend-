window.onload = function (e) {

    var btnEntrar = document.getElementById("btnEntrar");
    var txtEmail = document.getElementById("txtEmail");
    var txtSenha = document.getElementById("txtSenha");
    var btnOlho = document.getElementById("btnOlho");
    var txtSenha = document.getElementById("txtSenha");
    txtEmail.focus();

    btnOlho.addEventListener("mousedown", function () {
        txtSenha.type = "text";
    });

    btnOlho.addEventListener("mouseup", function () {
        txtSenha.type = "password";
    });

    btnOlho.addEventListener("mouseleave", function () {
        txtSenha.type = "password";
    });

    btnEntrar.onclick = function (e) {

        e.preventDefault();

        var email = txtEmail.value;
        var senha = txtSenha.value;

        if (email == "") {
            exibirMensagemErro("Informe o E-mail.");
        }
        else if (senha == "") {
            exibirMensagemErro("Informe a Senha.");
        }
        else {
            realizalogin(email, senha)
        }
    };
    function exibirMensagemErro(mensagem) {
        var spneErro = document.getElementById("spnErro");
        spneErro.innerText = mensagem;
        spneErro.style.display = "block";

        setTimeout(function () {
            spneErro.style.display = "none";

        }, 5000);

    }
    function realizalogin(email, senha) {

        var login = {
            "email": email,
            "senha": senha
        }
        var data = JSON.stringify(login);
        var xhr = new XMLHttpRequest();


        xhr.addEventListener("readystatechange", function () {
            if (this.readyState === 4) {
                var loginResult = JSON.parse(this.responseText);
                if (loginResult.sucesso) {

                    localStorage.setItem("usuarioGuid", loginResult.usuarioGuid);

                    window.location.href = "home.html";
                }
                else {
                    exibirMensagemErro(loginResult.mensagem);
                }

            }
        });

        xhr.open("POST", "http://localhost:5282/api/usuario/login");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.send(data);
    }
}