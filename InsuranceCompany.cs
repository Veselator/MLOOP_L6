namespace MLOOP_L6
{
    public enum InsuranceType { Life, Health, Property, Vehicle, Business }

    public class InsuranceCompany : Organisation
    {
        public int TechPassportId { get; private set; }
        public int PolicyId { get; private set; }
        public InsuranceType PrimaryType { get; private set; }
        public int ClientCount { get; private set; }
        public decimal InsuranceFund { get; private set; }

        public InsuranceCompany() : base()
        {
            TechPassportId = 89654;
            PolicyId = 92200404;
            PrimaryType = InsuranceType.Health;
            ClientCount = 5000;
            InsuranceFund = 10000000;
        }

        public InsuranceCompany(string name, int id, int numOfEmployees, int techPassportId, int policyId,
            InsuranceType primaryType = InsuranceType.Health, int clientCount = 5000, decimal insuranceFund = 10000000,
            DateTime foundingDate = default, string address = "", decimal annualRevenue = 0)
            : base(name, id, numOfEmployees, foundingDate, address, annualRevenue)
        {
            TechPassportId = techPassportId;
            PolicyId = policyId;
            PrimaryType = primaryType;
            ClientCount = clientCount;
            InsuranceFund = insuranceFund;
        }

        public override string GetDetails()
        {
            return $"Страхова компанія: ID техпаспорту: {TechPassportId}, ID поліса: {PolicyId}, Основний тип страхування: {PrimaryType}, Клієнтів: {ClientCount}, Страховий фонд: {InsuranceFund:C}";
        }

        public override decimal CalculateTax()
        {
            // Страхові компанії мають спеціальну ставку податку
            return AnnualRevenue * 0.15m;
        }

        public decimal CalculateRiskReserve()
        {
            decimal baseReserve = InsuranceFund * 0.3m;

            switch (PrimaryType)
            {
                case InsuranceType.Life:
                    return baseReserve * 1.5m;
                case InsuranceType.Health:
                    return baseReserve * 1.3m;
                case InsuranceType.Vehicle:
                    return baseReserve * 1.2m;
                default:
                    return baseReserve;
            }
        }

        public void AddClients(int count)
        {
            if (count <= 0) return;
            ClientCount += count;
            InsuranceFund += count * 5000; // Середній внесок на клієнта
        }

        public bool ProcessClaim(decimal amount)
        {
            if (amount <= 0 || amount > InsuranceFund * 0.1m)
                return false;

            InsuranceFund -= amount;
            return true;
        }

        public override void UpdateRevenue(decimal amount)
        {
            AnnualRevenue = Math.Max(0, AnnualRevenue + amount);
            InsuranceFund += amount * 0.5m; // 50% доходу йде у страховий фонд
        }

        public override string ToString()
        {
            return base.ToString() + $", Тип страхування: {PrimaryType}, Клієнтів: {ClientCount}";
        }
    }
}