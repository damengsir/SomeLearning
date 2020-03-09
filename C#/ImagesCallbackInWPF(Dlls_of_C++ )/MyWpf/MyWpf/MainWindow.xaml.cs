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
using System.Runtime.InteropServices;




namespace MyWpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    

    public class ImageScale
    {
        public double ImageWindowWidth = 0;
        public double ImageWindowHeight = 0;
        public System.Windows.Point ImageWindowTopLeftPoint;
        public double MinScale = 1.25;
        public double MaxScale = 10;
        public System.Windows.Controls.Image ImageWindow;
        public ScaleTransform ScaleTransform;
        public TranslateTransform TranslateTransform;
        public bool EnableImageMove = false;
        public bool EnableImageScale = true;
        public System.Windows.Point StartPosition = new System.Windows.Point(0, 0);

        public ImageScale(System.Windows.Controls.Image image, ScaleTransform scaleTransform, TranslateTransform translateTransform,
            System.Windows.Point imageWindowTopLeftPoint, double minScale = 1.25, double maxScale = 10)
        {
            ImageWindow = image;
            ScaleTransform = scaleTransform;
            TranslateTransform = translateTransform;
            MinScale = minScale;
            MaxScale = maxScale;
            ImageWindowTopLeftPoint = imageWindowTopLeftPoint;
        }

        public void ScaleImage(System.Windows.Point scalePoint, double scaleRatio)
        {
            if (!EnableImageScale)
                return;

            if (ImageWindow.Stretch == Stretch.Uniform)
                return;

            if (ImageWindowWidth == 0)
            {
                if (ScaleTransform.ScaleX == 1 && ScaleTransform.ScaleY == 1)
                {
                    ImageWindowWidth = ImageWindow.ActualWidth;
                    ImageWindowHeight = ImageWindow.ActualHeight;
                }
            }

            if (ScaleTransform.ScaleX < MinScale && ScaleTransform.ScaleY < MinScale && scaleRatio < 1)
            {
                return;
            }

            if (ScaleTransform.ScaleX > MaxScale && ScaleTransform.ScaleY > MaxScale && scaleRatio > 1)
            {
                return;
            }

            ScaleTransform.CenterX = scalePoint.X;
            ScaleTransform.CenterY = scalePoint.Y;

            ScaleTransform.ScaleX *= scaleRatio;
            ScaleTransform.ScaleY *= scaleRatio;

            if (scaleRatio < 1)
            {
                Window window = Window.GetWindow(ImageWindow);
                System.Windows.Point point = ImageWindow.TransformToAncestor(window).Transform(new System.Windows.Point(0, 0));

                if (point.X - ImageWindowTopLeftPoint.X > 0)
                {
                    TranslateTransform.X -= point.X - ImageWindowTopLeftPoint.X;
                }

                if (point.X - ImageWindowTopLeftPoint.X + ImageWindowWidth * ScaleTransform.ScaleX < ImageWindowWidth)
                {
                    TranslateTransform.X += ImageWindowWidth * (1 - ScaleTransform.ScaleX) - (point.X - ImageWindowTopLeftPoint.X);
                }

                if (point.Y - ImageWindowTopLeftPoint.Y > 0)
                {
                    TranslateTransform.Y -= point.Y - ImageWindowTopLeftPoint.Y;
                }

                if (point.Y - ImageWindowTopLeftPoint.Y + ImageWindowHeight * ScaleTransform.ScaleY < ImageWindowHeight)
                {
                    TranslateTransform.Y = ImageWindowHeight * (1 - ScaleTransform.ScaleY) - (point.Y - ImageWindowTopLeftPoint.Y);
                }
            }
        }

        public void MoveImage(System.Windows.Point mousePosition)
        {
            if (!EnableImageMove)
                return;

            if (ImageWindowWidth == 0)
            {
                if (ScaleTransform.ScaleX == 1 && ScaleTransform.ScaleY == 1)
                {
                    ImageWindowWidth = ImageWindow.ActualWidth;
                    ImageWindowHeight = ImageWindow.ActualHeight;
                }
            }

            Window window = Window.GetWindow(ImageWindow);
            System.Windows.Point point = ImageWindow.TransformToAncestor(window).Transform(new System.Windows.Point(0, 0));

            if ((point.X + mousePosition.X - StartPosition.X <= ImageWindowTopLeftPoint.X) && (point.X + mousePosition.X - StartPosition.X + ImageWindowWidth * ScaleTransform.ScaleX >= ImageWindowTopLeftPoint.X + ImageWindowWidth))
            {
                TranslateTransform.X += mousePosition.X - StartPosition.X;
            }

            if ((point.Y + mousePosition.Y - StartPosition.Y <= ImageWindowTopLeftPoint.Y) && (point.Y + mousePosition.Y - StartPosition.Y + ImageWindowHeight * ScaleTransform.ScaleY >= ImageWindowTopLeftPoint.Y + ImageWindowHeight))
            {
                TranslateTransform.Y += mousePosition.Y - StartPosition.Y;
            }
        }

        public void SetStretchMode(Stretch stretchMode)
        {
            if (ImageWindow.Stretch != stretchMode || TranslateTransform.X != 0 || TranslateTransform.Y != 0 || ScaleTransform.ScaleX != 1 || ScaleTransform.ScaleY != 1)
            {
                TranslateTransform.X = 0;
                TranslateTransform.Y = 0;
                ScaleTransform.ScaleX = 1;
                ScaleTransform.ScaleY = 1;

                ImageWindow.Stretch = stretchMode;
            }
        }
    }
    public partial class MainWindow : Window
    {
        private delegate void UpdateUVSSImageDelegate(IntPtr pData, int width, int height, int widthStep, int channels, int type);

        private UVSSOutputCallbackDelegate OutputCallback;
        private ImageScale ImageScaleUVSSImage;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonReadImage_Click(object sender, RoutedEventArgs e)
        {
            OutputCallback = UVSSOutputCallback;//图像数据，高度，宽度，通道数
            Dll.SetOutputCallback(OutputCallback);

            Dll.StartReadImage();
        }


        public void UVSSOutputCallback(IntPtr imageData, int width, int height, int widthStep, int channels, int type)
        {
            UpdateUVSSImageDelegate updateUVSSImage = new UpdateUVSSImageDelegate(UpdateUVSSImage);

            try
            {
                Dispatcher.Invoke(updateUVSSImage, imageData, width, height, widthStep, channels, type);
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        // 更新车底图像（预览和最终显示）
        public void UpdateUVSSImage(IntPtr imageData, int width, int height, int widthStep, int channels, int type)
        {

            
            //ImageScaleUVSSImage.EnableImageScale = true;

            try
            {
              //  ImageScaleUVSSImage.SetStretchMode(Stretch.Fill);
                

                int imageSize = widthStep * height;
                byte[] UVSSImageData = new byte[imageSize];
                Marshal.Copy(imageData, UVSSImageData, 0, imageSize);

                PixelFormat format = new PixelFormat();

              
                format = PixelFormats.Bgr24;

                BitmapSource bitmap = BitmapImage.Create(width, height, 96, 96, format, null, UVSSImageData, widthStep);
                imageUVSS.Source = bitmap;
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show("UpdateUVSSImage: " + ex.Message);
            }
        }
    }
}
