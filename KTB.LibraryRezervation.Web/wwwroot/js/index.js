
$('.seat-div').click(function () {
    var seatId = $(this).attr('id');
    var startTime = $('#saat').find(':selected').attr('startTime');
    var endTime = $('#saat').find(':selected').attr('endTime');
    var email = localStorage.getItem('email');

    $.ajax({
        type: "POST",
        url: "/Desk/GetReservationPopup",
        data: { "SeatId": seatId, "StartTime": startTime, "EndTime": endTime, "Email": email },
        success: function (response) {
            $('.modal-body').text(`${seatId} numaralı koltuğa ${startTime} - ${endTime} tarihleri arasında rezervasyon eklemek istiyor musunuz?`);

            $("#partialModal").modal('show');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
    $('#save-button').click(function () {
        $.ajax({
            type: "POST",
            url: "/Reservation/Add",
            data: { "SeatId": seatId, "StartTime": startTime, "EndTime": endTime, "Email": email },
            success: function (response) {
                $('#save-button').hide();
                $('.modal-body').text(response);
                setTimeout(function () {
                    $("#partialModal").modal('hide');
                }, 5000);
                
                
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});


const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7216/seathub", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
    })
    .build();

connection.start()
    .then(function () {
        console.log("xxx");
    })
    .catch(function (error) {
        console.error(error);
    });

connection.on("SeatRezerv", function (hallId, seatId, message) {
    const url = window.location.search;
    const params = new URLSearchParams(url);

    const hallId1 = params.get('hallId');

    alert(`${hallId1} numaralı salonda ${seatId} ${message}`);
    var i = $(`#${seatId}.seat-div i`);
    i.removeClass('seat-blue');
    i.addClass('seat-red');
});