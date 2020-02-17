using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Math;

namespace Lab2
{
    public class Rectangle
    {
        private Point2D point1;

        private Point2D point2;

        private Point2D point3;

        private Point2D point4;

        public static Rectangle initRectangle()
        {
            Rectangle rectangle = new Rectangle();

            rectangle.point1 = Generate.initPoint2D();
            Thread.Sleep(20);
            rectangle.point4 = Generate.initPoint2D();
            Thread.Sleep(20);
            rectangle.point2 = Generate.initPoint2D(); //это сделано потому, что иначе вылезает исключение:
            Thread.Sleep(20);                          //"Ссылка на объект не указывает на экземпляр объекта".
            rectangle.point3 = Generate.initPoint2D(); //Поэтому я использовал этот способ, чтоб сначала инициализировать
                                                       //поле, а потом подставить значения.
    /*
            Random r = new Random();

            rectangle.point1 = new Point2D();
            rectangle.point1.setX(r.Next(10, 100));
            rectangle.point1.setY(r.Next(10, 100));

            rectangle.point2 = new Point2D(rectangle.point1);
            rectangle.point2.shiftX(r.Next(1, 10));

    //*/

            rectangle.point2.setX(rectangle.point4.getX());
            rectangle.point2.setY(rectangle.point1.getY());

            rectangle.point3.setX(rectangle.point1.getX());
            rectangle.point3.setY(rectangle.point4.getY());

            return rectangle;
        }
        
        public static Rectangle initRectangleSize(double height, double width)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.point1 = Generate.initPoint2D();
            Thread.Sleep(20);
            rectangle.point4 = Generate.initPoint2D();
            Thread.Sleep(20);
            rectangle.point2 = Generate.initPoint2D(); 
            Thread.Sleep(20);                          
            rectangle.point3 = Generate.initPoint2D();
                        
            rectangle.point1.setX(0);
            rectangle.point1.setY(0);

            rectangle.point2.setX(width);
            rectangle.point2.setY(rectangle.point1.getY());

            rectangle.point3.setX(rectangle.point1.getX());
            rectangle.point3.setY(height);

            rectangle.point4.setX(width);
            rectangle.point4.setY(height);
            return rectangle;
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

        public Point2D getPoint4()
        {
            return point4;
        }

        public double getArea()
        {
            double first = point1.getDistance(point2);
            double second = point1.getDistance(point3);

            return (first * second);
        }

        public double getPerimeter()
        {
            double first = point1.getDistance(point2);
            double second = point1.getDistance(point3);

            return ((first + second) * 2);
        }

        public void shiftX(double value)
        {
            point1.shiftX(value);
            point2.shiftX(value);
            point3.shiftX(value);
            point4.shiftX(value);

            if ((point1.getX() < 0 || point1.getX() > 500) || (point2.getX() < 0 || point2.getX() > 500) || (point3.getX() < 0 || point3.getX() > 500) || (point4.getX() < 0 || point4.getX() > 500))
            {
                point1.shiftX(-value);
                point2.shiftX(-value);
                point3.shiftX(-value);
                point4.shiftX(-value);
            }
        }

        public void shiftY(double value)
        {
            point1.shiftY(value);
            point2.shiftY(value);
            point3.shiftY(value);
            point4.shiftY(value);

            if ((point1.getY() < 0 || point1.getY() > 300) || (point2.getY() < 0 || point2.getY() > 300) || (point3.getY() < 0 || point3.getY() > 300) || (point4.getY() < 0 || point4.getY() > 300))
            {
                point1.shiftY(-value);
                point2.shiftY(-value);
                point3.shiftY(-value);
                point4.shiftY(-value);
            }

        }
    }
}
