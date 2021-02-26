
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Modalidads/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Modalidads/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Modalidads/Delete/" + $(this).data("id"));

});
