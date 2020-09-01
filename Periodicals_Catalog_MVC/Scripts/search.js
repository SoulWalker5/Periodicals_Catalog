$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $('#SearchString').keyup(function () {
        $('#result').html('');
        $('#state').val('');

        var searchField = $('#SearchString').val();
        var exx = new RegExp(searchField, "i");
        var dataString = window.location.protocol + "//" + window.location.host + "/"

        $.getJSON(dataString + 'Search/Json', function (data) {
            $.each(JSON.parse(data), function (key, value) {
                if (value.Name.search(exx) != -1) {
                    $('#result').append('<li class="list-group-item "><img src="../../Images/' + value.ImageName + '" height="40" width="40" class="img-thumbnail" /> ' + value.Name + '</li>');
                }

                if (!searchField.length)
                    $('#result').empty();
            });
        });
    });

    $('#result').on('click', 'li', function () {
        var click_text = $(this).text().split('|');
        $('#SearchString').val($.trim(click_text[0]));
        $("#result").html('');
        $('#SearchString').focus();
        $('#form').submit();
    });
});