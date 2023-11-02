
var listState = ["#WaitingState", "#IncomingState", "#ProcessingState", "#EndingState"]
listState.forEach((element) => {
    $(element).on('click', '.pagination-container a', function (e) {
        e.preventDefault();
        var hrefState = $(this).attr("href");
        loadTaskProcess(hrefState.replace("action", "handler"), element);

    });
});

//update process
listState.forEach((element) => {
    $(element).on('change', '#item_Process', function (e) {
        var processChange = $(this).val();
        var idProcess = $(this).closest('tr').find('input').val();
        var postData = JSON.stringify({ process: processChange, Id: idProcess });
        $.ajax({
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            type: "POST",
            url: "TaskProcessPage?handler=AsyncUpdateProcess",
            data: { process: processChange, Id: idProcess },
            async: true,


        }).done(function () {
            console.log("CAC");
            listState.forEach((state) => {
                var termState = state;
                var _href = "/TaskProcessPage?&pageIndex=1&handler=TaskProcessState&state=" + termState.replace("State", "").replace("#", "");
                    loadTaskProcess(_href, state);
            });
        });

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



