window.onload = function (e) {

    var btnCadastrar = document.getElementById("btnCadastrar");

    var txtNome = document.getElementById("txtNome");
    var txtSobrenome = document.getElementById("txtSobrenome");
    var txtEmail = document.getElementById("txtEmail");
    var txtTelefone = document.getElementById("txtTelefone");
    var slcGenero = document.getElementById("slcGenero");
    var txtSenha = document.getElementById("txtSenha");
    txtNome.focus();


    //funcao pra ver senha

    var btnOlho = document.getElementById("btnOlho");
    var txtSenha = document.getElementById("txtSenha");

    btnOlho.addEventListener("mousedown", function () {
        txtSenha.type = "text"; // mostra a senha
    });

    btnOlho.addEventListener("mouseup", function () {
        txtSenha.type = "password"; // esconde a senha
    });

    btnOlho.addEventListener("mouseleave", function () {
        txtSenha.type = "password"; // caso o mouse saia do botão ainda pressionado
    });


    btnCadastrar.onclick = function (e) {

        e.preventDefault();

        var nome = txtNome.value;
        var sobrenome = txtSobrenome.value;
        var email = txtEmail.value;
        var telefone = txtTelefone.value;
        var genero = slcGenero.value;
        var senha = txtSenha.value;

        if (nome == "" ||
            sobrenome == "" ||
            senha == "" ||
            telefone == "" ||
            email == "" ||
            genero == "") {

            var mensagem = "Os campos acima s�o obrigat�rios.";

            exibirMensagemErro(mensagem);
        }
        else {
            fazerCadastro(nome, sobrenome, email, telefone, genero, senha)
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
    function fazerCadastro(nome, sobrenome, email, telefone, genero, senha) {
        var cadastrar = {
            "nome": nome,
            "sobrenome": sobrenome,
            "email": email,
            "telefone": telefone,
            "senha": senha,
            "genero": genero
        }
        var data = JSON.stringify(cadastrar);

        var xhr = new XMLHttpRequest();


        xhr.addEventListener("readystatechange", function () {

            if (this.readyState === 4) {

                var cadastroResult = JSON.parse(this.responseText);

                if (cadastroResult.sucesso) {
                    localStorage.setItem("usuarioGuid", cadastroResult.usuarioGuid);

                    window.location.href = "home.html";

                }

                if (cadastroResult.sucesso) {
                    alert("Cadastrou!");
                }
                else {
                    exibirMensagemErro(cadastroResult.mensagem);
                }

            }
        });

        xhr.open("POST", "http://localhost:5282/api/usuario/cadastro");
        xhr.setRequestHeader("Content-Type", "application/json");

        xhr.send(data);
    }
}
