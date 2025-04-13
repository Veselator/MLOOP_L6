namespace MLOOP_L6
{
    public interface IProductService
    {
        Product CreateProduct(string title, DateTime releaseDate, DateTime expiryDate, double price);
        MilkProduct CreateMilkProduct(string title, DateTime releaseDate, DateTime expiryDate, double price, string manufacturer, float milkPercentage);
        void PrintProductInfo(Product product);
        List<Product> FilterExpiredProducts(List<Product> products);
        double CalculateTotalValue(List<Product> products);
    }
}