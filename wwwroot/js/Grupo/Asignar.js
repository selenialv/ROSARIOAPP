$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Asignar/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Asignar/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Asignar/Delete/" + $(this).data("id"));

});