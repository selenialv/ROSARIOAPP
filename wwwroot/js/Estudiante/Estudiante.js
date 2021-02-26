
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Estudiantes/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Estudiantes/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Estudiantes/Delete/" + $(this).data("id"));

});

$('.btnDeta').click(function (eve) {

    $('#modal-content').load("/Estudiantes/Details/" + $(this).data("id"));

});
