

$('#dropdown1').on('change', function () {
    table.columns(1).search(this.value).draw();
});
$('#dropdown2').on('change', function () {
    table.columns(2).search(this.value).draw();
});