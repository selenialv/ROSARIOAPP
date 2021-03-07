var telefono = new Array(4, 3, 2, 2); // Patron para telefono
var cuenta_bancaria = new Array(4, 4, 2, 10); // Patron para Cuent Bancaria
var cedula = new Array(1, 10); // Patron para Numero de Cedula
var RIF = new Array(1, 8, 1); // Patron para Registro de Informacion Fiscal
var fecha =new Array(2, 2, 4); // Patron para Fecha (dd/mm/aaaa)

function mascara(d, sep, pat, nums) {
    if (d.valant != d.value) {
        val = d.value;
        largo = val.length;
        val = val.split(sep);
        val2 = '';
        for (r = 0; r < val.length; r++) {
            val2 += val[r];
        }

        if (nums) {
            for (z = 0; z < val2.length; z++) {
                if (isNaN(val2.charAt(z))) {
                    letra = new RegExp(val2.charAt(z), "g");
                    val2 = val2.replace(letra, "");
                }
            }
        }

        val = '';
        val3 = new Array();

        for (s = 0; s < pat.length; s++) {
            val3[s] = val2.substring(0, pat[s]);
            val2 = val2.substr(pat[s]);
        }

        for (q = 0; q < val3.length; q++) {
            if (q == 0) {
                val = val3[q];
            }
            else {
                if (val3[q] != "") {
                    val += sep + val3[q];
                }
            }
        }
        d.value = val;
        d.valant = val;
    }
}
