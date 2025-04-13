namespace MLOOP_L6
{
    public class StandardProductService : IProductService
    {
        public Product CreateProduct(string title, DateTime releaseDate, DateTime expiryDate, double price)
        {
            return new FoodProduct(title, releaseDate, expiryDate, price);
        }

        public MilkProduct CreateMilkProduct(string title, DateTime releaseDate, DateTime expiryDate, double price, string manufacturer, float milkPercentage)
        {
            return new MilkProduct(title, releaseDate, expiryDate, price, manufacturer, milkPercentage);
        }

        public void PrintProductInfo(Product product)
        {
            Console.WriteLine($" {product} НЕПРИДАТНИЙ: {(product.IsExpired ? "ТАК" : "НІ")}");
        }

        public List<Product> FilterExpiredProducts(List<Product> products)
        {
            return products.Where(p => p.IsExpired).ToList();
        }

        public double CalculateTotalValue(List<Product> products)
        {
            return products.Sum(p => p.CalculateTotalPrice());
        }
    }

    public class PremiumProductService : IProductService
    {
        public Product CreateProduct(string title, DateTime releaseDate, DateTime expiryDate, double price)
        {
            return new FoodProduct(title, releaseDate, expiryDate, price * 1.2, isOrganic: true);
        }

        public MilkProduct CreateMilkProduct(string title, DateTime releaseDate, DateTime expiryDate, double price, string manufacturer, float milkPercentage)
        {
            return new MilkProduct(title, releaseDate, expiryDate, price * 1.3, manufacturer, milkPercentage, isOrganic: true, isLactoseFree: true);
        }

        public void PrintProductInfo(Product product)
        {
            Console.WriteLine($" ПРЕМІУМ-ПРОДУКТ: {product} НЕПРИДАТНИЙ: {(product.IsExpired ? "ТАК" : "НІ")}");

            if (product is MilkProduct milkProduct)
            {
                Console.WriteLine($" Додаткова інформація: {milkProduct.GetMilkInfo()}");
            }
        }

        public List<Product> FilterExpiredProducts(List<Product> products)
        {
            DateTime nearExpiry = DateTime.Now.AddDays(5);
            return products.Where(p => p.IsExpired || p.ExpiryDate <= nearExpiry).ToList();
        }

        public double CalculateTotalValue(List<Product> products)
        {
            double total = 0;
            foreach (var product in products)
            {
                double price = product.CalculateTotalPrice();
                double discount = product.CalculateDiscount();
                total += price * (1 - discount);
            }
            return total;
        }
    }
}