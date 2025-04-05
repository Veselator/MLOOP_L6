namespace MLOOP_L6
{
    public class Factory : Organisation
    {
        public string FactoryOutputID { get; private set; }

        public Factory() : base()
        {
            FactoryOutputID = "INTEGRA NOOK 37162";
        }

        public Factory(string name, int id, int numOfEmployees, string factoryOutputID) : base(name, id, numOfEmployees)
        {
            FactoryOutputID = factoryOutputID;
        }

        public override string GetDetails()
        {
            return $"An Factory: factory product ID: {FactoryOutputID}";
        }
    }
}
