$('#my-reservations').click(function () {
    
    var email = localStorage.getItem('email');
    console.log(email);
    if (email != null) {
        $.ajax({
            type: "GET",
            url: "/Reservation/MyReservations?email=" + email,
            success: function (response) {
                window.location.href = '/Reservation/MyReservations?email=' + email;
                
                //window.location.href = response.url;
            },
            failure: function (response) {
                //window.location.href = '/Home/Login'
            },
            error: function (response) {
                //window.location.href = '/Home/Login'
            }
        });
    }

});