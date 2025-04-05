namespace MLOOP_L6
{
    public class ShipbuildingCompany : Organisation
    {
        public string PortId { get; private set; }

        public ShipbuildingCompany() : base()
        {
            PortId = "UA93303004";
        }
        public ShipbuildingCompany(string name, int id, int numOfEmployees, string portId) : base(name, id, numOfEmployees)
        {
            PortId = portId;
        }

        public override string GetDetails()
        {
            return $"An Shipbuilding Company: port id: {PortId}";
        }
    }
}
