using Microsoft.EntityFrameworkCore;

namespace LazyLoading.Models
{
    public class UrunGetir : IUrunGetir
    {
        private readonly AppDbContext _appDbContext;
        public UrunGetir(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public async Task<(List<Urunler>, int,string)> ListUrunler(int returnUrl)
        {
  
            Lazy<List<Urunler>> _lazlyData = new Lazy<List<Urunler>>(await _appDbContext.Set<Urunler>().ToListAsync());

            int sayfaMiktari = (_lazlyData.Value.Count / 10);
            string hata = returnUrl >= sayfaMiktari ? "geçersiz!" : null;
            int skipUrl;
            return (_lazlyData.Value.Skip(skipUrl = returnUrl == 0 ? 0 : (returnUrl * 10)).Take(10).ToList(),returnUrl+=1,hata);
        }
    }
}
