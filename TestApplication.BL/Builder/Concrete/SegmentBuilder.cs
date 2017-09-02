using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BL.Builder.Abstract;
using TestApplication.BL.Helpers.Abstract;
using TestApplication.BL.Managers.Abstract;
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
                for (int i = 0; i < 2; i++)
                {
                    model.CoordinatesList = model.CoordinatesList.Concat(new[] { coordinatesManager.GetRandomCoordinate() });
                }
            }
            return model;
        }
    }
}
