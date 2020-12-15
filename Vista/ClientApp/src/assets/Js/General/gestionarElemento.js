function guardarHTML(key){
    var documento = document;
    var objDocumento = JSON.stringify(documento);
    sessionStorage.setItem(key, objDocumento);
}

function obtenerHTML(key){
    strDocumento = sessionStorage.getItem(key);
    document = JSON.parse(strDocumento);
    return document;
}

function deshabilitar(key, id){
    document = obtenerHTML(key);
    elemento = document.getElementById(id);	
    elemento.style.display = 'none';
}

function habilitar(display, key, id){
    document = obtenerHTML(key);
    elemento = document.getElementById(id);	
    elemento.style.display = display;
}

function ocultar(key, id){
    deshabilitar(key, id);
    guardarHTML(key);
}

function cambio(key1, id1, key2, id2, display){
    deshabilitar(key1, id1);
    habilitar(display, key2, id2);
}

function acceder(key1, id1, key2, id2, key3, id3, display){
    deshabilitar(key3, id3);
    deshabilitar(key1, id1);
    habilitar(display, key2, id2);
}
