using System;
using System.Collections.Generic;
using System.Globalization;
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



namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            CompositionTarget.Rendering += OnRendering;
        }



        //public ScaleTransform GetScaleTransform(UIElement element)
        //{
        //    return (ScaleTransform)(element.RenderTransform)
        //      .Children.First(tr => tr is ScaleTransform);
        //}

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(image);

            double osMultiplier = 3.125; //this is a multiplier for the bitmap over to OS Grid

            double pixelWidth = image.Source.Width;
            double pixelHeight = image.Source.Height;
            double x = (osMultiplier * (pixelWidth * p.X / image.ActualWidth) - 1000)*100;
            double y = (13500 - (osMultiplier * (pixelHeight * p.Y / image.ActualHeight)) - 1000)*100;
            MessageBox.Show("Site Location:\nX = "+string.Format(new CultureInfo("en-GB"), "{0:N0}", x)+" mE\nY = "+ string.Format(new CultureInfo("en-GB"), "{0:N1}", y)+" mN");

        }

    
    

                
        

    
        
          
            private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            double scX = canvasMap.RenderTransform.Value.M11;
            double scY = canvasMap.RenderTransform.Value.M22;
            double trX = canvasMap.RenderTransform.Value.OffsetX;
            double trY = canvasMap.RenderTransform.Value.OffsetY;
            double zoom = 1;
            double winWidth = MapWindow.ActualWidth/2;
            double winHeight = MapWindow.ActualHeight/2;

            //MessageBox.Show(image.Height.ToString());
            double centerPointX = -(transformTranslate.X-winWidth) /((scX-1)/*/zoom/5*/ + 1); 
            double centerPointY = -(transformTranslate.Y - winHeight) / ((scY - 1) /*/ zoom / 5*/ + 1);

            //MessageBox.Show("translate: "+ canvasMap.RenderTransform.Value.OffsetX.ToString()+","+ canvasMap.RenderTransform.Value.OffsetY.ToString()+"\nborder:" + border.ActualWidth.ToString()+"," + border.ActualHeight.ToString() + "\ncentrepoints:"+centerPointX.ToString()+","+ centerPointY.ToString());

                        
            double absoluteX = centerPointX * transformScale.ScaleX + trX;
            double absoluteY = centerPointY * transformScale.ScaleY + trY;

            transformScale.ScaleX = scX + zoom;
            transformScale.ScaleY = scY + zoom;


            transformTranslate.X = absoluteX - centerPointX * transformScale.ScaleX;
            transformTranslate.Y = absoluteY - centerPointY * transformScale.ScaleY;

            //sc.Scale(1.2,1.2) = new TransformGroup();

            //canvasMap.RenderTransform = new MatrixTransform(sc);

            //MessageBox.Show(canvasMap.RenderTransform.Value.M22.ToString());
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            double scX = canvasMap.RenderTransform.Value.M11;
            double scY = canvasMap.RenderTransform.Value.M22;
            double trX = canvasMap.RenderTransform.Value.OffsetX;
            double trY = canvasMap.RenderTransform.Value.OffsetY;
            double zoom = -0.4;
            double winWidth = MapWindow.ActualWidth / 2;
            double winHeight = MapWindow.ActualHeight / 2;

            if (canvasMap.RenderTransform.Value.M11 > 0.4)
            {

                double centerPointX = -(transformTranslate.X - winWidth) / ((scX - 1)/*/zoom/5*/ + 1);
                double centerPointY = -(transformTranslate.Y - winHeight) / ((scY - 1) /*/ zoom / 5*/ + 1);

                double absoluteX = centerPointX * transformScale.ScaleX + trX;
                double absoluteY = centerPointY * transformScale.ScaleY + trY;

                transformScale.ScaleX = scX + zoom;
                transformScale.ScaleY = scY + zoom;


                transformTranslate.X = absoluteX - centerPointX * transformScale.ScaleX;
                transformTranslate.Y = absoluteY - centerPointY * transformScale.ScaleY;

            }
            else
            {
                return;
            }
         
            
        }

        private void OnRendering(object sender, EventArgs e)
        {
            double osMultiplier = 3.125;
            double pixelWidth = image.Source.Width;
            

            double xCoordinateLive = (Math.Round((osMultiplier *(pixelWidth * Mouse.GetPosition(image).X / image.ActualWidth)) - 1000,1)*100);
            double yCoordinateLive = (Math.Round(13500 - (osMultiplier * (pixelWidth * Mouse.GetPosition(image).Y / image.ActualWidth)) - 1000, 1) * 100);


            positionXText.Text = String.Format(new CultureInfo("en-GB"), "{0:N0}", xCoordinateLive);
            positionYText.Text = String.Format(new CultureInfo("en-GB"), "{0:N0}", yCoordinateLive);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mapReset_Click(object sender, RoutedEventArgs e)
        {
            transformScale.ScaleX = 1;
            transformScale.ScaleY = 1;


            transformTranslate.X = 170;
            transformTranslate.Y = 00;
        }

        //private void plusButton_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show(GetScaleTransform(canvas).ToString());
        //}
    }
}
