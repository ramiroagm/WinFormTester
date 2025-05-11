function initializePopovers() {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));
    console.log("Popovers reinitialized:", popoverList);
}

window.initializeModals = () => {
    const modalElement = document.getElementById('addPersonModal');
    if (modalElement) {
        modalElement.addEventListener('shown.bs.modal', () => {
            console.log('El modal de agregar persona se ha mostrado.');
        });
    }
};

window.initializeModalEvents = () => {
    const addressModal = document.getElementById('addAddressModal');
    const personModal = new bootstrap.Modal(document.getElementById('addPersonModal'));

    if (addressModal) {
        addressModal.addEventListener('hidden.bs.modal', () => {
            personModal.show();
        });
    }
};