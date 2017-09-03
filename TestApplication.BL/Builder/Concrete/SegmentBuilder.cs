using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BL.Builder.Abstract;
using TestApplication.BL.Helpers.Abstract;
using TestApplication.BL.Managers.Abstract;
using TestApplication.BL.Model;
using TestApplication.BL.Models;

namespace TestApplication.BL.Builder.Concrete
{
    public class SegmentBuilder : IElementBuilder
    {
        IColorChooseHelper colorHelper;
        ICoordinatesManager coordinatesManager;
        public SegmentBuilder()
        {

        }
        public SegmentBuilder(IColorChooseHelper colorHelperParam, ICoordinatesManager coordinatesManagerParam)
        {
            colorHelper = colorHelperParam;
            coordinatesManager = coordinatesManagerParam;
        }
        public Object BuildElement()
        {
            SegmentModel model = new SegmentModel();
            model.Color = colorHelper.GetRandomColor();
            if (coordinatesManager.HasSavedCoordinates())
            {
                model.CoordinatesList = coordinatesManager.GetSavedCoordinates();
            }
            else
            {
                HashSet <Point> temp = new HashSet<Point>();
                for (int i = 0; i < 2; i++)
                {
                    temp.Add(coordinatesManager.GetRandomCoordinate());
                }
                model.CoordinatesList = temp;
            }
            return model;
        }
    }
}
