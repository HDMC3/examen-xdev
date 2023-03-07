// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const deleteProducModalElement = document.querySelector("#delete-product-modal");

if (deleteProducModalElement) {
    const deleteProductModal = new bootstrap.Modal(deleteProducModalElement);
    const cancelButton = deleteProducModalElement.querySelector('#cancel-button');
    const closeButton = deleteProducModalElement.querySelector('#close-button');
    
    const showDeleteModalButton = document.querySelector("#show-delete-modal-button");
    
    showDeleteModalButton.onclick = () => {
        deleteProductModal.show();
    }

    cancelButton.onclick = () => {
        deleteProductModal.hide();
    }

    closeButton.onclick = () => {
        deleteProductModal.hide();
    }   
}

const generateXlsxButton = document.querySelector('#generate-xlsx-button');

if (generateXlsxButton) {
    const toast = new bootstrap.Toast(document.querySelector('#generate-xlsx-toast'), { delay: 2000 });

    generateXlsxButton.addEventListener('click', (e) => {
        generateXlsxButton.disabled = true;
        toast.show();
        fetch('/Products/GenerateSpreadsheet')
            .then(resp => resp.blob())
            .then(blob => {
                const link = document.createElement('a');
                link.href = URL.createObjectURL(blob);
                link.download = 'listado-productos.xlsx';
                link.click();
                URL.revokeObjectURL(link.href);
            })
            .finally(() => {
                generateXlsxButton.disabled = false;
            });
    });
}
