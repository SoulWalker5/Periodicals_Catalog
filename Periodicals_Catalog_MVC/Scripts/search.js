$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $('#SearchString').keyup(function () {
        $('#result').html('');
        $('#state').val('');
        var searchField = $('#SearchString').val();
        var exx = new RegExp(searchField, "i");
        $.getJSON('Search/Json', function (data) {
            $.each(JSON.parse(data), function (key, value) {
                if (value.Name.search(exx) != -1) {
                    $('#result').append('<li class="list-group-item form-control">' + value.Name + '</li>');
                }
            });
        });
    });

    $('#result').on('click', 'li', function () {
        var click_text = $(this).text().split('|');
        $('#search').val($.trim(click_text[0]));
        $("#result").html('');
    });
});