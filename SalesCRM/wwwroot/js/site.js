// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#myTable').DataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        "order": [[0, "asc"]],
        "pagingType": "full_numbers"
    });

    $.ajax({
        url: 'https://localhost:44328/Leads/Index', // Sesuaikan dengan URL tindakan Anda
        type: 'GET',
        dataType: 'json', // Mengharapkan respons JSON
        success: function (data) {
            // Data JSON akan tersedia di sini
            // Anda dapat memprosesnya sesuai kebutuhan Anda
            console.log(data); // Contoh: Tampilkan data di konsol
        },
        error: function (error) {
            // Tangani kesalahan di sini, jika terjadi
            console.error(error);
        }
    });
});
