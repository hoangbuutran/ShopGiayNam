using ShopGiay.Data.Infrastructure;
using ShopGiay.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiay.Data.Repositoris
{
    public interface ILoaiSanPhamRepository: IRepository<LOAI_SAN_PHAM>
    {

    }
    public class LoaiSanPhamRepository : RepositoryBase<LOAI_SAN_PHAM>, ILoaiSanPhamRepository
    {
        public LoaiSanPhamRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
}
