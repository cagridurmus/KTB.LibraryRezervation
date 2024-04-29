using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Web.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KTB.LibraryRezervation.Web.Controllers
{
    public class DeskController : Controller
    {
        private readonly DeskApiService _deskService;

        public DeskController(DeskApiService deskService)
        {
            _deskService = deskService;
        }

        public async Task<IActionResult> Index(int hallId, DateTime startTime, DateTime endTime, int sayfa)
        {
            var tarih = DateTime.Today;
            ViewBag.sayfa = sayfa;
            if (DateTime.Now.Hour > 18)
            {
                tarih = tarih.AddDays(1);
            }
            var tarihler = GösterilenTarihleriOluştur(sayfa, hallId, tarih);
            ViewBag.tarihler = tarihler;
            var saatler = SecilenTarihiOluştur(tarih.AddDays(sayfa));
            ViewBag.saatler = saatler;
            ViewBag.HallId = hallId;
            var desks = await _deskService.GetDeskWithHallIdAsync(hallId, saatler[0], saatler[1]);
            return View(desks);
        }

        [HttpPost]
        public IActionResult GetReservationPopup(AddReservationDto model)
        {
            return PartialView("_Popup");
        }

        public static string[] GetDatetimeInDesk(int sayfa, DateTime baslangicTarihi)
        {
            //int baslangicIndeksi = (sayfa);
            //int bitisIndeksi = baslangicIndeksi + 7;
            
            string[] tarihler = new string[7];
            for (int i = 0; i < 7; i++)
            {
                var tarih = baslangicTarihi.AddDays(i).ToString("dd MMMMM yyyy", new CultureInfo("tr-TR"));
                //var tarihStr = DateTime.Parse(tarih);
                tarihler[i] = tarih;
            }

            return tarihler;
        }

        public static string[] GösterilenTarihleriOluştur(int sayfa, int hallId, DateTime baslangicTarihi)
        {
            int baslangicIndeksi = (sayfa);
            int bitisIndeksi = baslangicIndeksi + 7;

            string[] gosterilenTarihler = new string[7];
            for (int i = baslangicIndeksi; i < bitisIndeksi; i++)
            {
                var tarih = baslangicTarihi.AddDays(i);
                if(tarih.DayOfWeek != DayOfWeek.Monday)
                {
                var tarihStr = tarih.ToString("d MMMMM yyyy", new CultureInfo("tr-TR"));
                gosterilenTarihler[i - baslangicIndeksi] = $"<div onclick=\"location.href='/Desk/Index?hallId={hallId}&sayfa={i}'\" value=\"{tarih}\" class=\"tarih-kutusu {(i == baslangicIndeksi ? "active" : "")} \" id=\"kutu\"><span>&nbsp;{tarihStr}</span></div>";
            }
            }

            return gosterilenTarihler;
        }

        public static List<DateTime> SecilenTarihiOluştur(DateTime time)
        {
            //DateTime[] gosterilenSaatler = new DateTime[3];
            var gosterilenSaatler = new List<DateTime>();
            //int saat = 0;
            for (int i = 9; i < 18; i+=3)
            {
                
                var newTime = new DateTime(time.Year, time.Month, time.Day, i, 00, 00);
                if (newTime.CompareTo(DateTime.Now) > 0)
                {
                    gosterilenSaatler.Add(newTime);
                }
                //gosterilenSaatler[saat] += $"<option startTime=\"{newTime}\" endTime=\"${newTime.AddHours(3)}\">{newTime} - {newTime.AddHours(3)}</option>";
                //gosterilenSaatler.Add(newTime);
            }

            return gosterilenSaatler;
        }

    }
}

