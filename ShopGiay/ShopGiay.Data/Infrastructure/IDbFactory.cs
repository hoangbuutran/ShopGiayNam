using System;

namespace ShopGiay.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopGiayDbContext Init();
    }
}