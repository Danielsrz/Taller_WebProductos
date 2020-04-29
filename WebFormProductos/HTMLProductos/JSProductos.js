function Guardar() {
    if (validar() == true) {
        alert("Éste botón Guardará cosas más adelante");
    } else {
        alert("Debe completar todo el formulario");
    }
}

function Eliminar() {
    alert("Éste botón Eliminará cosas más adelante");
}

function Cancelar() {
    limpiarFormulario();
}

function validar() {
    var todo_correcto = true;

    if (document.getElementById('name').value.length < 2) {
        todo_correcto = false;
    }
    if (document.getElementById('desc').value.length < 2) {
        todo_correcto = false;
    }
    if (isNaN(document.getElementById('price').value) || (document.getElementById('price').value.length < 1)) {
        todo_correcto = false;
    }
    if (isNaN(document.getElementById('stock').value) || (document.getElementById('stock').value.length < 1)) {
        todo_correcto = false;
    }

    return todo_correcto;
}

function limpiarFormulario() {
    document.getElementById("productosHTML").reset();
}