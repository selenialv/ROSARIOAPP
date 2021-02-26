
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Materias/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Materias/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Materias/Delete/" + $(this).data("id"));

});
