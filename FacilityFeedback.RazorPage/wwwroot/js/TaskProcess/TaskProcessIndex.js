
var listState = ["#WaitingState", "#IncomingState", "ProcessingState", "EndingState"]
listState.forEach((element) => {
    $(element).on('click', '.pagination-container a', function (e) {
        e.preventDefault();
        var hrefState = $(this).attr("href");
        loadTaskProcess(hrefState.replace("action", "handler"), element);

    });
});

var loadTaskProcess = function (hrefState, state) {
    var _url = hrefState;
        $.ajax({
            type: "GET",
            url: _url,
            success: function (response) {
                $(state).empty();
                $(state).append(response);
            }

        })
    }

    

