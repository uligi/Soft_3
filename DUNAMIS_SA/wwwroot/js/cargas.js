document.addEventListener('DOMContentLoaded', function () {
    var editModal = document.getElementById('editModal');
    editModal.addEventListener('show.bs.modal', function (event) {
        var button = event.relatedTarget;
        var id = button.getAttribute('data-id');
        var modalTitle = editModal.querySelector('.modal-title');
        var modalBodyInputID = editModal.querySelector('#CargaID');
        var modalBodyInputPeso = editModal.querySelector('#Peso');
        var modalBodyInputFechaEnvio = editModal.querySelector('#FechaEnvio');
        var modalBodyInputDestino = editModal.querySelector('#Destino');
        var modalBodyInputTipoDeCargaID = editModal.querySelector('#TipoDeCargaID');
        var modalBodyInputClienteID = editModal.querySelector('#ClienteID');

        if (id) {
            // Obtener los datos del modelo para el ID dado
            var data = JSON.parse(document.getElementById('cargaTableBody').dataset.model);
            var carga = data.find(item => item.CargaID == id);

            modalBodyInputID.value = carga.CargaID;
            modalBodyInputPeso.value = carga.Peso;
            modalBodyInputFechaEnvio.value = carga.FechaEnvio.split('T')[0]; // Formato YYYY-MM-DD
            modalBodyInputDestino.value = carga.Destino;
            modalBodyInputTipoDeCargaID.value = carga.TipoDeCargaID;
            modalBodyInputClienteID.value = carga.ClienteID;
            modalTitle.textContent = 'Editar Carga';
        } else {
            modalBodyInputID.value = '';
            modalBodyInputPeso.value = '';
            modalBodyInputFechaEnvio.value = '';
            modalBodyInputDestino.value = '';
            modalBodyInputTipoDeCargaID.value = '';
            modalBodyInputClienteID.value = '';
            modalTitle.textContent = 'Agregar Carga';
        }
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
        var tipoDeCargaID = document.getElementById('TipoDeCargaID').value;
        var clienteID = document.getElementById('ClienteID').value;

        // Simulando la creación/actualización de datos
        if (id) {
            alert('Carga ' + id + ' actualizada: ' + peso + ', ' + fechaEnvio + ', ' + destino + ', ' + tipoDeCargaID + ', ' + clienteID);
        } else {
            alert('Nueva Carga agregada: ' + peso + ', ' + fechaEnvio + ', ' + destino + ', ' + tipoDeCargaID + ', ' + clienteID);
        }

        var modal = bootstrap.Modal.getInstance(editModal);
        modal.hide();
        location.reload(); // Recargar la página para ver los cambios
    });

    var fechaEnvioInput = document.getElementById('FechaEnvio');
    fechaEnvioInput.addEventListener('input', function () {
        var datePattern = /^\d{4}-\d{2}-\d{2}$/;
        if (!datePattern.test(this.value)) {
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }
    });

    var pesoInput = document.getElementById('Peso');
    pesoInput.addEventListener('input', function () {
        if (this.value < 0) {
            this.classList.add('is-invalid');
            this.value = 0;
        } else {
            this.classList.remove('is-invalid');
        }
    });

    var destinoInput = document.getElementById('Destino');
    destinoInput.addEventListener('input', function () {
        var maxLength = 255;
        if (this.value.length > maxLength) {
            this.value = this.value.substring(0, maxLength);
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
