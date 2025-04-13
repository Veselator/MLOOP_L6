namespace MLOOP_L6
{
    public abstract class Organisation
    {
        public string? Name { get; protected set; }
        public int ID { get; protected set; }
        public int NumOfEmployees { get; protected set; }
        public DateTime FoundingDate { get; protected set; }
        public string? Address { get; protected set; }
        public decimal AnnualRevenue { get; protected set; }

        public Organisation()
        {
            Name = "Organisation";
            ID = 123456789;
            NumOfEmployees = 2;
            FoundingDate = DateTime.Now.AddYears(-5);
            Address = "Київ, вул. Хрещатик, 1";
            AnnualRevenue = 1000000;
        }

        public Organisation(string name, int id, int numOfEmployees, DateTime foundingDate = default, string address = "", decimal annualRevenue = 0)
        {
            Name = name;
            ID = id;
            NumOfEmployees = numOfEmployees;
            FoundingDate = foundingDate == default ? DateTime.Now.AddYears(-5) : foundingDate;
            Address = string.IsNullOrEmpty(address) ? "Київ, вул. Хрещатик, 1" : address;
            AnnualRevenue = annualRevenue == 0 ? 1000000 : annualRevenue;
        }

        public override string ToString()
        {
            return $"{Name}: ID {ID}, Працівників: {NumOfEmployees}, Заснована: {FoundingDate.ToShortDateString()}, Адреса: {Address}, Річний дохід: {AnnualRevenue:C}";
        }

        public abstract string GetDetails();

        public abstract decimal CalculateTax();

        public virtual void HireEmployees(int count)
        {
            if (count <= 0) return;
            NumOfEmployees += count;
        }

        public virtual void FireEmployees(int count)
        {
            if (count <= 0 || count >= NumOfEmployees) return;
            NumOfEmployees -= count;
        }

        public abstract void UpdateRevenue(decimal amount);
    }
}