namespace MLOOP_L6
{
    public enum ShipType { Cargo, Passenger, Military, Research }

    public class ShipbuildingCompany : Organisation
    {
        public string PortId { get; private set; }
        public ShipType Specialization { get; private set; }
        public int ShipsBuilt { get; private set; }
        public int DockCapacity { get; private set; }
        public decimal AvgShipCost { get; private set; }

        public ShipbuildingCompany() : base()
        {
            PortId = "UA93303004";
            Specialization = ShipType.Cargo;
            ShipsBuilt = 12;
            DockCapacity = 3;
            AvgShipCost = 50000000;
        }

        public ShipbuildingCompany(string name, int id, int numOfEmployees, string portId,
            ShipType specialization = ShipType.Cargo, int shipsBuilt = 12, int dockCapacity = 3, decimal avgShipCost = 50000000,
            DateTime foundingDate = default, string address = "", decimal annualRevenue = 0)
            : base(name, id, numOfEmployees, foundingDate, address, annualRevenue)
        {
            PortId = portId;
            Specialization = specialization;
            ShipsBuilt = shipsBuilt;
            DockCapacity = dockCapacity;
            AvgShipCost = avgShipCost;
        }

        public override string GetDetails()
        {
            return $"Суднобудівна компанія: ID порту: {PortId}, Спеціалізація: {Specialization}, Побудовано суден: {ShipsBuilt}, Місткість доків: {DockCapacity}, Середня вартість судна: {AvgShipCost:C}";
        }

        public override decimal CalculateTax()
        {
            decimal baseTax = AnnualRevenue * 0.2m;

            // Податкові пільги для військових суднобудівників
            if (Specialization == ShipType.Military)
                baseTax *= 0.8m;

            return baseTax;
        }

        public decimal EstimateProjectCost(ShipType shipType, int tonnage)
        {
            decimal baseCost = AvgShipCost;

            switch (shipType)
            {
                case ShipType.Military:
                    baseCost *= 1.5m;
                    break;
                case ShipType.Research:
                    baseCost *= 1.3m;
                    break;
                case ShipType.Passenger:
                    baseCost *= 1.2m;
                    break;
            }

            return baseCost * (tonnage / 1000m);
        }

        public int CalculateBuildTime(ShipType shipType)
        {
            int baseMonths = 12;

            switch (shipType)
            {
                case ShipType.Military:
                    return baseMonths * 2;
                case ShipType.Research:
                    return baseMonths * 3 / 2;
                case ShipType.Passenger:
                    return baseMonths * 4 / 3;
                default:
                    return baseMonths;
            }
        }

        public void CompletedShip()
        {
            ShipsBuilt++;
            UpdateRevenue(AvgShipCost * 1.2m); // Прибуток від продажу судна
        }

        public override void UpdateRevenue(decimal amount)
        {
            AnnualRevenue = Math.Max(0, AnnualRevenue + amount);

            // Збільшення оцінки вартості суден на основі збільшення доходу
            if (amount > 0)
                AvgShipCost *= 1 + (amount / (AnnualRevenue * 10));
        }

        public override string ToString()
        {
            return base.ToString() + $", Спеціалізація: {Specialization}, Побудовано суден: {ShipsBuilt}";
        }
    }
}