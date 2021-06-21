
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grados/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Grados/Edit/" + $(this).data("id"));

});

$('.btnDetalle').click(function (eve) {

    $('#modal-content').load("/Grados/Details/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Grados/Delete/" + $(this).data("id"));

});
