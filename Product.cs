namespace MLOOP_L6
{
    public class Product
    {
        protected string? title;
        protected DateTime dateOfRelease;
        protected DateTime expiryDate;
        protected double pricePerProduct;

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

        public bool IsExpired
        {
            get
            {
                return GetIsExpired();
            }
        }

        public Product()
        {
            title = "ПРОДУКТ";
            dateOfRelease = DateTime.Now;
            expiryDate = DateTime.Now;
            pricePerProduct = 100;
        }

        public Product(string title, DateTime dateOfRelease, DateTime expiryDate, double pricePerProduct)
        {
            this.title = title;
            this.dateOfRelease = dateOfRelease;
            this.expiryDate = expiryDate;
            this.pricePerProduct = pricePerProduct;
        }

        virtual public bool GetIsExpired()
        {
            return expiryDate < DateTime.Now;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Product)) return false;
            return ToString() == obj.ToString();
        }

        public override string ToString()
        {
            return $"ПРОДУКТ '{title}': ДАТА ВИРОБНИЦТВА: {dateOfRelease}, ВЖИТИ ДО: {expiryDate}, РЕКОМЕНДОВАНА ЦІНА: {pricePerProduct}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
