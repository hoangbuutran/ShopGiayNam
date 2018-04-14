using ShopGiay.Data.Infrastructure;
using ShopGiay.Model.Model;


namespace ShopGiay.Data.Repositories
{
    public interface IThuongHieuRepository : IRepository<THUONG_HIEU>
    {
    }

    public class ThuongHieuRepository : RepositoryBase<THUONG_HIEU>, IThuongHieuRepository
    {
        public ThuongHieuRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}