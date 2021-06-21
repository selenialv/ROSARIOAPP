
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grupos/Create');

});

$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grupos/CreateAsignar');

});


$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Grupos/Edit/" + $(this).data("id"));

});
$('.btnDetails').click(function (eve) {

    $('#modal-content').load("/Grupos/Details/" + $(this).data("id"));

});



$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Grupos/Delete/" + $(this).data("id"));

});



