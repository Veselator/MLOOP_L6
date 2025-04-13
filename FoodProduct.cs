namespace MLOOP_L6
{
    public class FoodProduct : Product
    {
        private bool isOrganic;
        private int caloriesPerServing;

        public bool IsOrganic
        {
            get { return isOrganic; }
            set { isOrganic = value; }
        }

        public int CaloriesPerServing
        {
            get { return caloriesPerServing; }
            set
            {
                if (value < 0) return;
                caloriesPerServing = value;
            }
        }

        public FoodProduct() : base()
        {
            isOrganic = false;
            caloriesPerServing = 100;
        }

        public FoodProduct(string title, DateTime dateOfRelease, DateTime expiryDate, double pricePerProduct,
            int quantity = 1, string country = "Україна", bool isOrganic = false, int caloriesPerServing = 100)
            : base(title, dateOfRelease, expiryDate, pricePerProduct, quantity, country)
        {
            this.isOrganic = isOrganic;
            this.caloriesPerServing = caloriesPerServing;
        }

        public override double CalculateTotalPrice() => pricePerProduct * quantity * (isOrganic ? 1.2 : 1.0); // Якщо без ГМО, то дорожче

        public override void UpdateExpiryDate(int days)
        {
            expiryDate = expiryDate.AddDays(days);
        }

        public override string ToString()
        {
            return base.ToString() + $", ОРГАНІЧНИЙ: {(isOrganic ? "ТАК" : "НІ")}, КАЛОРІЙ: {caloriesPerServing}";
        }
    }
}