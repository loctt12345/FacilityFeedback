$('#WaitingState').on('click', 'a', function (e) {
    e.preventDefault();
    var aa = $(this).attr("href");
    loadTaskProcess(aa.replace("action", "handler"));

});
    var loadTaskProcess = function (aa) {
        var _url = aa;
        $.ajax({
            type: "GET",
            url: _url,
            success: function (response) {
                $("#WaitingState").empty();
                $("#WaitingState").append(response);
            }

        })
    }

    

