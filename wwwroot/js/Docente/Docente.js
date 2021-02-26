
     $('#btnNuevo').click(function (eve) {

         $('#modal-content').load('/Docentes/Create');
         $('myModal').modal('toggle');
   
     });


$('.btnEdit').click(function (eve) {

    $('#modal-content').load("/Docentes/Edit/"+ $(this).data("id"));
    
});

$('.btnDelete').click(function (eve) {

    $('#modal-content').load("/Docentes/Delete/" + $(this).data("id"));

});

$('.btnDeta').click(function (eve) {

    $('#modal-content').load("/Docentes/Details/" + $(this).data("id"));

});

    

   





