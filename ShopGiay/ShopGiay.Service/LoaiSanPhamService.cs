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

    public interface ILoaiSanPhamService
    {
        LOAI_SAN_PHAM Add(LOAI_SAN_PHAM loaiSanPham);
        void Update(LOAI_SAN_PHAM loaiSanPham);
        void Delete(int id);
        IEnumerable<LOAI_SAN_PHAM> GetAll();
        LOAI_SAN_PHAM GetByID(int id);
        void SaveChange();
    }

    public class LoaiSanPhamService : ILoaiSanPhamService
    {
        ILoaiSanPhamRepository _loaiSanPhamRepository;
        IUnitOfWork _unitOfWork;
        public LoaiSanPhamService(ILoaiSanPhamRepository loaiSanPhamRepository, IUnitOfWork unitOfWork)
        {
            this._loaiSanPhamRepository = loaiSanPhamRepository;
            this._unitOfWork = unitOfWork;
        }

        public LOAI_SAN_PHAM Add(LOAI_SAN_PHAM loaiSanPham)
        {
            return _loaiSanPhamRepository.Add(loaiSanPham);
        }

        public void Update(LOAI_SAN_PHAM loaiSanPham)
        {
            _loaiSanPhamRepository.Update(loaiSanPham);
        }

        public void Delete(int id)
        {
            _loaiSanPhamRepository.Delete(id);
        }

        public IEnumerable<LOAI_SAN_PHAM> GetAll()
        {
            return _loaiSanPhamRepository.GetAll();
        }

        public LOAI_SAN_PHAM GetByID(int id)
        {
            return _loaiSanPhamRepository.GetSingleById(id);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
