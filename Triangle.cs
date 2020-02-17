using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Lab2
{
    public class Triangle
    {
        private Point2D point1;

        private Point2D point2;

        private Point2D point3;

        public static Triangle initTriangle()
        {
            Triangle triangle = new Triangle();

            triangle.point1 = Generate.initPoint2D();
            Thread.Sleep(20);
            triangle.point2 = Generate.initPoint2D();
            Thread.Sleep(20);
            triangle.point3 = Generate.initPoint2D();

            return triangle;
        }

        public Point2D getPoint1()
        {
            return point1;
        }

        public Point2D getPoint2()
        {
            return point2;
        }

        public Point2D getPoint3()
        {
            return point3;
        }

        public double getPerimeter()
        {
            double first = point1.getDistance(point2);
            double second = point2.getDistance(point3);
            double third = point3.getDistance(point1);

            return first + second + third;
        }

        public double getArea()
        {
            double[,] array = new double[2, 2];
            array[0, 0] = point1.getX() - point3.getX();
            array[0, 1] = point1.getY() - point3.getY();
            array[1, 0] = point2.getX() - point3.getX();
            array[1, 1] = point2.getY() - point3.getY(); 

            return Abs((array[0, 0] * array[1, 1]) - (array[0, 1] * array[1, 0])) / 2; ;
        }

        public void shiftX(double value)
        {
            point1.shiftX(value);
            point2.shiftX(value); 
            point3.shiftX(value);

            if ((point1.getX() < 0 || point1.getX() > 500) || (point2.getX() < 0 || point2.getX() > 500) || (point3.getX() < 0 || point3.getX() > 500))
            {
                point1.shiftX(-value);
                point2.shiftX(-value);
                point3.shiftX(-value);
            }
        }

        public void shiftY(double value)
        {
            point1.shiftY(value);
            point2.shiftY(value);
            point3.shiftY(value);

            if ((point1.getY() < 0 || point1.getY() > 300) || (point2.getY() < 0 || point2.getY() > 300) || (point3.getY() < 0 || point3.getY() > 300))
            {
                point1.shiftY(-value);
                point2.shiftY(-value);
                point3.shiftY(-value);
            }
        }
    }
}
