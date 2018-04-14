using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopGiay.Data.Infrastructure;
using ShopGiay.Data.Repositories;
using ShopGiay.Model.Model;

namespace ShopGiay.Service
{
    public interface IThuongHieuService
    {
        THUONG_HIEU Add(THUONG_HIEU thuongHieu);
        void Update(THUONG_HIEU thuongHieu);
        void Delete(int id);
        IEnumerable<THUONG_HIEU> GetAll();
        IEnumerable<THUONG_HIEU> GetAll(string keyWord);
        THUONG_HIEU GetById(int id);
        void SaveChanges();
    }
    public class ThuongHieuService : IThuongHieuService
    {
        IThuongHieuRepository _thuongHieuRepository;
        IUnitOfWork _unitOfWork;
        public ThuongHieuService(IThuongHieuRepository thuongHieuRepository, IUnitOfWork unitOfWork)
        {
            this._thuongHieuRepository = thuongHieuRepository;
            this._unitOfWork = unitOfWork;
        }
        public THUONG_HIEU Add(THUONG_HIEU thuongHieu)
        {
            return _thuongHieuRepository.Add(thuongHieu);
        }

        public void Update(THUONG_HIEU thuongHieu)
        {
            _thuongHieuRepository.Update(thuongHieu);
        }

        public void Delete(int id)
        {
            _thuongHieuRepository.Delete(id);
        }

        public IEnumerable<THUONG_HIEU> GetAll()
        {
            //return _postCategoryRepository.GetAll(new string[] { "Posts" });
            return _thuongHieuRepository.GetAll();
        }

        public IEnumerable<THUONG_HIEU> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
            {
                return _thuongHieuRepository.GetMulti(x => x.TrangThai == true && x.TenThuongHieu.Contains(keyWord));
            }
            else
            {
                return _thuongHieuRepository.GetAll();
            }
        }

        //public IEnumerable<THUONG_HIEU> GetAllByParentId(int parentId)
        //{
        //    return _thuongHieuRepository.GetMulti(x => x.TrangThai == true && x.ParentID == parentId, new string[] { "Posts" });
        //}

        public THUONG_HIEU GetById(int id)
        {
            return _thuongHieuRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
