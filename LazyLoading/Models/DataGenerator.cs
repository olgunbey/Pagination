namespace LazyLoading.Models
{
    public static class DataGenerator
    {
        public static IEnumerable<Urunler> UrunlerGenerator()
        {
            for (int i = 1; i <= 40; i++)
            {
                yield return new Urunler() { ID = i, Fiyat = 200 + i, UrunAdi = $"Urun{i}" };
            }
        }
    }
}
