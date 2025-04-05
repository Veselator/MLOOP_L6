namespace MLOOP_L6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Завдання №1.5

            Product[] products = 
            [
                new Product("Яблука Ред Чіф", new DateTime(2025, 4, 2), new DateTime(2040, 8, 9), 52.90),
                new MilkProduct("Молоко 1л", new DateTime(2025, 4, 2), new DateTime(2025, 4, 5), 31.50, "Формула смаку", 1f),
                new Product("Сік Садочок Яблуко-виноград 1л", new DateTime(2025, 2, 2), new DateTime(2150, 4, 3), 49.40),
                new MilkProduct("Йогурт Активія 1л", new DateTime(2025, 4, 1), new DateTime(2025, 4, 12), 84.40, "Формула смаку", 0.65f),
            ];

            foreach (Product someProduct in products)
            {
                Console.WriteLine(" " + someProduct.ToString() + $" НЕПРИДАТНИЙ: {(someProduct.IsExpired ? "ТАК" : "НІ")}");
            }

            // Завдання №2.5

            Organisation[] organisations = new Organisation[6];

            organisations[0] = new Factory("Завод Металоконструкцій", 100123, 850, "ZMK-7734");
            organisations[1] = new ShipbuildingCompany("Верф Одеса", 200456, 1200, "PORT-A9241");
            organisations[2] = new InsuranceCompany("СтрахІнвест", 300789, 320, 77665, 81234567);
            organisations[3] = new Factory("ТехноПром", 400234, 630, "TPR-2208");
            organisations[4] = new ShipbuildingCompany("МорБуд", 500567, 980, "PORT-M5892");
            organisations[5] = new InsuranceCompany("НадійнийЗахист", 600890, 250, 88776, 93456789);

            Array.Sort(organisations, (x, y) => x.NumOfEmployees.CompareTo(y.NumOfEmployees));

            Console.WriteLine("\n Інформація про організації, відсортована за зростанням кількості співробітників:");
            foreach (var org in organisations)
            {
                Console.WriteLine("\n " + org.ToString());
                Console.WriteLine(" Деталі: " + org.GetDetails() + "\n");
            }

            Console.ReadLine();
        }
    }
}
