//Data tables
$(document).ready(function () {
    $("table").DataTable({
        aaSorting: [],
        responsive: true,

        columnDefs: [
            {
                responsivePriority: 1,
                targets: 0
            },
            {
                responsivePriority: 2,
                targets: -1
            }
        ]
    });

    $(".dataTables_filter input")
        .attr("placeholder", "Search here...")
        .css({
            width: "300px",
            display: "inline-block"
        });

    $('[data-toggle="tooltip"]').tooltip();
});

//Cerrar alerta automaticamente
window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 4000)