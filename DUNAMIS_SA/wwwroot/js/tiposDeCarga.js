document.addEventListener('DOMContentLoaded', function () {
    var editModal = document.getElementById('editModal');
    editModal.addEventListener('show.bs.modal', function (event) {
        var button = event.relatedTarget;
        var id = button ? button.getAttribute('data-id') : null;
        var modalTitle = editModal.querySelector('.modal-title');
        var modalBodyInputID = editModal.querySelector('#TipoDeCargaID');
        var modalBodyInputDesc = editModal.querySelector('#Descripcion');
        var modalBodyInputTarifa = editModal.querySelector('#TarifaPorKilo');

        if (id) {
            // Obtener los datos del modelo para el ID dado
            var data = JSON.parse('@Html.Raw(System.Text.Json.JsonSerializer.Serialize(Model))');
            var tipoCarga = data.find(item => item.TipoDeCargaID == id);

            modalBodyInputID.value = tipoCarga.TipoDeCargaID;
            modalBodyInputDesc.value = tipoCarga.Descripcion;
            modalBodyInputTarifa.value = tipoCarga.TarifaPorKilo;
            modalTitle.textContent = 'Editar Tipo de Carga';
        } else {
            modalBodyInputID.value = '';
            modalBodyInputDesc.value = '';
            modalBodyInputTarifa.value = '';
            modalTitle.textContent = 'Agregar Tipo de Carga';
        }
    });

    // Form submit validation and handling
    var tipoCargaForm = document.getElementById('tipoCargaForm');
    tipoCargaForm.addEventListener('submit', function (event) {
        event.preventDefault();

        if (!tipoCargaForm.checkValidity()) {
            event.stopPropagation();
            tipoCargaForm.classList.add('was-validated');
            return;
        }

        // Submit form
        var formData = $(this).serialize();
        $.ajax({
            type: "POST",
            url: '/TipoDeCarga/Save',
            data: formData,
            success: function (response) {
                location.reload(); // Recargar la página para ver los cambios
            },
            error: function (xhr, status, error) {
                alert('Error guardando el Tipo de Carga: ' + error);
            }
        });
    });

    // Validación para la cantidad de caracteres y el formato permitido
    var descripcionInput = document.getElementById('Descripcion');
    descripcionInput.addEventListener('input', function () {
        var maxLength = 50;
        if (this.value.length > maxLength) {
            alert('La descripción no puede tener más de ' + maxLength + ' caracteres.');
            this.value = this.value.substring(0, maxLength);
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }

        var invalidChars = /[^a-zA-Z0-9\s]/;
        if (invalidChars.test(this.value)) {
            alert('La descripción solo puede contener letras, números y espacios.');
            this.value = this.value.replace(invalidChars, '');
            this.classList.add('is-invalid');
        } else {
            this.classList.remove('is-invalid');
        }
    });

    var tarifaInput = document.getElementById('TarifaPorKilo');
    tarifaInput.addEventListener('input', function () {
        var minValue = 1;
        var maxValue = 10000;
        if (this.value < minValue || this.value > maxValue) {
            alert('La tarifa debe estar entre ' + minValue + ' y ' + maxValue + ' colones.');
            this.classList.add('is-invalid');
            if (this.value < minValue) {
                this.value = minValue;
            } else if (this.value > maxValue) {
                this.value = maxValue;
            }
        } else {
            this.classList.remove('is-invalid');
        }
    });
});

function showAddModal() {
    var modal = new bootstrap.Modal(document.getElementById('editModal'));
    modal.show();
}

function deleteTipoCarga(id) {
    if (confirm('¿Está seguro de que desea eliminar este tipo de carga?')) {
        $.ajax({
            type: "POST",
            url: '/TipoDeCarga/Delete',
            data: { id: id },
            success: function (response) {
                alert('Tipo de Carga ' + id + ' eliminado');
                location.reload();
            },
            error: function (xhr, status, error) {
                alert('Error eliminando el Tipo de Carga: ' + error);
            }
        });
    }
}
