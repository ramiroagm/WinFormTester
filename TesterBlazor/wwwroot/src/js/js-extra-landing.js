window.closeModal = function (id) {
    $('#' + id).modal('hide');
    setTimeout(function () {
        $('.modal-backdrop').remove();
        $('body').removeClass('modal-open');
    }, 500);
}