function initializePopovers() {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));
    console.log("Popovers reinitialized:", popoverList);
}

window.initializeModals = (modalId) => {
    const modalElement = document.getElementById(modalId);
    if (modalElement) {
        modalElement.addEventListener('shown.bs.modal', () => {
        });
    }
};

window.showModal = (modalId) => {
    const modalElement = document.getElementById(modalId);
    if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
    }
};

window.closeModal = (modalId) => {
    var modalEl = document.getElementById(modalId);
    if (modalEl) {
        var modal = bootstrap.Modal.getInstance(modalEl) || new bootstrap.Modal(modalEl);
        modal.hide();
    }
};

window.initializeModalEvents = () => {
    const addressModal = document.getElementById('addAddressModal');
    const personModalElement = document.getElementById('addPersonModal');
    const personModal = new bootstrap.Modal(personModalElement);

    let reopenedByAddress = false;

    if (addressModal) {
        addressModal.addEventListener('show.bs.modal', () => {
            reopenedByAddress = true;
        });

        addressModal.addEventListener('hidden.bs.modal', () => {
            setTimeout(() => {
                document.querySelectorAll('.modal-backdrop').forEach(e => e.remove());
                document.body.classList.remove('modal-open');
                if (reopenedByAddress && !personModalElement.classList.contains('show')) {
                    personModal.show();
                }
                reopenedByAddress = false;
            }, 200);
        });
    }
};