namespace MLOOP_L6
{
    public abstract class Organisation
    {
        public string? Name { get; protected set; }
        public int ID { get; protected set;}
        public int NumOfEmployees { get; protected set;}

        public Organisation()
        {
            Name = "Organisation";
            ID = 123456789;
            NumOfEmployees = 2;
        }

        public Organisation(string name, int id, int numOfEmployees)
        {
            Name = name;
            ID = id;
            NumOfEmployees = numOfEmployees;
        }

        public override string ToString()
        {
            return $"{Name}: {ID}, employees: {NumOfEmployees}";
        }

        public abstract string GetDetails();
    }
}
