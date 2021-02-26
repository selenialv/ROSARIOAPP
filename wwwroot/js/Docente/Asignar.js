
$('#btnNuevo').click(function (eve) {

    $('#modal-content').load('/Asignars/Create');
    $('myModal').modal('toggle');

});


$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Asignars/Edit/" + $(this).data("id"));

});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Asignars/Delete/" + $(this).data("id"));

});
