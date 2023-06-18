namespace LazyLoading.Models
{
    public interface IUrunGetir
    {
        public Task<(List<Urunler>,int,string)> ListUrunler(int returnUrl);
    }
}
