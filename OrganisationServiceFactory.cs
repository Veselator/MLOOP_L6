namespace MLOOP_L6
{
    public abstract class OrganisationServiceFactory
    {
        public abstract IOrganisationService CreateOrganisationService();
    }

    public class StandardOrganisationServiceFactory : OrganisationServiceFactory
    {
        public override IOrganisationService CreateOrganisationService()
        {
            return new StandardOrganisationService();
        }
    }

    public class DetailedOrganisationServiceFactory : OrganisationServiceFactory
    {
        public override IOrganisationService CreateOrganisationService()
        {
            return new DetailedOrganisationService();
        }
    }
}