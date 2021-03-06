﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApplication.BL.Model;

namespace TestApplication.Models
{
    public class PointModel
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static implicit operator Point (PointModel convertFrom)
        {
            return new Point
            {
                X = convertFrom.X,
                Y = convertFrom.Y
            };
        }
    }
}