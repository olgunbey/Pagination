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
                int returnUrls= Convert.ToInt16(returnUrl);
                return View(await _urunGetir.ListUrunler(returnUrls));
    
           
        }
        [HttpPost]
        public async Task<IActionResult> Getir(int returnUrl)
        {
            return View(await _urunGetir.ListUrunler(returnUrl));  
        }

        
    }
}
