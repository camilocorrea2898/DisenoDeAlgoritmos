function validarRol() {
    rolActual = parseInt(sessionStorage.getItem("rol"));

    if ( rolActual == '' || rolActual.length < 1 || rolActual == null || isNaN(rolActual) == true ) {
        location.href = "index.html";
    }
    else {

        if (rolActual == 1001) {
            $("#admon").show();
            $("#reports").show();
        }
        else {
            $("#admon").hide();
            $("#reports").hide();
        }

        cargar("index");
    }
}