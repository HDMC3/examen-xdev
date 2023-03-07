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