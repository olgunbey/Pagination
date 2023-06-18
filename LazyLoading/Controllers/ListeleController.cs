using LazyLoading.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Immutable;

namespace LazyLoading.Controllers
{
    public class ListeleController : Controller
    {
        private readonly IUrunGetir _urunGetir;
       
        private readonly AppDbContext _context;
        public ListeleController(AppDbContext appDbContext, IUrunGetir urunGetir)
        {
            _context = appDbContext;
            _urunGetir = urunGetir;
        }
        [HttpGet]
        public async Task<IActionResult> Getir(string returnUrl)
        {
            var options = new CookieOptions
            {
                // İsteğe bağlı olarak cookie'nin süresini, erişim alanını vb. ayarlayabilirsiniz
                Expires = DateTime.Now.AddDays(1),
                Secure = true,
                HttpOnly = true
            };
            
            int returnUrls= Convert.ToInt16(returnUrl);
           
            if(Request.Cookies.TryGetValue("cookieGiris",out string? value))
            {
                var (urunlers, intReturn, hata) = ((List<Urunler>)null!, returnUrls, "hata");
                ViewResult view = Convert.ToInt16(value) != returnUrls ? View((urunlers, intReturn, hata)) : View(await _urunGetir.ListUrunler(returnUrls));
                return view;
            }
            else
            {
                Response.Cookies.Append("cookieGiris", "0", options); //bu cookie yoksa oluşturur
                return View(await _urunGetir.ListUrunler(returnUrls));
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Getir(int returnUrl)
        {

             string? x = Request.Cookies["cookieGiris"];
            int deger= Convert.ToInt16(x);
            if(deger<=4) Response.Cookies.Append("cookieGiris", (deger + 1).ToString());
            return View(await _urunGetir.ListUrunler(returnUrl));
            
        }

        
    }
}
