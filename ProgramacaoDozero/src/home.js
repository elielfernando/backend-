
window.onload = function (e) {

    var usuarioGuid = this.localStorage.getItem("usuarioGuid");

    if (usuarioGuid == null) {
        window.location.href = "login.html";
    }
    else {
        obterUsuario(usuarioGuid);
    }
    var lnkSair = this.document.getElementById("lnkSair");

    lnkSair.onclick = function (e) {

        localStorage.removeItem("usuarioGuid");
        window.location.href = "login.html";
    }
    var icon = document.querySelector(".icon");

    icon.onclick = function (e) {
        var menu = document.querySelector(".topnav");

        if (menu.className == "topnav") {
            menu.className += " open";
        }
        else {
            menu.className = "topnav";
        }
    }

    function obterUsuario(usuarioGuid) {

        var xhr = new XMLHttpRequest();


        xhr.addEventListener("readystatechange", function () {
            if (this.readyState === 4) {
                var result = JSON.parse(this.responseText);

                if (result.sucesso) {

                    var spn = document.getElementById("spnMensagem");
                    spn.innerText = "Bem-vindo ao sistema  " + result.nome;
                }
                else {
                    window.location.href = "login.html"
                }
            }
        });

        xhr.open("GET", "http://localhost:5282/api/usuario/obterUsuario?usuarioGuid=" + usuarioGuid);

        xhr.send();


    }
}