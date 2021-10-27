$(document).ready(function () {
    $("#myTable").DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
        "lengthChange": true,
        lengthMenu : [3, 5, 10]
    });
});