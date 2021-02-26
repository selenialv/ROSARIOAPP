
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Notas/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Notas/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Notas/Delete/" + $(this).data("id"));

});


$('.btnDeta').click(function (eve) {

    $('#modal-content').load("/Notas/Details/" + $(this).data("id"));

});
