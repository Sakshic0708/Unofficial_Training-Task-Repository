$(document).ready(function () {

    $('.CustomerDetails').click(function () {
        var customerId = $(this).attr('data-id');
        $.ajax({
            url: '/Customer/GetCustomerDetails',
            data: { id: customerId },
            type: 'GET',
            success: function (data) {
                $('#CustomerModalBody').html(data);
                $("#CustomerModalWindow").modal("show");
            },
            error: function () {
                swal({
                    text: "Error loading customer details",
                    icon: "error",
                    button: "ok"
                });
            }
        });
    });

    //$('#exportBtn').click(function () {
    //    alert('ok');
    //    $.ajax({
    //        url: '/ExportCustomersCSV/Customer',
    //        type: 'GET',
    //        success: function (data) {
    //            var link = document.createElement('a');
    //            link.href = "data:text/csv;base64," + btoa(data);
    //            link.download = "Export.csv";
    //            link.click();
    //            document.body.appendChild(link);
    //            document.body.removeChild(link);
    //        },
    //        error: function (error) {
    //            alert('Error exporting data to CSV');
    //        }
    //    });
    //});

    $('#exportBtn').click(function (e) {
        e.preventDefault();
        var baseUrl = window.location.href.split('?')[0]; // Get the base URL of the current page
        var url = baseUrl + 'Customer/ExportCustomersCSV?downloadCSV=true';

        window.location.href = url;
    });

    $('.role-dropdown').change(function () {
        var userId = $(this).data('user-id');
        var roleName = $(this).val();
        $.ajax({
            type: 'POST',
            url: '/Account/ChangeRole',
            data: { Id: userId, role: roleName },
            success: function () {
                swal({
                    text: "Role changed successfully.",
                    icon: "success",
                    button: "ok"
                });
            },
            error: function () {
                swal({
                    text: "An error occurred while changing the role.",
                    icon: "error",
                    button: "ok"
                });
            }
        });
    });


    //$('.delete-role-btn').click(function (e) {
    //    e.preventdefault();

    //    if (confirm("are you sure you want to delete this role?")) {
    //        var roleid = $('#id').val();

    //        $.ajax({
    //            url: '/roles/deleterole',
    //            type: 'post',
    //            data: { id: roleid },
    //            success: function (response) {
    //                if (response.success) {
    //                    alert(response.message);
    //                    window.location.href = '/roles/roles'; // redirect to the roles page
    //                } else {
    //                    alert(response.error);
    //                }
    //            },
    //            error: function (xhr, status, error) {
    //                alert("failed to delete role: " + error);
    //            }
    //        });
    //    }
    //});


});
