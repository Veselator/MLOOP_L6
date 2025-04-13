// Program.cs
namespace MLOOP_L6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ЗАВДАННЯ №6.1
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Створення фабрик
            ProductServiceFactory standardFactory = new StandardProductServiceFactory();
            ProductServiceFactory premiumFactory = new PremiumProductServiceFactory();

            // Отримання сервісів з фабрик
            IProductService standardService = standardFactory.CreateProductService();
            IProductService premiumService = premiumFactory.CreateProductService();

            // Створення продуктів за допомогою стандартного сервісу
            Console.WriteLine("=== СТАНДАРТНІ ПРОДУКТИ ===");
            List<Product> standardProducts = new List<Product>
            {
                standardService.CreateProduct("Яблука Ред Чіф", new DateTime(2025, 4, 2), new DateTime(2025, 8, 9), 52.90),
                standardService.CreateMilkProduct("Молоко 1л", new DateTime(2025, 4, 2), new DateTime(2025, 4, 5), 31.50, "Формула смаку", 1f),
                standardService.CreateProduct("Сік Садочок Яблуко-виноград 1л", new DateTime(2025, 2, 2), new DateTime(2025, 4, 30), 49.40),
                standardService.CreateMilkProduct("Йогурт Активія 1л", new DateTime(2025, 4, 1), new DateTime(2025, 4, 12), 84.40, "Формула смаку", 0.65f),
            };

            foreach (Product product in standardProducts)
            {
                standardService.PrintProductInfo(product);
            }

            Console.WriteLine($"\nЗагальна вартість стандартних продуктів: {standardService.CalculateTotalValue(standardProducts):F2} грн");

            // Створення продуктів за допомогою преміум сервісу
            Console.WriteLine("\n=== ПРЕМІУМ ПРОДУКТИ ===");
            List<Product> premiumProducts = new List<Product>
            {
                premiumService.CreateProduct("Органічні яблука Голден", new DateTime(2025, 4, 10), new DateTime(2025, 4, 30), 79.90),
                premiumService.CreateMilkProduct("Біо-молоко без лактози 0.9л", new DateTime(2025, 4, 11), new DateTime(2025, 4, 18), 62.50, "Органік Фарм", 0.98f),
                premiumService.CreateProduct("Органічний сік мультифрукт 1л", new DateTime(2025, 4, 9), new DateTime(2025, 5, 15), 89.90),
                premiumService.CreateMilkProduct("Преміум йогурт грецький 500г", new DateTime(2025, 4, 12), new DateTime(2025, 4, 20), 115.40, "Органік Фарм", 0.85f),
            };

            foreach (Product product in premiumProducts)
            {
                premiumService.PrintProductInfo(product);
            }

            Console.WriteLine($"\nЗагальна вартість преміум продуктів: {premiumService.CalculateTotalValue(premiumProducts):F2} грн");

            // Перевірка на термін придатності
            Console.WriteLine("\n=== ПРОСТРОЧЕНІ ПРОДУКТИ ===");

            // Встановлюємо деякі продукти як прострочені для демонстрації
            standardProducts[1].UpdateExpiryDate(-10);  // Робимо молоко простроченим
            premiumProducts[0].UpdateExpiryDate(-5);    // Робимо яблука простроченими

            var expiredStandard = standardService.FilterExpiredProducts(standardProducts);
            var expiredPremium = premiumService.FilterExpiredProducts(premiumProducts);

            Console.WriteLine("Стандартні прострочені продукти:");
            foreach (var product in expiredStandard)
            {
                standardService.PrintProductInfo(product);
            }

            Console.WriteLine("\nПреміум прострочені продукти:");
            foreach (var product in expiredPremium)
            {
                premiumService.PrintProductInfo(product);
            }

            // Демонстрація застосування знижок
            Console.WriteLine("\n=== ЗНИЖКИ НА МОЛОЧНІ ПРОДУКТИ ===");
            foreach (var product in standardProducts.OfType<MilkProduct>())
            {
                double discount = product.CalculateDiscount();
                if (discount > 0)
                {
                    Console.WriteLine($" {product.Title} - знижка: {discount * 100}%, ціна зі знижкою: {product.CalculateTotalPrice() * (1 - discount):F2} грн");
                }
            }
            

            // ЗАВДАННЯ №6.2
            OrganisationServiceFactory orgStandardFactory = new StandardOrganisationServiceFactory();
            OrganisationServiceFactory orgDetailedFactory = new DetailedOrganisationServiceFactory();

            // Отримання сервісів з фабрик
            IOrganisationService orgStandardService = orgStandardFactory.CreateOrganisationService();
            IOrganisationService orgDetailedService = orgDetailedFactory.CreateOrganisationService();

            // Створення організацій за допомогою стандартного сервісу
            Console.WriteLine("=== СТАНДАРТНІ ОРГАНІЗАЦІЇ ===");
            List<Organisation> standardOrgs = new List<Organisation>
            {
                orgStandardService.CreateOrganisation("factory", "ЗавтехМаш", 101, 250),
                orgStandardService.CreateOrganisation("insurance", "УкрСтрах", 202, 75),
                orgStandardService.CreateOrganisation("shipbuilding", "МорФлот", 303, 500),
                orgStandardService.CreateOrganisation("factory", "АгроТех", 404, 180),
            };

            foreach (Organisation org in standardOrgs)
            {
                orgStandardService.DisplayOrganisationDetails(org);
                Console.WriteLine($"Річний податок: {orgStandardService.CalculateAnnualTaxes(org):C}");
                orgStandardService.PerformSpecializedAction(org);
                Console.WriteLine();
            }

            // Створення організацій за допомогою детального сервісу
            Console.WriteLine("\n=== ДЕТАЛЬНІ ОРГАНІЗАЦІЇ ===");
            List<Organisation> detailedOrgs = new List<Organisation>
            {
                orgDetailedService.CreateOrganisation("factory", "НовіТехнології", 501, 1200),
                orgDetailedService.CreateOrganisation("insurance", "ЄвроЗахист", 602, 320),
                orgDetailedService.CreateOrganisation("shipbuilding", "Суднобудівник", 703, 850),
                orgDetailedService.CreateOrganisation("insurance", "ГлобалСтрах", 804, 125),
            };

            foreach (Organisation org in detailedOrgs)
            {
                orgDetailedService.DisplayOrganisationDetails(org);
                orgDetailedService.PerformSpecializedAction(org);
                Console.WriteLine();
            }

            // Пошук організацій за кількістю працівників
            Console.WriteLine("\n=== ОРГАНІЗАЦІЇ З КІЛЬКІСТЮ ПРАЦІВНИКІВ ВІД 200 ДО 1000 ===");
            List<Organisation> allOrgs = new List<Organisation>();
            allOrgs.AddRange(standardOrgs);
            allOrgs.AddRange(detailedOrgs);

            List<Organisation> filteredOrgs = orgDetailedService.FindOrganisationsByEmployeeCount(allOrgs, 200, 1000);

            foreach (Organisation org in filteredOrgs)
            {
                Console.WriteLine($"{org.Name}: {org.NumOfEmployees} працівників");
            }

            // Демонстрація унікальних функцій кожного типу організації
            Console.WriteLine("\n=== УНІКАЛЬНІ ФУНКЦІЇ ОРГАНІЗАЦІЙ ===");

            // Фабрика
            Factory factory = (Factory)detailedOrgs[0];
            Console.WriteLine($"Демонстрація функцій фабрики '{factory.Name}':");
            factory.UpgradeAutomation();
            Console.WriteLine($"Автоматизація: {(factory.IsAutomated ? "Так" : "Ні")}");
            Console.WriteLine($"Нова виробнича потужність: {factory.CalculateDailyProduction()} од./день");

            // Страхова компанія
            InsuranceCompany insurance = (InsuranceCompany)detailedOrgs[1];
            Console.WriteLine($"\nДемонстрація функцій страхової компанії '{insurance.Name}':");
            insurance.AddClients(500);
            Console.WriteLine($"Клієнтська база після додавання клієнтів: {insurance.ClientCount}");
            bool claimResult = insurance.ProcessClaim(100000);
            Console.WriteLine($"Результат обробки страхової вимоги: {(claimResult ? "Успішно" : "Відхилено")}");

            // Суднобудівна компанія
            ShipbuildingCompany shipbuilding = (ShipbuildingCompany)detailedOrgs[2];
            Console.WriteLine($"\nДемонстрація функцій суднобудівної компанії '{shipbuilding.Name}':");
            decimal projectCost = shipbuilding.EstimateProjectCost(ShipType.Military, 5000);
            Console.WriteLine($"Оцінка вартості військового судна (5000 тонн): {projectCost:C}");
            Console.WriteLine($"Час будівництва: {shipbuilding.CalculateBuildTime(ShipType.Military)} місяців");
            shipbuilding.CompletedShip();
            Console.WriteLine($"Загальна кількість побудованих суден після завершення нового: {shipbuilding.ShipsBuilt}");

            Console.ReadLine();
        }
    }
}