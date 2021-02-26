
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Matriculas/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Matriculas/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Matriculas/Delete/" + $(this).data("id"));

});
$('.btnDeta').click(function (eve) {

    $('#modal-content').load("/Matriculas/Details/" + $(this).data("id"));

});
    

