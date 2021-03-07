var departamento = document.querySelector('#departamento');
var municipios = document.querySelector('#municipios');
departamento.onchange = mandoDepartamento;

function reciboMaterias(respuesta) {

    limpiar();

    var lines = respuesta.split('\n');
    for (var line = 0; line < lines.length; line++) {
        var opt = document.createElement('option');
        opt.innerHTML = lines[line];
        opt.value = lines[line];
        departamento.appendChild(opt);
    }

}

function mandoDepartamento() {
    var ajax = new XMLHttpRequest();
    ajax.open('GET', departamento.value);
    ajax.onreadystatechange = function () {
        console.log(ajax.status, ajax.readyState, ajax.responseText);
        if (ajax.status === 200 && ajax.readyState === 4) {
            reciboMaterias(ajax.responseText);
        }
        else
            limpiar();
    }
    ajax.send();
}

function limpiar() {
    while (municipios.options.length > 0) {
        municipios.remove(0);
    }
}


