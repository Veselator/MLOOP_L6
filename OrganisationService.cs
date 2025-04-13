namespace MLOOP_L6
{
    public class StandardOrganisationService : IOrganisationService
    {
        public Organisation CreateOrganisation(string type, string name, int id, int employees)
        {
            return type.ToLower() switch
            {
                "factory" => new Factory(name, id, employees, $"PROD-{id}-{DateTime.Now.Year}"),
                "insurance" => new InsuranceCompany(name, id, employees, id + 1000, id + 2000),
                "shipbuilding" => new ShipbuildingCompany(name, id, employees, $"PORT-{id}"),
                _ => throw new ArgumentException("Невідомий тип організації", nameof(type))
            };
        }

        public void DisplayOrganisationDetails(Organisation org)
        {
            Console.WriteLine($"Організація: {org}");
            Console.WriteLine($"Деталі: {org.GetDetails()}");
        }

        public decimal CalculateAnnualTaxes(Organisation org)
        {
            return org.CalculateTax();
        }

        public void PerformSpecializedAction(Organisation org)
        {
            switch (org)
            {
                case Factory factory:
                    Console.WriteLine($"Денне виробництво: {factory.CalculateDailyProduction()} одиниць");
                    break;
                case InsuranceCompany insurance:
                    Console.WriteLine($"Ризиковий резерв: {insurance.CalculateRiskReserve():C}");
                    break;
                case ShipbuildingCompany shipbuilding:
                    Console.WriteLine($"Час будівництва вантажного судна: {shipbuilding.CalculateBuildTime(ShipType.Cargo)} місяців");
                    break;
                default:
                    Console.WriteLine("Невідомий тип організації");
                    break;
            }
        }

        public List<Organisation> FindOrganisationsByEmployeeCount(List<Organisation> organisations, int minCount, int maxCount)
        {
            return organisations.Where(o => o.NumOfEmployees >= minCount && o.NumOfEmployees <= maxCount).ToList();
        }
    }

    public class DetailedOrganisationService : IOrganisationService
    {
        public Organisation CreateOrganisation(string type, string name, int id, int employees)
        {
            DateTime foundingDate = DateTime.Now.AddYears(-new Random().Next(1, 20));
            string[] cities = { "Київ", "Харків", "Одеса", "Львів", "Дніпро" };
            string[] streets = { "Центральна", "Незалежності", "Соборна", "Грушевського", "Шевченка" };
            string address = $"{cities[new Random().Next(cities.Length)]}, вул. {streets[new Random().Next(streets.Length)]}, {new Random().Next(1, 100)}";
            decimal revenue = employees * new Random().Next(10000, 50000);

            return type.ToLower() switch
            {
                "factory" => new Factory(
                    name, id, employees,
                    $"PROD-{id}-{DateTime.Now.Year}",
                    (FactoryType)new Random().Next(4),
                    new Random().Next(500, 5000),
                    new Random().Next(2) == 1,
                    new Random().Next(200000, 2000000),
                    foundingDate, address, revenue),

                "insurance" => new InsuranceCompany(
                    name, id, employees,
                    id + 1000, id + 2000,
                    (InsuranceType)new Random().Next(5),
                    new Random().Next(1000, 100000),
                    new Random().Next(5000000, 100000000),
                    foundingDate, address, revenue),

                "shipbuilding" => new ShipbuildingCompany(
                    name, id, employees,
                    $"PORT-{id}",
                    (ShipType)new Random().Next(4),
                    new Random().Next(5, 50),
                    new Random().Next(1, 10),
                    new Random().Next(10000000, 200000000),
                    foundingDate, address, revenue),

                _ => throw new ArgumentException("Невідомий тип організації", nameof(type))
            };
        }

        public void DisplayOrganisationDetails(Organisation org)
        {
            Console.WriteLine($"=== ДЕТАЛЬНА ІНФОРМАЦІЯ ПРО ОРГАНІЗАЦІЮ ===");
            Console.WriteLine($"Назва: {org.Name}");
            Console.WriteLine($"Ідентифікатор: {org.ID}");
            Console.WriteLine($"Кількість працівників: {org.NumOfEmployees}");
            Console.WriteLine($"Річний дохід: {org.AnnualRevenue:C}");
            Console.WriteLine(org.GetDetails());
            Console.WriteLine($"Податки: {CalculateAnnualTaxes(org):C}");
            Console.WriteLine("=== СПЕЦІАЛІЗОВАНА ІНФОРМАЦІЯ ===");

            switch (org)
            {
                case Factory factory:
                    Console.WriteLine($"Тип фабрики: {factory.Type}");
                    Console.WriteLine($"Виробнича потужність: {factory.ProductionCapacity} од./день");
                    Console.WriteLine($"Автоматизація: {(factory.IsAutomated ? "Так" : "Ні")}");
                    Console.WriteLine($"Вартість сировини: {factory.RawMaterialCost:C}");
                    Console.WriteLine($"Денне виробництво: {factory.CalculateDailyProduction()} одиниць");
                    break;

                case InsuranceCompany insurance:
                    Console.WriteLine($"Основний тип страхування: {insurance.PrimaryType}");
                    Console.WriteLine($"Клієнтська база: {insurance.ClientCount} клієнтів");
                    Console.WriteLine($"Страховий фонд: {insurance.InsuranceFund:C}");
                    Console.WriteLine($"Ризиковий резерв: {insurance.CalculateRiskReserve():C}");
                    break;

                case ShipbuildingCompany shipbuilding:
                    Console.WriteLine($"Спеціалізація: {shipbuilding.Specialization}");
                    Console.WriteLine($"Побудовано суден: {shipbuilding.ShipsBuilt}");
                    Console.WriteLine($"Місткість доків: {shipbuilding.DockCapacity}");
                    Console.WriteLine($"Середня вартість судна: {shipbuilding.AvgShipCost:C}");

                    foreach (ShipType type in Enum.GetValues(typeof(ShipType)))
                    {
                        Console.WriteLine($"Час будівництва судна типу {type}: {shipbuilding.CalculateBuildTime(type)} місяців");
                    }
                    break;

                default:
                    Console.WriteLine("Невідомий тип організації");
                    break;
            }
            Console.WriteLine("==========================================");
        }

        public decimal CalculateAnnualTaxes(Organisation org)
        {
            decimal baseTax = org.CalculateTax();

            // Детальний сервіс враховує додаткові фактори при розрахунку податків
            int yearsOfOperation = DateTime.Now.Year - org.FoundingDate.Year;

            if (yearsOfOperation < 3)
                baseTax *= 0.9m; // Податкові пільги для нових організацій
            else if (yearsOfOperation > 10)
                baseTax *= 1.05m; // Додатковий податок для старих організацій

            if (org.NumOfEmployees > 1000)
                baseTax *= 0.95m; // Знижка для великих роботодавців

            return baseTax;
        }

        public void PerformSpecializedAction(Organisation org)
        {
            switch (org)
            {
                case Factory factory:
                    factory.UpgradeAutomation();
                    Console.WriteLine($"Фабрику {factory.Name} автоматизовано.");
                    Console.WriteLine($"Нова виробнича потужність: {factory.ProductionCapacity} од./день");
                    Console.WriteLine($"Нова кількість працівників: {factory.NumOfEmployees}");
                    break;

                case InsuranceCompany insurance:
                    int newClients = new Random().Next(100, 1000);
                    insurance.AddClients(newClients);
                    Console.WriteLine($"До страхової компанії {insurance.Name} додано {newClients} нових клієнтів.");
                    Console.WriteLine($"Поточна кількість клієнтів: {insurance.ClientCount}");
                    Console.WriteLine($"Оновлений страховий фонд: {insurance.InsuranceFund:C}");
                    break;

                case ShipbuildingCompany shipbuilding:
                    shipbuilding.CompletedShip();
                    Console.WriteLine($"Суднобудівна компанія {shipbuilding.Name} завершила будівництво нового судна.");
                    Console.WriteLine($"Загальна кількість побудованих суден: {shipbuilding.ShipsBuilt}");
                    Console.WriteLine($"Оновлений річний дохід: {shipbuilding.AnnualRevenue:C}");
                    break;

                default:
                    Console.WriteLine("Невідомий тип організації");
                    break;
            }
        }

        public List<Organisation> FindOrganisationsByEmployeeCount(List<Organisation> organisations, int minCount, int maxCount)
        {
            var result = organisations.Where(o => o.NumOfEmployees >= minCount && o.NumOfEmployees <= maxCount).ToList();

            // Сортування за кількістю працівників (від більшого до меншого)
            result.Sort((a, b) => b.NumOfEmployees.CompareTo(a.NumOfEmployees));

            return result;
        }
    }
}