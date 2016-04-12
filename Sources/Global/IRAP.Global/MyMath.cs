using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace IRAP.Global
{
    public class MyMath
    {
        /// <summary>
        /// 计算两点间的直线长度
        /// </summary>
        public static double LineWidthWithTwoPoint(Point from, Point to)
        {
            return Math.Sqrt(
                Math.Pow((from.X - to.X), 2) + 
                Math.Pow((from.Y - to.Y), 2));
        }
    }
}