function getModal(url) {
    $.get(url, function (data) {
        $('.modal-content').html(data);
        $('#modal-container').modal('show');
    });
}
