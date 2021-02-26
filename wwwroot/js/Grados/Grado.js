
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Gradoes/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Gradoes/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Gradoes/Delete/" + $(this).data("id"));

});