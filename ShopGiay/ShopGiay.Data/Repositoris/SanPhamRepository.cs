using ShopGiay.Data.Infrastructure;
using ShopGiay.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiay.Data.Repositoris
{
    public interface ISanPhamRepository : IRepository<SAN_PHAM>
    {

    }
    public class SanPhamRepository : RepositoryBase<SAN_PHAM>, ISanPhamRepository
    {
        public SanPhamRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
