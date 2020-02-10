using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab2
{
    public class Point2D
    {
        private double x;

        private double y;
                
        public static Point2D initPoint2D()
        {
            Point2D point = new Point2D();

            Random random = new Random();
            const int widthMAX = 500;
            const int heightMAX = 300;

            point.x = random.NextDouble() * widthMAX;
            point.y = random.NextDouble() * heightMAX;

            return point;
        }
        
        public void setX(double value)
        {
            x = value;
        }

        public void setY(double value)
        {
            y = value;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public void shiftX(double value)
        {
            x += value;

            if (x < 0 || x > 500)
                x -= value;
        }

        public void shiftY(double value)
        {
            y += value;

            if (y < 0 || y > 300)
                y -= value;
        }

        public double getDistance(Point2D OtherPoint)
        {
            double distance = Sqrt(Pow((x - OtherPoint.getX()), 2) + (y - OtherPoint.getY()));

            return distance;
        }

        public bool equals(Point2D OtherPoint)
        {
            if ((x == OtherPoint.getX()) && y == OtherPoint.getY())
                return true;
            else
                return false;
        }
    }
}