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
    [RoutePrefix("api/thuonghieu")]
    public class ThuongHieuController : ApiControllerBase
    {
        IThuongHieuService _thuongHieuService;

        public ThuongHieuController(IErrorService errorService, IThuongHieuService thuongHieuService)
            : base(errorService)
        {
            this._thuongHieuService = thuongHieuService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var loaiSanPhamByID = _thuongHieuService.GetById(id);
                var response = request.CreateResponse(HttpStatusCode.OK, loaiSanPhamByID);
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listThuongHieu = _thuongHieuService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listThuongHieu);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, THUONG_HIEU thuongHieuModel)
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
                    var thuongHieu = _thuongHieuService.Add(thuongHieuModel);
                    _thuongHieuService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, thuongHieu);
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, THUONG_HIEU thuongHieuModel)
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
                    var thuongHieuDb = _thuongHieuService.GetById(thuongHieuModel.ID);
                    _thuongHieuService.Update(thuongHieuDb);
                    _thuongHieuService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [HttpDelete]
        [Route("delete")]
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
                    _thuongHieuService.Delete(id);
                    _thuongHieuService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
