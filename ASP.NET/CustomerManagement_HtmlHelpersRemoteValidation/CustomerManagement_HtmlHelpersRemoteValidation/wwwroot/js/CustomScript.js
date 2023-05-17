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

    $('#exportBtn').click(function () {
        $.ajax({
            type: 'GET',
            url: '/Customer/ExportCustomersCSV',
            success: function (data) {
                var link = document.createElement('a');
                link.href = "data:text/csv;base64," + btoa(data);
                link.download = "Export.csv";
                link.click();
                //document.body.appendChild(link);
                //document.body.removeChild(link);
            },
            error: function (error) {
                alert('Error exporting data to CSV');
            }
        });
    });

  

    $('.role-dropdown').change(function () {
        var userId = $(this).data('user-id');
        var roleName = $(this).val();
        $.ajax({
            type: 'POST',
            url: '/Account/ChangeRole',
            data: { Id: userId, role: roleName },
            success: function () {
                swal.fire({
                    text: "Role changed successfully.",
                    icon: "success",
                    button: "ok"
                });
            },
            error: function () {
                swal.fire({
                    text: "An error occurred while changing the role.",
                    icon: "error",
                    button: "ok"
                });
            }
        });
    });


    $(document).on('click', '.RoleDelete-Btn', function (e) {
        e.preventDefault();
        var RoleId = $(this).data('id');
        Swal.fire({
            title: 'Are you sure?',
            text: 'You do not be able to revert this!"',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/Roles/DeleteRole',
                    type: 'POST',
                    data: { id: RoleId },
                    success: function (result) {
                        var element = $('#' + RoleId);
                        element.remove();

                    },
                    error: function (xhr, status, error) {
                        console.log(xhr.responseText);
                    }
                });
            }
        });
    });


});
