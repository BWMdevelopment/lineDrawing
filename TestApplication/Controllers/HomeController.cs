using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestApplication.BL.Builder.Abstract;
using TestApplication.BL.Builder.Concrete;
using TestApplication.BL.Helpers.Abstract;
using TestApplication.BL.Managers.Abstract;
using TestApplication.BL.Model;
using TestApplication.BL.Models;

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

        public JsonResult SaveSegment(IEnumerable<Point> pointsList)
        {
            Boolean result = coordinatesManager.SaveOrUpdatePoints(pointsList);
            return Json(result);
        }

        public JsonResult UpdateSegment()
        {
            return Json(elementBuilder.BuildElement());
        }
    }
}