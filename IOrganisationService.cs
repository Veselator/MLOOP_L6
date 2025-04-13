namespace MLOOP_L6
{
    public interface IOrganisationService
    {
        Organisation CreateOrganisation(string type, string name, int id, int employees);
        void DisplayOrganisationDetails(Organisation org);
        decimal CalculateAnnualTaxes(Organisation org);
        void PerformSpecializedAction(Organisation org);
        List<Organisation> FindOrganisationsByEmployeeCount(List<Organisation> organisations, int minCount, int maxCount);
    }
}