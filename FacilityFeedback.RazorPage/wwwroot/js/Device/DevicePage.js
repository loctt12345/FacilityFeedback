$(function () {
    $("#Problem_Device_Room_Id").on("change", function () {
        var roomId = $(this).val();
        $.getJSON(`?handler=Device&roomId=${roomId}`, (data) => {
            $.each(data, function (i, item) {
                console.log("Element: " + item.value + " --- " + item.text);
            });
             
        });
    });

});