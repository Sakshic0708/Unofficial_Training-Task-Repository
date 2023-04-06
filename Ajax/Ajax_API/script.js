$(document).ready(function () {
    $.validator.addMethod('validName',
    function (value) {
        return /^[a-zA-Z\s]+$/.test(value)
    },
);

    $.validator.addMethod('validnumber',
        function (value) {
            return /^[0-9]$/.test(value)
        },
    );
    $("#ModalFormID").validate({
        rules: {
            EventTitle: {
                required: true,
                validName: true
            },
            startDate: {
                required: true,
            },
            endDate: {
                required: true,
            },
            Description: {
                required: true,
                validName: true
            },
            Priority: {
                required: true,
                validnumber: true
            },
        },
        messages: {
            EventTitle: {
                required: "Enter Event Title",
                validName: "Only Alphabets Allowed"
            },
            startDate: {
                required: "Choose Date",
            },
            endDate: {
                required: "Choose Date",
            },
            Description: {
                required: "Enter Event Description",
                validName: "Only Alphabets Allowed"
            },
            Priority: {
                required: "Enter Event Priority",
                validnumber: "Only Digits Allowed"
            },
        },
    });
 
    $('.get-data-button').click(function () {
        $.ajax({
            url: 'https://demosatva.azurewebsites.net/v1/api/Events',
            type: 'GET',
            data: JSON.stringify({}),
            success: function (data) {
                console.log(data);
                if (data.document != null) {
                    var rows = '';

                    $.each(data.document.records, function (index, item) {
                        rows += '<tr data-id="' + item.id + '">';
                        rows += '<td>' + item.eventTitle + '</td>';
                        rows += '<td>' + item.startDate + '</td>';
                        rows += '<td>' + item.endDate + '</td>';
                        rows += '<td>' + item.eventDescription + '</td>';
                        rows += '<td>' + item.eventPriority + '</td>';
                        rows += '<td><button class= "edit btn btn-warning me-2" id="EditButton" data-id="' + item.id + '">Edit </button><button class= "delete btn btn-danger" data-id="' + item.id + '">delete</button></td>';
                        rows += '</tr>';

                    });
                }
                else {
                    swal("Sorry!", "Data Not Available!!", "error");
                }
                $('.table-body').html(rows);
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }
        });
    });
    $("#addData").click(function () {
        $("#UpdateEvent").hide();
        $("#CreateEvent").show();
    })

    $("#CreateEvent").click(function () {
        if ($('#ModalFormID').valid() == true) {
            var title = $("#EventTitle").val();
            var startDate = $("#sDate").val();
            var endDate = $("#eDate").val();
            var description = $("#Description").val();
            var priority = $("#Priority").val();
            // var tableRow = "<tr><td>" + title + "</td><td>" + startDate + "</td><td>" + endDate + "</td><td>" + description + "</td><td>" + priority + "</td>" + '<td><button class= "edit btn btn-warning me-2" id="EditButton" data-id="' + item.id + '">Edit </button><button class= "delete btn btn-danger" data-id="' + item.id + '">delete</button></td></tr>';
            // $("#events-table").append(tableRow);
            var obj = {
                eventTitle: title,
                startDate: startDate,
                endDate: endDate,
                eventDescription: description,
                eventPriority: priority
            }
            console.log(obj);
            $.ajax({
                type: 'POST',
                url: 'https://demosatva.azurewebsites.net/v1/api/Events',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(obj),
                success: function (data) {
                    swal("Good job!", "Event Added Successfully!", "success");
                    document.getElementById("ModalFormID").reset();
                    $("#addDataModal").modal("hide");
                
                },
                error: function (xhr, textStatus, errorThrown) {
                    console.log(xhr.responseText);
                }
            });
        }
    });

    $(document).on('click', '.delete', function () {
        var eventId = $(this).data('id');
        $.ajax({
            url: 'https://demosatva.azurewebsites.net/v1/api/Events/' + eventId,
            type: 'DELETE',
            success: function (data) {
                swal("Yess!", "Delte Data Successfully!", "success");
                $(eventId).closest('tr').remove();
                $('.get-data-button').click();
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }
        });

    });

    $('.table-body').on('click', '.edit', function () {
        var id = $(this).closest('tr').data('id');
        $("#CreateEvent").hide();
        $("#UpdateEvent").show();

        $.ajax({
            url: 'https://demosatva.azurewebsites.net/v1/api/Events/' + id,
            type: 'GET',
            success: function (data) {
                $('#EventTitle').val(data.document.eventTitle);
                $('#sDate').val(data.document.startDate);
                $('#eDate').val(data.document.endDate);
                $('#Description').val(data.document.eventDescription);
                $('#Priority').val(data.document.eventPriority);

                // Create event handler for update button
                $('#UpdateEvent').off('click').on('click', function (e) {
                    e.preventDefault();

                    var editedData = {
                        eventTitle: $('#EventTitle').val(),
                        startDate: $('#sDate').val(),
                        endDate: $('#eDate').val(),
                        eventDescription: $('#Description').val(),
                        eventPriority: $('#Priority').val()
                    };

                    $.ajax({
                        url: 'https://demosatva.azurewebsites.net/v1/api/Events/' + id,
                        type: 'PUT',
                        data: JSON.stringify(editedData),
                        contentType: 'application/json',
                        success: function () {
                            $("#addDataModal").modal("hide");
                            $('.get-data-button').click();
                        },
                        error: function () {
                            console.log('Error in Operation');
                        }
                    });
                });
                $("#addDataModal").modal("show");
            },
            error: function () {
                console.log('Error in Operation');
            }
        });
    });




});



