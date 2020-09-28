var UsuariosSystem = []
var PedidoSeleccionado = null;
var PeriodoSeleccionado = null;
var listProductSelCategory = [];

var listProductsGeneral = [];
var transferTransitCount = null;
var ClienteVarios = null;
var almacenList = [];


function out() {
    var args = Array.prototype.slice.call(arguments, 0);
    var formatted = args.map(a => {
        if (isObject(a)) {
            return JSON.stringify(a);
        }
        return a;
    });
    document.getElementById('output').innerHTML += formatted.join(" ") + "\n";
}
function isObject(obj) {
    return obj === Object(obj);
}