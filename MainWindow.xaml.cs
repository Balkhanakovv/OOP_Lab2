using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point2D point;
        private Rectangle rectangle;
        private Triangle triangle;

        private void drawPoint(Point2D point) 
        {
            Ellipse boldPoint = new Ellipse();
            boldPoint.Width = 4;
            boldPoint.Height = 4;
            boldPoint.StrokeThickness = 2;
            boldPoint.Stroke = Brushes.Black;
            boldPoint.Margin = new Thickness(point.getX() - 2, point.getY() - 2, 0, 0);

            MainCanvas.Children.Add(boldPoint);
        }

        private void drawRectangle(Rectangle rectangle)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            Line line1 = new Line();
            line1.Stroke = Brushes.Red;
            Line line2 = new Line();
            line2.Stroke = Brushes.Red;
            Line line3 = new Line();
            line3.Stroke = Brushes.Red;

            line.X1 = rectangle.getPoint1().getX();
            line.Y1 = rectangle.getPoint1().getY();
            line.X2 = rectangle.getPoint2().getX();
            line.Y2 = rectangle.getPoint2().getY();
            MainCanvas.Children.Add(line);

            line1.X1 = rectangle.getPoint2().getX();
            line1.Y1 = rectangle.getPoint2().getY();
            line1.X2 = rectangle.getPoint4().getX();
            line1.Y2 = rectangle.getPoint4().getY();
            MainCanvas.Children.Add(line1);

            line2.X1 = rectangle.getPoint4().getX();
            line2.Y1 = rectangle.getPoint4().getY();
            line2.X2 = rectangle.getPoint3().getX();
            line2.Y2 = rectangle.getPoint3().getY();
            MainCanvas.Children.Add(line2);

            line3.X1 = rectangle.getPoint3().getX();
            line3.Y1 = rectangle.getPoint3().getY();
            line3.X2 = rectangle.getPoint1().getX();
            line3.Y2 = rectangle.getPoint1().getY();
            MainCanvas.Children.Add(line3);
        }

        private void drawTriangle(Triangle triangle)
        {
            Line line = new Line();
            line.Stroke = Brushes.Red;
            Line line1 = new Line();
            line1.Stroke = Brushes.Red;
            Line line2 = new Line();
            line2.Stroke = Brushes.Red;

            line.X1 = triangle.getPoint1().getX();
            line.Y1 = triangle.getPoint1().getY();
            line.X2 = triangle.getPoint2().getX();
            line.Y2 = triangle.getPoint2().getY();
            MainCanvas.Children.Add(line);

            line1.X1 = triangle.getPoint2().getX();
            line1.Y1 = triangle.getPoint2().getY();
            line1.X2 = triangle.getPoint3().getX();
            line1.Y2 = triangle.getPoint3().getY();
            MainCanvas.Children.Add(line1);

            line2.X1 = triangle.getPoint3().getX();
            line2.Y1 = triangle.getPoint3().getY();
            line2.X2 = triangle.getPoint1().getX();
            line2.Y2 = triangle.getPoint1().getY();
            MainCanvas.Children.Add(line2);
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Point2DBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Visible;
            triangleInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Hidden;

            MainCanvas.Children.Clear();
            this.point = Generate.initPoint2D();
            this.rectangle = null;
            this.triangle = null;

            drawPoint(this.point);

            pointX.Text = "X: " + point.getX().ToString("#.##");
            pointY.Text = "Y: " + point.getY().ToString("#.##");
        }

        private void RectangleBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Visible;
            triangleInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Visible;

            MainCanvas.Children.Clear();

            if (rectangleWidth.Text == "" && rectangleHeight.Text == "")
            {
                this.rectangle = Generate.initRectangle();
                drawRectangle(this.rectangle);

                rectangleArea.Text = "Площадь " + rectangle.getArea().ToString("#.##");
                rectanglePerimeter.Text = "Периметр " + rectangle.getPerimeter().ToString("#.##");
            }
            else
            {
                this.rectangle = Generate.initRectangleSize(double.Parse(rectangleHeight.Text), double.Parse(rectangleWidth.Text));

                if ((double.Parse(rectangleHeight.Text) > 300 || double.Parse(rectangleWidth.Text) > 500))
                    MessageBox.Show("Неправильные данные");
                else
                {
                    drawRectangle(this.rectangle);

                    rectangleArea.Text = "Площадь " + rectangle.getArea().ToString("#.##");
                    rectanglePerimeter.Text = "Периметр " + rectangle.getPerimeter().ToString("#.##");
                }
            }

            this.triangle = null;
            this.point = null;

        }

        private void TriangleBt_Click(object sender, RoutedEventArgs e)
        {
            pointInfo.Visibility = Visibility.Hidden;
            rectangleInfo.Visibility = Visibility.Hidden;
            rectangleOptions.Visibility = Visibility.Hidden;
            triangleInfo.Visibility = Visibility.Visible;

            MainCanvas.Children.Clear();
            this.triangle = Generate.initTriangle();
            this.point = null;
            this.rectangle = null;

            drawTriangle(this.triangle);

            triangleArea.Text = "Площадь " + triangle.getArea().ToString("#.##");
            trianglePerimeter.Text = "Периметр " + triangle.getPerimeter().ToString("#.##");
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.point != null)
            {
                if (e.Key == Key.Up)
                    this.point.shiftY(-10);
                if (e.Key == Key.Down)
                    this.point.shiftY(10);
                if (e.Key == Key.Right)
                    this.point.shiftX(10);
                if (e.Key == Key.Left)
                    this.point.shiftX(-10);

                MainCanvas.Children.Clear();

                drawPoint(this.point);

                pointX.Text = "X: " + point.getX().ToString("#.##");
                pointY.Text = "Y: " + point.getY().ToString("#.##");
            }

            if (this.triangle != null)
            {
                MainCanvas.Children.Clear();

                if(e.Key == Key.Up)
                    this.triangle.shiftY(-10);
                if (e.Key == Key.Down)
                    this.triangle.shiftY(10);
                if (e.Key == Key.Right)
                    this.triangle.shiftX(10);
                if (e.Key == Key.Left)
                    this.triangle.shiftX(-10);

                drawTriangle(this.triangle);
            }

            if (this.rectangle != null)
            {
                MainCanvas.Children.Clear();
                
                if (e.Key == Key.Up)
                    this.rectangle.shiftY(-10);
                if (e.Key == Key.Down)
                    this.rectangle.shiftY(10);
                if (e.Key == Key.Right)
                    this.rectangle.shiftX(10);
                if (e.Key == Key.Left)
                    this.rectangle.shiftX(-10);

                drawRectangle(this.rectangle);
            }
        }
    }
}
