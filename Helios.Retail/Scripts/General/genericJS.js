var UsuariosSystem = [];
var listProductSelCategory = [];
var listProductSales = [];
var listPedidosActivos = [];
var listCategorias[];

function convertirNumero(str) {
    //El número vendrá como 1.234.567,89 €
    return Number(str.replace(/\./g, "").
        replace(/,/, ".").
        replace(/[^\d.+-]/g, ""));
}


function roundNumber(num, scale) {
    if (!("" + num).includes("e")) {
        return +(Math.round(num + "e+" + scale) + "e-" + scale);
    } else {
        var arr = ("" + num).split("e");
        var sig = ""
        if (+arr[1] + scale > 0) {
            sig = "+";
        }
        return +(Math.round(+arr[0] + "e" + sig + (+arr[1] + scale)) + "e-" + scale);
    }
}