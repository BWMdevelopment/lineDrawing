using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestApplication.BL.Managers.Abstract;
using TestApplication.BL.Model;

namespace TestApplication.BL.Managers.Concrete
{
    public class XMLLineCoordinatesManager : ICoordinatesManager
    {
        String xmlFilePath;
        public XMLLineCoordinatesManager(string DataPath)
        {
            xmlFilePath = DataPath;
        }
        public XMLLineCoordinatesManager()
        {
            xmlFilePath = @"d:\\Coordinates.xml";
        }
        public IEnumerable<Point> GetSavedCoordinates()
        {
            XDocument xdoc = XDocument.Load(xmlFilePath);
            var a = from xe in xdoc.Element("Points").Elements("Point")
                    select new Point
                    {
                        X = Convert.ToInt32(xe.Element("X").Value),
                        Y = Convert.ToInt32(xe.Element("Y").Value)
                    };
            return a;
        }

        public bool SaveOrUpdatePoints(IEnumerable<Point> pointToProceed)
        {
            try
            {
                CreateFileIfNotExists();

                XDocument xdoc = new XDocument();
                XElement pointsList = new XElement("Points");

                foreach (var point in pointToProceed)
                {
                    XElement pointRoot = CreateRootElementHierarchy(point);
                    pointsList.Add(pointRoot);
                }

                xdoc.Add(pointsList);
                xdoc.Save(xmlFilePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CreateFileIfNotExists()
        {
            if (!File.Exists(xmlFilePath))
            {
                File.Create(xmlFilePath);
            }
        }

        private static XElement CreateRootElementHierarchy(Point point)
        {
            XElement pointRoot = new XElement("Point");
            XElement pointX = new XElement("X", point.X);
            XElement pointY = new XElement("Y", point.Y);
            pointRoot.Add(pointX);
            pointRoot.Add(pointY);
            return pointRoot;
        }

        public bool HasSavedCoordinates()
        {
            return File.Exists(xmlFilePath);
        }

        public Point GetRandomCoordinate()
        {
            Random r = new Random();
            return new Point
            {
                X = r.Next(100),
                Y = r.Next(100)
            };
        }
    }
}
