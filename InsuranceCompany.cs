namespace MLOOP_L6
{
    public class InsuranceCompany : Organisation
    {
        public int TechPassportId { get; private set; }
        public int PolicyId { get; private set; }

        public InsuranceCompany() : base() 
        {
            TechPassportId = 89654;
            PolicyId = 92200404;
        }
        public InsuranceCompany(string name, int id, int numOfEmployees, int techPassportId, int policyId) : base(name, id, numOfEmployees)
        {
            TechPassportId = techPassportId;
            PolicyId = policyId;
        }

        public override string GetDetails()
        {
            return $"An Insurance Company: tech passport id: {TechPassportId}, policy id: {PolicyId}";
        }
    }
}
