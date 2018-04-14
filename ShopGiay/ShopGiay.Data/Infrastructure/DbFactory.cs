namespace ShopGiay.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopGiayDbContext dbContext;

        public ShopGiayDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopGiayDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}