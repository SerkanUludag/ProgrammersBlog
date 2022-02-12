$(document).ready(function () {

    // trumbowyg

    $('#text-editor').trumbowyg({
        btns: [
            ['viewHTML'],                                    // if no extra button to add no need to write default buttons
            ['undo', 'redo'], // Only supported in Blink browsers
            ['formatting'],
            ['strong', 'em', 'del'],
            ['superscript', 'subscript'],
            ['link'],
            ['insertImage'],
            ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
            ['unorderedList', 'orderedList'],
            ['horizontalRule'],
            ['removeformat'],
            ['fullscreen'],
            ['foreColor', 'backColor'],
            ['emoji'],
            ['fontfamily'],
            ['fontsize']
        ]
        //plugins: {                    plugin use example only
        //    colors: {
        //        foreColorList: [
        //            'ff0000', '00ff00', '0000ff'
        //        ],
        //        backColorList: [
        //            '000', '333', '555'
        //        ],
        //        displayAsList: false
        //    }
        //}
    });

    // select2

    $('#categoryList').select2({
        theme: 'bootstrap4',         /*use bootstrap 4 theme*/
        placeholder: "Select a category...",
        allowClear: true
    });


    // jquery ui datepicker

    $(function () {
        $("#datepicker").datepicker({
            //closeText: "kapat",               TÜRKÇE DİLİ
            //prevText: "&#x3C;geri",
            //nextText: "ileri&#x3e",
            //currentText: "bugün",
            //monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            //    "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
            //monthNamesShort: ["Oca", "Şub", "Mar", "Nis", "May", "Haz",
            //    "Tem", "Ağu", "Eyl", "Eki", "Kas", "Ara"],
            //dayNames: ["Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi"],
            //dayNamesShort: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            //dayNamesMin: ["Pz", "Pt", "Sa", "Ça", "Pe", "Cu", "Ct"],
            //weekHeader: "Hf",
            //dateFormat: "dd.mm.yy",
            //firstDay: 1,
            //isRTL: false,
            //showMonthAfterYear: false,
            //yearSuffix: ""
            duration: 1000,
            showAnim: "drop",
            showOptions: {direction: "down"},
            minDate: -3,
            maxDate: +3
        
        });
    });


});