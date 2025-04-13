namespace MLOOP_L6
{
    public abstract class Product
    {
        protected string? title;
        protected DateTime dateOfRelease;
        protected DateTime expiryDate;
        protected double pricePerProduct;
        protected int quantity;
        protected string? country;
        protected string? manufacturerName;

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

        public string? Title
        {
            get { return title; }
            set
            {
                if (value == null) return;
                if (value.Length > 50) return;
                title = value;
            }
        }

        public DateTime DateOfRelease
        {
            get { return dateOfRelease; }
            set { dateOfRelease = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public double PricePerProduct
        {
            get { return pricePerProduct; }
            set
            {
                if (value <= 0.00) return;
                pricePerProduct = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0) return;
                quantity = value;
            }
        }

        public string? Country
        {
            get { return country; }
            set
            {
                if (value == null) return;
                if (value.Length > 30) return;
                country = value;
            }
        }

        public bool IsExpired => GetIsExpired();

        public Product()
        {
            title = "ПРОДУКТ";
            dateOfRelease = DateTime.Now;
            expiryDate = DateTime.Now;
            pricePerProduct = 100;
            quantity = 1;
            country = "Україна";
        }

        public Product(string title, DateTime dateOfRelease, DateTime expiryDate, double pricePerProduct, int quantity = 1, string country = "Україна")
        {
            this.title = title;
            this.dateOfRelease = dateOfRelease;
            this.expiryDate = expiryDate;
            this.pricePerProduct = pricePerProduct;
            this.quantity = quantity;
            this.country = country;
        }

        public abstract double CalculateTotalPrice();

        public virtual double CalculateDiscount() => 0.0;

        public abstract void UpdateExpiryDate(int days);

        public virtual bool GetIsExpired() => expiryDate < DateTime.Now;

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Product)) return false;
            return ToString() == obj.ToString();
        }

        public override string ToString()
        {
            return $"ПРОДУКТ '{title}': ДАТА ВИРОБНИЦТВА: {dateOfRelease}, ВЖИТИ ДО: {expiryDate}, РЕКОМЕНДОВАНА ЦІНА: {pricePerProduct}, КІЛЬКІСТЬ: {quantity}, КРАЇНА: {country}";
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}