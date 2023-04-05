$(document).ready(function(){
    $('input[name="startDate"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        timePicker : true,
        startDate: moment().startOf('hour'),
      
        locale: {
            format: 'MM/DD/YYYY hh:mm A'
          }
    });
    $('input[name="endDate"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        timePicker : true,
        startDate: moment().startOf('hour'),
      
        locale: {
            format: 'MM/DD/YYYY hh:mm A'
          }
    });
    
})
function fetch(){
    $.ajax({
        url: 'https://demosatva.azurewebsites.net/v1/api/Events',
        type: 'GET',
        dataType: 'json',
        data:JSON.stringify({  }),  
        success: function (data) {
            console.log(data);  
            $('.messages').append("<li>"+JSON.stringify(data)+"</li>")
        },
        error: function (xhr, textStatus, errorThrown) {
            console.log('Error in Operation');
        }
    });
    }

   
    