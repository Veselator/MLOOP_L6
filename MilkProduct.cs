namespace MLOOP_L6
{
    public class MilkProduct : Product
    {
        private string? manufacturerName;
        private float percentageOfMilk;

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
                if(value > 0.00f && value < 1.00f) percentageOfMilk = value;
            }
        }

        public MilkProduct() : base()
        {
            manufacturerName = "Formula smaku";
            percentageOfMilk = 0.24f;
        }

        public MilkProduct(string title, DateTime dateOfRelease, DateTime expiryDate, double pricePerProduct, string manufacturerName, float percentageOfMilk) : base(title, dateOfRelease, expiryDate, pricePerProduct)
        {
            this.manufacturerName = manufacturerName;
            this.percentageOfMilk = Math.Clamp(percentageOfMilk, 0.0f, 1.0f);
        }

        public override string ToString()
        {
            return base.ToString() + $" ВИРОБНИК: {manufacturerName}, ПРОЦЕНТ ВМІСТУ МОЛОКА: {percentageOfMilk}";
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
