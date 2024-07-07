$(document).ready(function () {
    var editModal = document.getElementById('editModal');
    var backdropExists = false;

    // Eliminar los backdrop adicionales al cerrar el modal
    $('#editModal').on('hidden.bs.modal', function () {
        if (backdropExists) {
            $('.modal-backdrop').remove();
            backdropExists = false;
        }
    });

    editModal.addEventListener('show.bs.modal', function (event) {
        var button = event.relatedTarget;
        var id = button.getAttribute('data-id');
        var modalTitle = editModal.querySelector('.modal-title');
        var modalBodyInputID = editModal.querySelector('#CargaID');
        var modalBodyInputPeso = editModal.querySelector('#Peso');
        var modalBodyInputFechaEnvio = editModal.querySelector('#FechaEnvio');
        var modalBodyInputDestino = editModal.querySelector('#Destino');
        var modalBodyInputTipoDeCarga = editModal.querySelector('#TipoDeCargaID');
        var modalBodyInputCliente = editModal.querySelector('#ClienteID');

        if (id) {
            // Obtener los datos del modelo para el ID dado
            var data = @Html.Raw(System.Text.Json.JsonSerializer.Serialize(Model));
            var carga = data.find(item => item.CargaID == id);

            modalBodyInputID.value = carga.CargaID;
            modalBodyInputPeso.value = carga.Peso;
            modalBodyInputFechaEnvio.value = carga.FechaEnvio.split('T')[0]; // Formatear la fecha
            modalBodyInputDestino.value = carga.Destino;
            modalBodyInputTipoDeCarga.value = carga.TipoDeCargaID;
            modalBodyInputCliente.value = carga.ClienteID;
            modalTitle.textContent = 'Editar Carga';
        } else {
            modalBodyInputID.value = '';
            modalBodyInputPeso.value = '';
            modalBodyInputFechaEnvio.value = '';
            modalBodyInputDestino.value = '';
            modalBodyInputTipoDeCarga.value = '';
            modalBodyInputCliente.value = '';
            modalTitle.textContent = 'Agregar Carga';
        }

        // Establecer que existe un backdrop
        backdropExists = true;
    });

    var cargaForm = document.getElementById('cargaForm');
    cargaForm.addEventListener('submit', function (event) {
        event.preventDefault();

        if (!cargaForm.checkValidity()) {
            event.stopPropagation();
            cargaForm.classList.add('was-validated');
            return;
        }

        var id = document.getElementById('CargaID').value;
        var peso = document.getElementById('Peso').value;
        var fechaEnvio = document.getElementById('FechaEnvio').value;
        var destino = document.getElementById('Destino').value;
        var tipoDeCarga = document.getElementById('TipoDeCargaID').value;
        var cliente = document.getElementById('ClienteID').value;

        // Simulando la creación/actualización de datos
        if (id) {
            alert('Carga ' + id + ' actualizada: ' + peso + ' kg, ' + fechaEnvio + ', ' + destino);
        } else {
            alert('Nueva Carga agregada: ' + peso + ' kg, ' + fechaEnvio + ', ' + destino);
        }

        var modal = bootstrap.Modal.getInstance(editModal);
        modal.hide();
        location.reload(); // Recargar la página para ver los cambios
    });

    // Validación para la cantidad de caracteres y el formato permitido
    var destinoInput = document.getElementById('Destino');
    destinoInput.addEventListener('input', function () {
        var maxLength = 255;
        if (this.value.length > maxLength) {
            alert('El destino no puede tener más de ' + maxLength + ' caracteres.');
            this.value = this.value.substring(0, maxLength);
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }

        var invalidChars = /[^a-zA-Z0-9\s]/;
        if (invalidChars.test(this.value)) {
            alert('El destino solo puede contener letras, números y espacios.');
            this.value = this.value.replace(invalidChars, '');
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }
    });
});

function showAddModal() {
    var modal = new bootstrap.Modal(document.getElementById('editModal'));
    modal.show();
}

function deleteCarga(id) {
    if (confirm('¿Está seguro de que desea eliminar esta carga?')) {
        // Simulando la eliminación de datos
        alert('Carga ' + id + ' eliminada');
        location.reload();
    }
}
