// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var baseUrl = window.location.origin;
var app = {
    init: function init() {
         //console.log("JS Masuk");
        app.ajax.init();
        //app.form.init();
        //app.dropdown.init();
        //app.printDetail();
        //app.logoutHandler();
        //validation.addMethods();
        //app.table.init();


        //if (!$("#logincont").length) {
        //    other.checkSession.init();
        //    app.notification.init();
        //}

        //app.checkBalance.init();
        //if ($(".select2").length) {
        //    $(".select2").select2();
        //}

        //app.checkPasswordChange();
        //window.onbeforeunload = function () {
        //    other.checkSession.init();
        //};
        // if($("#form_forget_password")) {
        //   app.validationPassword();
        // }
    },
    ajax: {
        init: function init() {
            console.log("ajax init masuk");
            $.ajaxSetup({
                headers: {
                    "X-CSRF-TOKEN": $('meta[name="csrf-token"]').attr("content"),
                },
                beforeSend: function beforeSend(jxqhr) {
                    // console.log(jxqhr, 'dor');
                    //swal.close();
                    //ui.popup.showLoader();
                },
                timeout: 600000,
                error: function error(event, jxqhr, status, _error) {
                    console.log(_error);
                    //ui.popup.hideLoader();
                    //status + " " + _error;
                    //// terjadi ganggungan jaringan mohon coba lagi, jika anda transaksi mohon cek history transaksi anda
                    //if (status == "timeout") {
                    //    ui.popup.alert("Error", "Transaksi Sedang Diproses", "error");
                    //} else if (_error == "timeout") {
                    //    ui.popup.alert("Error", "Transaksi Sedang Diproses", "error");
                    //} else {
                    //    ui.popup.alert("Error", status, "error");
                    //}
                },
                complete: function complete() {
                    // console.log({
                    // 	dor: e.responseJSON,
                    // 	tes: e
                    // })
                    // if (typeof e['code'] === 'undefined') {
                    // } else if (typeof e.responseJSON['code'] === 'undefined') {
                    // 	console.log('masuki');
                    // 	// ui.popup.hideLoader();
                    // } else if (typeof e.responseJSON['password'] === 'undefined') {
                    // 	ui.popup.hideLoader();
                    // } else {
                    // 	console.log('masuki elsetr');
                    // 	// $('#laporanOJK')[0].reset();
                    // 	// ui.popup.hideLoader();
                    // }
                },
                global: true,
            });
        },
        getData: function getData(url, method, params, callback) {
            console.log({
                url: url,
                 params: params,
                method: method,
                callback: callback
             });
            var urlArray = {
                "getGraphLineDefault?month=1": true,
                "get_graph?month=1": true,
                "get_graph?month=12": true,
            };
            if (urlArray && method == "get") {
                // console.log(url);
                $.ajaxSetup({
                    beforeSend: function beforeSend(jxqhr) { },
                });
            } else {
                $.ajaxSetup({
                    beforeSend: function beforeSend(jxqhr) {
                        //swal.close();
                        //ui.popup.showLoader();
                    },
                });
            }
            $.ajaxSetup({
                headers: {
                    "X-CSRF-TOKEN": $('meta[name="csrf-token"]').attr("content"),
                },
            });
            if (params == null) {
                params = {};
            }
            $.ajax({
                type: method,
                url: baseUrl + url,
                data: params,
                success: function success(result) {
                    //console.log("ini hasil", result);
                },
            });
        },
    },
}
$(document).ready(function () {
    app.init();

    //$('#myTable').DataTable({
    //    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
    //    "order": [[0, "asc"]],
    //    "pagingType": "full_numbers"
    //});

    //if ($('#myTable').length) {
    //    console.log("If ID Tabel Masuk");
    //    app.ajax.getData("/Leads/GetSalesLeads", "GET")
    //}

    if ($("#myTable").length) {
        console.log("If ID Tabel Masuk");
        app.ajax.getData("/Leads/GetSalesLeads", "GET", function (data) {
             console.log({
               calon: data,
             });
            var column = [{
                data: null,
            },
            {
                data: "firstName",
            },
            {
                data: "lastName",
            },
            {
                data: "mobile",
            },
            {
                data: "email",
            },
            {
                data: "source",
            },
            {
                data: "button",
            },
            ];
            app.table.setAndPopulate("myTable", column, data.data, null);
        });
    }

    //$.ajax({
    //    url: `${url}/Leads/Index`,
    //    type: 'GET',
    //    dataType: 'json',
    //    success: function (data) {
    //        console.log(data);
    //    },
    //    error: function (error) {
    //        console.error(error);
    //    }
    //});
});
