$(document).ready(function () {

    // select2
    $('#categoryList').select2({
        theme: 'bootstrap4',         /*use bootstrap 4 theme*/
        placeholder: "Select a category...",
        allowClear: true
    });

    $('#filterByList').select2({
        theme: 'bootstrap4',         
        placeholder: "Select a filter type...",
        allowClear: true
    });

    $('#orderByList').select2({
        theme: 'bootstrap4',
        placeholder: "Select order by...",
        allowClear: true
    });

    $('#isAscendingList').select2({
        theme: 'bootstrap4',
        placeholder: "Select order type...",
        allowClear: true
    });


    // jquery ui datepicker

    $(function () {
        $("#startAtDatePicker").datepicker({
            duration: 1000,
            showAnim: "drop",
            showOptions: {direction: "down"},
            //minDate: -3,
            maxDate: 0,          // means max today
            onSelect: function (selectedDate) {
                $("#endAtDatePicker").datepicker('option', 'minDate', selectedDate || getTodaysDate());    // set selected value to min value for end date
            }
        
        });

        $("#endAtDatePicker").datepicker({
            duration: 1000,
            showAnim: "drop",
            showOptions: { direction: "down" },
            //minDate: -3,
            maxDate: 0          

        });
    });


});