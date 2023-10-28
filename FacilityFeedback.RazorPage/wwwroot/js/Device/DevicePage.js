$(function () {
    $("#Problem_Device_RoomId").on("change", function () {
        var roomId = $(this).val();
        $("#Problem_DeviceId").empty();
        $.getJSON(`?handler=Device&roomId=${roomId}`, (data) => {
            $.each(data, function (i, item) {
                $("#Problem_DeviceId").append(`<option value = "${item.value}">${item.text}</option>`);
            });
             
        });
    });


   
}); 