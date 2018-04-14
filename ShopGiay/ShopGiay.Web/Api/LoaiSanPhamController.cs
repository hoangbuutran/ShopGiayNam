using ShopGiay.Model.Model;
using ShopGiay.Service;
using ShopGiay.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopGiay.Web.Api
{
    [RoutePrefix("api/loaisanpham")]
    public class LoaiSanPhamController : ApiControllerBase
    {
        ILoaiSanPhamService _loaiSanPhamService;
        public LoaiSanPhamController(IErrorService errorService, ILoaiSanPhamService loaiSanPhamService)
            : base(errorService)
        {
            this._loaiSanPhamService = loaiSanPhamService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var loaiSanPhamByID = _loaiSanPhamService.GetByID(id);
                var response = request.CreateResponse(HttpStatusCode.OK, loaiSanPhamByID);

                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listLoaiSanPham = _loaiSanPhamService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listLoaiSanPham);

                return response;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, LOAI_SAN_PHAM loaiSanPhamModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var loaiSanPham = _loaiSanPhamService.Add(loaiSanPhamModel);
                    _loaiSanPhamService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, loaiSanPham);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPost]
        public HttpResponseMessage Update(HttpRequestMessage request, LOAI_SAN_PHAM loaiSanPhamModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var loaiSanPhamDb = _loaiSanPhamService.GetByID(loaiSanPhamModel.ID);
                    _loaiSanPhamService.Update(loaiSanPhamDb);
                    _loaiSanPhamService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpPost]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _loaiSanPhamService.Delete(id);
                    _loaiSanPhamService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
