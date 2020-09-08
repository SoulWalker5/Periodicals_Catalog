$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $('#SearchString').keyup(function () {
        $('#result').html('');
        $('#state').val('');

        var searchField = $('#SearchString').val();
        var exx = new RegExp(searchField, "i");
        var dataString = window.location.protocol + "//" + window.location.host + "/"

        $.getJSON(dataString + 'Search/Json', function (data) {
            var count = 0;
            $.each(JSON.parse(data), function (key, value) {
                if (value.Name.search(exx) != -1 & count < 5) {
                    count++;
                    $('#result').append('<li class="list-group-item "><a href="' + dataString + 'Periodical/Details/' + value.Id + '"><img src="../../Images/' + value.ImageName + '" height="40" width="40" class="img-thumbnail" /> ' + value.Name + '</a></li>');
                }
                if (count == 5) {
                    count++;
                    $('#result').append('<li id="allResult" class="list-group-item text-center"><a href="' + dataString + 'Search?searchString=' + $('#SearchString').val() + '">' + 'See all results' + '</a></li>');
                }

                if (!searchField.length)
                    $('#result').empty();

            });
        });
    });

    $('#result').on('click', 'li', function () {
        if ($(this).text() == 'See all results') {
            $('#SearchString').focus();
            $('#form').submit();
        }

        //else {
        //    var click_text = $(this).text().split('|');
        //    $('#SearchString').val($.trim(click_text[0]));
        //    $("#result").html('');
        //    $('#SearchString').focus();
        //    $('#form').submit();
        //}
    });
});