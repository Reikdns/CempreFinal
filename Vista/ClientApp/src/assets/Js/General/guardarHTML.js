function guardarHTML(key){
    var documento = document.documentElement.innerHTML;
    var objDocumento = JSON.stringify(documento);
    sessionStorage.setItem(key, objDocumento);
}