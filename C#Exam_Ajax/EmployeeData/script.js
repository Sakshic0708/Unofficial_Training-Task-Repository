$(document).ready(function () {
    $.ajax({
        url: "Employee_10-04-2023.json",
        type: 'GET',
        success: function (data) {
            
            var employeeDataTable = $('#employeeDataTable').DataTable({
                "dom": '<"toolbar">frtip',
                binfo: false,
                "searching": true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: 'Search...'
                },
                data : data,
                columns: [
                    { data: "EmployeeId", className: 'text-center', orderable: false },
                    { data: "Name", className: 'text-center' },
                    { data: "Department", className: 'text-center', 
                      render: function(data, type, row) {
                        switch(data) {
                            case 'Sales':
                                return '<span class="text-sales">' + data + '</span>';
                            case 'Marketing':
                                return '<span class="text-Marketing">' + data + '</span>';
                            case 'Developer':
                                return '<span class="text-Developer">' + data + '</span>';
                            case 'QA':
                                return '<span class="text-QA">' + data + '</span>';
                            case 'HR':
                                return '<span class="text-HR ">' + data + '</span>';
                            case 'SEO':
                                return '<span class="text-SEO">' + data + '</span>';
                            default:
                                return data;
                        }
                    }},
                    { 
                        data: "Email", 
                        className: 'text-center',
                        render: function (data, type, row) {
                            return '<a href="mailto:' + data + '">' + data + '</a>';
                        }
                    },
                    { 
                        data: "Phone", 
                        className: 'text-center',
                        render: function (data, type, row) {
                            return '<a href="tel:' + data + '">' + data + '</a>';
                        }
                    },
                    { data: "Gender", className: 'text-center' },
                    {
                        data: null,
                        className: 'text-center',
                        orderable: false,
                        render: function (data, type, row) {
                            return (
                                '<button type="button" class="btn btn-sm showDetails" view-id="' + row.employeeID + '"><i class="fa fa-eye"></i></button>'
                            );
                        },
                    },
                ]
                ,

            });
            
            $(document).on('click', '.showDetails', function () {
                var addrow = employeeDataTable.row($(this).closest('tr')).data();
                $('#empName').text(addrow.Name);
                $('#empEmail').text(addrow.Email);
                $('#empDob').text(addrow.DateOfBirth);
                $('#empgender').text(addrow.Gender);
                $('#empDesignation').text(addrow.Designation);
                $('#empState').text(addrow.State);
                $('#empCity').text(addrow.City);
                $('#empPostcode').text(addrow.Postcode);
                $('#empPhone').text(addrow.Phone);
                $('#empDepartment').text(addrow.Department);
                $('#empSalary').text( addrow.MonthlySalary);
                $('#empdateOfJoining').text(addrow.DateOfJoining);
                $('#empTotalexp').text(addrow.TotalExperience);
                $('#empRemarks').text(addrow.Remarks);
                $('#EmployeeDetail').modal('show');
            });
        },
        error: function () {
            alert('Error retrieving data!');
        }
    });

});

