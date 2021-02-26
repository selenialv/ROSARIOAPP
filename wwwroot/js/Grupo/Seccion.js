
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grupos/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Grupos/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Grupos/Delete/" + $(this).data("id"));

});



