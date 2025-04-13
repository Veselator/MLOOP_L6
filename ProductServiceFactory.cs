namespace MLOOP_L6
{
    public abstract class ProductServiceFactory
    {
        public abstract IProductService CreateProductService();
    }

    public class StandardProductServiceFactory : ProductServiceFactory
    {
        public override IProductService CreateProductService()
        {
            return new StandardProductService();
        }
    }

    public class PremiumProductServiceFactory : ProductServiceFactory
    {
        public override IProductService CreateProductService()
        {
            return new PremiumProductService();
        }
    }
}