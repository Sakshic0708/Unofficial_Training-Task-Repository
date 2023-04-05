$(document).ready(function () {
   
    var countryOptions = '';
    var stateOptions = '';
    var cityOptions = '';

    $.ajax({
        type: "Get",
        url: './Countries.json',
        dataType: 'json',   
        success: function (data) {
            console.log(data);
            countryOptions += "<option value=''>Select country</option>";
            $.each(data.countries, function (index, country) {
                countryOptions += "<option value='" + country.id + "'>" + country.name + "</option>";
            });
            $('#country').html(countryOptions);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus + ': ' + errorThrown);
        }
    });

    $(document).on('change', '#country', function () {
        // Reset state and city options
        stateOptions = '';
        cityOptions = '';
    
        var country_id = $(this).val();
        if (country_id != '') {
            // Load states based on selected country
            $.ajax({
                url: 'States.json',
                dataType: 'json',
                success: function (data) {
                    stateOptions += '<option value="">Select state</option>';
                    $.each(data.states, function (key, state) {
                        if (country_id == state.country_id) {
                            stateOptions += '<option value="' + state.id + '">' + state.name + '</option>';
                        }
                    });
                    $('#state').html(stateOptions);
                    // Reset city options
                    $('#city').html('<option value="">Select city</option>');
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });
        }
        else {
            $('#state').html('<option value="">Select state</option>');
            $('#city').html('<option value="">Select city</option>');
        }
    });
    
    

    $(document).on('change', '#state', function () {
        // Reset city options
        cityOptions = '';
    
        var state_id = $(this).val();
        if (state_id != '') {
            $.ajax({
                url: 'Cities.json',
                dataType: 'json',
                success: function (data) {
                    cityOptions += '<option value="">Select city</option>';
                    $.each(data.cities, function (key, city) {
                        if (state_id == city.state_id) {
                            cityOptions += '<option value="' + city.id + '">' + city.name + '</option>';
                        }
                    });
                    $('#city').html(cityOptions);
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });
        }
        else {
            $('#city').html('<option value="">Select city</option>');
        }
    });
    
});

