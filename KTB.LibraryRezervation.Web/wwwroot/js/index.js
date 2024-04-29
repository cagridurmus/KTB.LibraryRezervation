//$('#library-dropdown').change(function () {
//    var libraryDropdownValue = $(this).val();
//    if (!isNaN(parseInt(libraryDropdownValue))) {
//        fetch('/LibraryHall/Index?libraryId=' + libraryDropdownValue)
//            .then(response => response.json())
//            .then(data => {
//                var hallDropdown = $('#hall-dropdown');
//                data.forEach(function (item, index) {
//                    var option = new Option(item.name, item.id);
//                    hallDropdown.append(option);
//                });
//                hallDropdown.toggleClass('invisible', 'visible');
//            });
//    }
//});
//console.log(new Date().toLocaleString());

//console.log(c);
//const tarihElemani = document.getElementById('tarih');
//const saatElemani = document.getElementById('saat');
//guncelleSaatSecenekleri(new Date());
//tarihElemani.addEventListener('change', guncelleSaatSecenekleri);



//const tarihKutulariElemani = document.querySelector('.tarih-kutulari');
//const oncekiButonu = document.getElementById('onceki');
//const ileriButonu = document.getElementById('ileri');

//const bugun = new Date();
//const baslangicTarihi = new Date(bugun.getFullYear(), bugun.getMonth(), bugun.getDate());
//const gunSayisi = 7;

//let aktifSayfa = 1;
//let gosterilenTarihler = [];

//gosterilenTarihleriOluştur(aktifSayfa);

//oncekiButonu.addEventListener('click', () => {
//    //console.log(aktifSayfa);
//    if (aktifSayfa == 2) {
//        oncekiButonu.setAttribute('hidden', false);
//    }
//    if (aktifSayfa > 1) {

//        aktifSayfa--;
//        gosterilenTarihleriOluştur(aktifSayfa);
//    }
//});

//ileriButonu.addEventListener('click', () => {
//    //console.log(aktifSayfa < Math.ceil(gunSayisi / 7));
//    //if (aktifSayfa < Math.ceil(gunSayisi / 7)) {
//    //    aktifSayfa++;
//    //    gosterilenTarihleriOluştur(aktifSayfa);
//    //}
//    oncekiButonu.removeAttribute('hidden');
//    aktifSayfa++;
//    gosterilenTarihleriOluştur(aktifSayfa);
//});



//function changeKutuActive(element) {
//    var element = $(element);
//    var active = $('.tarih-kutusu.active'); 
//    active.removeClass("active");
//    element.addClass("active");
//}

//function gosterilenTarihleriOluştur(sayfa) {
//    const baslangicIndeksi = (sayfa - 1) * 7;
//    const bitisIndeksi = baslangicIndeksi + 7;

//    gosterilenTarihler = [];
//    for (let i = baslangicIndeksi; i < bitisIndeksi; i++) {
//        const tarih = new Date(baslangicTarihi.getTime() + i * 24 * 60 * 60 * 1000);
//        const tarihStr = tarih.toLocaleDateString('tr-TR', { day: 'numeric', month: 'long', year: 'numeric' });
//        gosterilenTarihler.push(`<div value="${tarih}" class="tarih-kutusu"><span>&nbsp;${tarihStr}</span></div>`);
//    }

//    tarihKutulariElemani.innerHTML = gosterilenTarihler.join('');
//}

//tarihKutulariElemani.addEventListener('click', function (e) {
//    changeKutuActive(e.target.parentElement);
//    guncelleSaatSecenekleri(e.target.parentElement.getAttribute('value'));
//})

//function guncelleSaatSecenekleri(secilenTarih) {
//    const saatSecenekleri = [];

//    for (let saat = 9; saat < 18; saat += 3) {
//        const saatStr = saat.toString().padStart(2, '0');
//        var newDate = new Date(secilenTarih);
//        var date = new Date(newDate.getFullYear(), newDate.getMonth(), newDate.getDate(), saat, 00).toLocaleString('en-US', { hour12: false }).toString('MM/dd/yyyy hh:mm:ss');
//        var date2 = new Date(date);
//        date2.setHours(saat + 3);
//        date2 = date2.toLocaleString('en-US', { hour12: false }).toString('MM/dd/yyyy hh:mm:ss');
//        saatSecenekleri.push(`<option startTime="${date}" endTime="${date2}">${date} - ${date2}</option>`);

//    }

//    saatElemani.innerHTML = saatSecenekleri.join('');
//}

//saatElemani.addEventListener("change", function (e) {
//    console.log(e.target);

//    console.log(e.target.getAttribute("endTime"));
//});

//$('#saat').change(function () {
//    var startTime = $(this).find(':selected').attr('startTime')
//    var endTime = $(this).find(':selected').attr('endTime');
//    var hallId = $('.column-desk').attr('id');
//    window.location.href = '/Desk/Index?hallId=' + hallId + '&startTime=' + startTime + '&endTime=' + endTime;
//    //fetch('/Desk/Index?hallId=' + hallId + '&startTime=' + startTime + '&endTime=' + endTime)
//    //    .then(response => window.location.href = response.url);
//})
//$(document).ready(function () {
//    $("#exampleModal").modal('hide');
//})

$('.seat-div').click(function () {
    /*window.location.href = '/Desk/Popup';*/
    var seatId = $(this).attr('id');
    var startTime = $('#saat').find(':selected').attr('startTime');
    var endTime = $('#saat').find(':selected').attr('endTime');
    var email = localStorage.getItem('email');
    //if (success == true) {
    //    $('#exampleModalCenter').appendTo("body").modal('show');
    //}
    //var json = `{
    //    "SeatId": ${x},
    //    "StartTime": ${y},
    //    "EndTime": ${z},
    //    "Email": ${b}
    //}`;

    $.ajax({
        type: "POST",
        url: "/Desk/GetReservationPopup",
        data: { "SeatId": seatId, "StartTime": startTime, "EndTime": endTime, "Email": email },
        success: function (response) {
            //$('.modal-title').text("Rezervasyon eklemek istiyor musunuz?");
            $('.modal-body').text(`${seatId} numaralı koltuğa ${startTime} - ${endTime} tarihleri arasında rezervasyon eklemek istiyor musunuz?`);
            //console.log(response);
            //$("#partialModal").find(".modal-body").html(response);
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
                //$('.modal-title').text("Rezervasyon eklemek istiyor musunuz?");
                $('#save-button').hide();
                $('.modal-body').text(response);
                setTimeout(function () {
                    $("#partialModal").modal('hide');
                }, 5000);
                
                
                //console.log(response);
                //$("#partialModal").find(".modal-body").html(response);
                
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


