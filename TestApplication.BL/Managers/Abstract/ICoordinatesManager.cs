using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BL.Model;

namespace TestApplication.BL.Managers.Abstract
{
    public interface ICoordinatesManager
    {
        IEnumerable<Point> GetSavedCoordinates();
        Point GetRandomCoordinate();
        bool SaveOrUpdatePoints(IEnumerable<Point> pointToProceed);
        bool HasSavedCoordinates();
    }
}
