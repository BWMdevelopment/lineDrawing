using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestApplication.BL.Builder.Abstract;
using TestApplication.BL.Builder.Concrete;
using TestApplication.BL.Helpers.Abstract;
using TestApplication.BL.Managers.Abstract;
using TestApplication.BL.Model;
using TestApplication.BL.Models;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class HomeController : Controller
    {
        ICoordinatesManager coordinatesManager;
        IColorChooseHelper colorChooseHelper;
        IElementBuilder elementBuilder;
        public HomeController(ICoordinatesManager coordinatesManagerParam, IColorChooseHelper colorChooseHelperParam)
        {
            coordinatesManager = coordinatesManagerParam;
            colorChooseHelper = colorChooseHelperParam;
            elementBuilder = new SegmentBuilder(colorChooseHelper, coordinatesManager);

        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult SaveSegment(List<PointModel> pointsList)
        {
            List<Point> temp = new List<Point>();
            pointsList.ForEach(x => temp.Add(new Point { X = x.X, Y = x.Y }));
            Boolean result = coordinatesManager.SaveOrUpdatePoints(temp);
            return Json(null);
        }

        public JsonResult GetSegment()
        {
            return Json(elementBuilder.BuildElement(), JsonRequestBehavior.AllowGet);
        }
    }
}