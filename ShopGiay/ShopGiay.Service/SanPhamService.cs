using ShopGiay.Data.Infrastructure;
using ShopGiay.Data.Repositoris;
using ShopGiay.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiay.Service
{
    public interface ISanPhamService
    {
        SAN_PHAM Add(SAN_PHAM sanPham);
        void Update(SAN_PHAM sanPham);
        void Delete(int id);
        IEnumerable<SAN_PHAM> GetAll();
        SAN_PHAM GetById(int id);
        void SaveChange();
    }

    public class SanPhamService : ISanPhamService
    {
        ISanPhamRepository _sanPhamRepository;
        IUnitOfWork _unitOfWork;
        public SanPhamService(ISanPhamRepository sanPhamRepository, IUnitOfWork unitOfWork)
        {
            this._sanPhamRepository = sanPhamRepository;
            this._unitOfWork = unitOfWork;
        }

        public SAN_PHAM Add(SAN_PHAM sanPham)
        {
            return _sanPhamRepository.Add(sanPham);
        }

        public void Update(SAN_PHAM sanPham)
        {
            _sanPhamRepository.Update(sanPham);
        }

        public void Delete(int id)
        {
            _sanPhamRepository.Delete(id);
        }

        public IEnumerable<SAN_PHAM> GetAll()
        {
            return _sanPhamRepository.GetAll(new string[] { "THUONG_HIEU" });
        }

        public SAN_PHAM GetById(int id)
        {
            return _sanPhamRepository.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
