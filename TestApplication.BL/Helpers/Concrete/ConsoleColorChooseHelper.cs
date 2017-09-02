using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BL.Helpers.Abstract;

namespace TestApplication.BL.Helpers.Concrete
{
    public class ConsoleColorChooseHelper : IColorChooseHelper
    {
        public string GetRandomColor()
        {
            Int32 countOfElements = Enum.GetNames(typeof(ConsoleColor)).Length;
            int colorIndex = new Random().Next(0, countOfElements - 1);
            return ((ConsoleColor)colorIndex).ToString();
        }
    }
}
