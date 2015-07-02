using System.Web.Mvc;
using SweetFly.BusinessLogic.contract.Cmr.cn;
using SweetFly.Infrastructure;
using SweetFly.Model.Entities.Cmr.cn;

namespace SweetFly.Admin.Controllers.Cmr
{
    /// <summary>
    /// 习题类别管理
    /// </summary>
    public class ItemTypeController : AdminBaseController
    {
        public IItemTypeService ItemTypeService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int page, int pageSize)
        {
            int total;
            var list = ItemTypeService.PageList(page, pageSize, out total);

            var result = new { Rows = list, Total = total };

            return Json(result);
        }

        public ActionResult Insert()
        {
            return PartialView("_Insert");
        }

        [HttpPost]
        public ActionResult Insert(ItemType model)
        {
            var result = ItemTypeService.Insert(model);

            return Json(result);
        }

        public ActionResult Update(ItemType model)
        {
            var result = ItemTypeService.Update(model);

            return Json(result);
        }

        public ActionResult Remove(int id)
        {
            var result = ItemTypeService.Remove(id);

            return Json(result);
        }
    }
}
