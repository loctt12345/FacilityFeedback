$(function () {

    var loadDeviceSelectList = function (roomId) {
        $("#Problem_DeviceId").empty();
        $.getJSON(`?handler=Device&roomId=${roomId}`, (data) => {
            $.each(data, function (i, item) {
                $("#Problem_DeviceId").append(`<option value = "${item.value}">${item.text}</option>`);
            });

        });

    };

    //On load
    var roomId = $("#Problem_Device_RoomId option:selected").val();
    loadDeviceSelectList(roomId);

    //On change
    $("#Problem_Device_RoomId").on("change", function () {
        var roomId = $(this).val();
        loadDeviceSelectList(roomId);

    });
    






}); 