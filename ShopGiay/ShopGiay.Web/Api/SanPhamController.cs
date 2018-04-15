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
    [RoutePrefix("api/sanpham")]
    public class SanPhamController : ApiControllerBase
    {
        ISanPhamService _sanPhamService;

        public SanPhamController(IErrorService errorService, ISanPhamService sanPhamService)
            : base(errorService)
        {
            this._sanPhamService = sanPhamService;
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var sanPhamByID = _sanPhamService.GetById(id);
                var response = request.CreateResponse(HttpStatusCode.OK, sanPhamByID);
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listSanPham = _sanPhamService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listSanPham);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, SAN_PHAM sanPhamModel)
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
                    var thuongHieu = _sanPhamService.Add(sanPhamModel);
                    _sanPhamService.SaveChange();
                    response = request.CreateResponse(HttpStatusCode.Created, thuongHieu);
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, SAN_PHAM sanPhamModel)
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
                    var sanPhamDb = _sanPhamService.GetById(sanPhamModel.ID);
                    _sanPhamService.Update(sanPhamDb);
                    _sanPhamService.SaveChange();

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
                    _sanPhamService.Delete(id);
                    _sanPhamService.SaveChange();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
