
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Grupos/Create');

});

$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Grupos/Edit/" + $(this).data("id"));

});
$('.btnDetails').click(function (eve) {

    $('#modal-content').load("/Grupos/Details/" + $(this).data("id"));

});
$('.btnAsignar').click(function (eve) {

    $('#modal-content').load("/Grupos/CreateAsignar/" + $(this).data("id"));

});


$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Grupos/Delete/" + $(this).data("id"));

});



