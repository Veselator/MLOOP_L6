namespace MLOOP_L6
{
    public class MilkProduct : FoodProduct
    {
        private string? manufacturerName;
        private float percentageOfMilk;
        private bool isLactoseFree;
        private string? milkType;
        private float fatContent;

        public string? ManufacturerName
        {
            get { return manufacturerName; }
            set
            {
                if (value == null) return;
                if (value.Length > 70) return;
                manufacturerName = value;
            }
        }

        public float PercentageOfMilk
        {
            get { return percentageOfMilk; }
            set
            {
                if (value > 0.00f && value <= 1.00f) percentageOfMilk = value;
            }
        }

        public bool IsLactoseFree
        {
            get { return isLactoseFree; }
            set { isLactoseFree = value; }
        }

        public string? MilkType
        {
            get { return milkType; }
            set
            {
                if (value == null) return;
                if (value.Length > 30) return;
                milkType = value;
            }
        }

        public float FatContent
        {
            get { return fatContent; }
            set
            {
                if (value >= 0.0f && value <= 1.0f) fatContent = value;
            }
        }

        public MilkProduct() : base()
        {
            manufacturerName = "Формула смаку";
            percentageOfMilk = 0.24f;
            isLactoseFree = false;
            milkType = "Коров'яче";
            fatContent = 0.035f;
        }

        public MilkProduct(string title, DateTime dateOfRelease, DateTime expiryDate, double pricePerProduct,
            string manufacturerName, float percentageOfMilk, int quantity = 1, string country = "Україна",
            bool isOrganic = false, int caloriesPerServing = 100, bool isLactoseFree = false,
            string milkType = "Коров'яче", float fatContent = 0.035f)
            : base(title, dateOfRelease, expiryDate, pricePerProduct, quantity, country, isOrganic, caloriesPerServing)
        {
            this.manufacturerName = manufacturerName;
            this.percentageOfMilk = Math.Clamp(percentageOfMilk, 0.0f, 1.0f);
            this.isLactoseFree = isLactoseFree;
            this.milkType = milkType;
            this.fatContent = Math.Clamp(fatContent, 0.0f, 1.0f);
        }

        public override double CalculateTotalPrice()
        {
            double basePrice = base.CalculateTotalPrice();
            double additionalFactor = 1.0;

            if (isLactoseFree) additionalFactor += 0.15;
            if (fatContent < 0.01f) additionalFactor += 0.1;  // Безжирні продукти дорожчі

            return basePrice * additionalFactor;
        }

        public override double CalculateDiscount()
        {
            // Більша знижка для продуктів, що швидко псуються
            TimeSpan timeUntilExpiry = expiryDate - DateTime.Now;
            if (timeUntilExpiry.TotalDays < 2) return 0.3;
            if (timeUntilExpiry.TotalDays < 5) return 0.15;
            return 0.0;
        }

        public override void UpdateExpiryDate(int days)
        {
            // Молочні продукти мають обмежений термін придатності
            int maxAddDays = 7;
            expiryDate = expiryDate.AddDays(Math.Min(days, maxAddDays));
        }

        public override bool GetIsExpired()
        {
            // Додаткова перевірка для молочних продуктів
            if (base.GetIsExpired()) return true;

            // Якщо залишилось менше 12 годин до закінчення терміну, вважаємо продукт непридатним
            TimeSpan timeUntilExpiry = expiryDate - DateTime.Now;
            return timeUntilExpiry.TotalHours < 12;
        }

        public string GetMilkInfo() => $"Тип молока: {milkType}, Вміст жиру: {fatContent * 100}%";

        public override string ToString()
        {
            return base.ToString() + $", ВИРОБНИК: {manufacturerName}, ПРОЦЕНТ ВМІСТУ МОЛОКА: {percentageOfMilk}, БЕЗ ЛАКТОЗИ: {(isLactoseFree ? "ТАК" : "НІ")}, ТИП МОЛОКА: {milkType}, ВМІСТ ЖИРУ: {fatContent * 100}%";
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}