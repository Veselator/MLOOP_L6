namespace MLOOP_L6
{
    public enum FactoryType { Industrial, Processing, Manufacturing, Assembly }

    public class Factory : Organisation
    {
        public string FactoryOutputID { get; private set; }
        public FactoryType Type { get; private set; }
        public int ProductionCapacity { get; private set; }
        public bool IsAutomated { get; private set; }
        public decimal RawMaterialCost { get; private set; }

        public Factory() : base()
        {
            FactoryOutputID = "INTEGRA NOOK 37162";
            Type = FactoryType.Manufacturing;
            ProductionCapacity = 1000;
            IsAutomated = false;
            RawMaterialCost = 500000;
        }

        public Factory(string name, int id, int numOfEmployees, string factoryOutputID,
            FactoryType type = FactoryType.Manufacturing, int productionCapacity = 1000,
            bool isAutomated = false, decimal rawMaterialCost = 500000,
            DateTime foundingDate = default, string address = "", decimal annualRevenue = 0)
            : base(name, id, numOfEmployees, foundingDate, address, annualRevenue)
        {
            FactoryOutputID = factoryOutputID;
            Type = type;
            ProductionCapacity = productionCapacity;
            IsAutomated = isAutomated;
            RawMaterialCost = rawMaterialCost;
        }

        public override string GetDetails()
        {
            return $"Фабрика: ID продукції: {FactoryOutputID}, Тип: {Type}, Виробнича потужність: {ProductionCapacity} од./день, Автоматизована: {(IsAutomated ? "Так" : "Ні")}, Вартість сировини: {RawMaterialCost:C}";
        }

        public override decimal CalculateTax()
        {
            decimal baseTax = AnnualRevenue * 0.18m;

            if (IsAutomated)
                baseTax += AnnualRevenue * 0.02m; // Додатковий податок на автоматизовані фабрики

            return baseTax;
        }

        public void UpgradeAutomation()
        {
            if (!IsAutomated)
            {
                IsAutomated = true;
                ProductionCapacity = (int)(ProductionCapacity * 1.5);
                NumOfEmployees = (int)(NumOfEmployees * 0.7); // Скорочення персоналу при автоматизації
            }
        }

        public int CalculateDailyProduction()
        {
            double efficiencyFactor = 1.0;

            if (IsAutomated)
                efficiencyFactor = 1.2;

            if (NumOfEmployees < 10)
                efficiencyFactor *= 0.8;
            else if (NumOfEmployees > 100)
                efficiencyFactor *= 1.1;

            return (int)(ProductionCapacity * efficiencyFactor);
        }

        public override void UpdateRevenue(decimal amount)
        {
            // Фабрики мають особливий розрахунок доходу з урахуванням витрат на сировину
            AnnualRevenue = Math.Max(0, AnnualRevenue + amount - RawMaterialCost * 0.1m);
        }

        public override string ToString()
        {
            return base.ToString() + $", Тип фабрики: {Type}";
        }
    }
}