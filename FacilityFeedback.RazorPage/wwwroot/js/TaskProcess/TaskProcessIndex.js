const listState = ["#WaitingState", "#IncomingState", "#ProcessingState", "#FinishingState", "#EndingState"];
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
            listState.forEach((state) => {
                var termState = state;
                var _href = "/TaskProcessPage?&pageIndex=1&handler=TaskProcessState&state=" + termState.replace("State", "").replace("#", "");
                loadTaskProcess(_href, state);
            });
            $(listState[processChange])[0].scrollIntoView({
                behavior: 'smooth',
                block: 'center',
                inline: 'center'
            });
        });

    });
});

//update staff
listState.forEach((element) => {
    $(element).on('change', '#item_StaffEmail', function (e) {
        var email = $(this).val();
        var idProcess = $(this).closest('tr').find('input').val();
        $.ajax({
            beforeSend: function (xhr) {
                xhr.setRequestHeader("XSRF-TOKEN",
                    $('input:hidden[name="__RequestVerificationToken"]').val());
            },
            type: "POST",
            url: "TaskProcessPage?handler=AsyncUpdateEmail",
            data: { email: email, Id: idProcess },
            async: true,
        }).done(function () {
            listState.forEach((state) => {
                var termState = state;
                var _href = "/TaskProcessPage?&pageIndex=1&handler=TaskProcessState&state=" + termState.replace("State", "").replace("#", "");
                loadTaskProcess(_href, state);
            });
            $('#ProcessingState')[0].scrollIntoView({
                behavior: 'smooth',
                block: 'center',
                inline: 'center'
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



