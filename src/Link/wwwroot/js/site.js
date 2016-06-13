$(function () {
    $('input[name="User.BirthDate"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        "minDate": "01/01/1950",
        "maxDate": "01/01/2016",
        locale: {
            format: 'DD/MM/YYYY'
        }
    });
});
