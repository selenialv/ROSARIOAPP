
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grados/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Grados/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Grados/Delete/" + $(this).data("id"));

});