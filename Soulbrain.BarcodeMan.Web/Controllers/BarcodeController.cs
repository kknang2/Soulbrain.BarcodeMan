using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using Soulbrain.BarcodeMan.Repositories;
using Soulbrain.BarcodeMan.Web.Binders;
using Soulbrain.BarcodeMan.Web.Filters;
using Soulbrain.BarcodeMan.Web.Models.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class BarcodeController : BaseController
    {
        private readonly IMaterialGroupRepository _materialGroupRepo;
        private readonly IMaterialTypeRepository _materialTypeRepo;
        private readonly IWebBarCodeRepository _barcodeRepo;

        public BarcodeController(
            IMaterialGroupRepository materialGroupRepo,
            IMaterialTypeRepository materialTypeRepo,
            IWebBarCodeRepository barcodeRepo
            )
        {
            _materialGroupRepo = materialGroupRepo;
            _materialTypeRepo = materialTypeRepo;
            _barcodeRepo = barcodeRepo;
    }
        /// <summary>
        /// 바코드 발행등록
        /// </summary>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult Print()
        {
            Print model = new Print()
            {
                PopupProduct = new PopupProduct()
                {
                    MaterialGroupSelectList = _materialGroupRepo
                        .GetMaterialGroupSelectItems()
                        .Select(x => new SelectListItem()
                        {
                            Text = x.MaterialGroupName,
                            Value = x.MaterialGroupCode
                        }).ToList(),
                    MaterialTypeSelectList = _materialTypeRepo
                        .GetMaterialTypeSelectItems()
                        .Select(x => new SelectListItem()
                        {
                            Text = x.MaterialTypeName,
                            Value = x.MaterialTypeCode
                        }).ToList()
                }
            };

            return View("Print", model);
        }

        /// <summary>
        /// 바코드 발행이력
        /// </summary>
        /// <param name="filter">검색파라메터</param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ActionResult List([ModelBinder(typeof(WebBarCodeListFilterBinder))] WebBarCodeListFilter filter)
        {
            if(filter.ProductDateFrom == null)
            {
                filter.ProductDateFrom = DateTime.Now.Date;
            }
            if (filter.ProductDateTo == null)
            {
                filter.ProductDateTo = DateTime.Now.Date;
            }

            BarCodeListView model = new BarCodeListView()
            {
                WebBarCodeListItems = _barcodeRepo.GetWebBarCodePagedList(filter),
                Filter = filter
            };

            return View(model);
        }

        /// <summary>
        /// 재발행 테스트
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [CheckIfAuthenticated]
        public JsonResult Check()
        {
            return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 바코드발행이력 선택삭제
        /// </summary>
        /// <param name="ids">발행이력 삭제 키 리스트</param>
        /// <returns></returns>
        [HttpPost]
        [CheckIfAuthenticated]
        public JsonResult Delete(IList<WebBarCodeID> ids)
        {
            _barcodeRepo.DeleteWebBarCodes(ids);

            return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 바코드 발행이력 보관
        /// </summary>
        /// <param name="inputs">바코드 발행등록 모임</param>
        /// <returns></returns>
        [HttpPost]
        [CheckIfAuthenticated]
        public JsonResult Save(IList<WebBarCodeInput> inputs)
        {
            _barcodeRepo.SaveWebBarCodes(inputs);

            return Json(new { status = 200 }, JsonRequestBehavior.AllowGet);
        }
    }
}