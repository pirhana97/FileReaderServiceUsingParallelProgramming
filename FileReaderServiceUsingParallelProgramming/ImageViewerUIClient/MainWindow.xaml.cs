using FileReaderUIClient;
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
using System.Windows.Forms;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using System.Drawing;

namespace ImageViewerUIClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string filepath = FilePath.Text;

           
        }

        private void OnBrowseClick(object sender, EventArgs e)
        {


            OpenFileDialog dlg = new OpenFileDialog();
            //    dlg.InitialDirectory = "c:\\";
    //        dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string selectedFileName = dlg.FileName;
                FilePath.Text = selectedFileName;
                BitmapImage bitmaps = new BitmapImage();
                bitmaps.BeginInit();
                bitmaps.UriSource = new Uri(selectedFileName);
                bitmaps.EndInit();
                ImageViewer.Source = bitmaps;


            }

        }

        private void GrayScaleButton_OnClick(object sender, RoutedEventArgs e)
        {

            BitmapImage bitmap = new BitmapImage();
            string filePath = FilePath.Text;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();

            FormatConvertedBitmap grayBitmapSource = new FormatConvertedBitmap();
  
            grayBitmapSource.BeginInit();

            grayBitmapSource.Source = bitmap;
 
            grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            grayBitmapSource.EndInit();

            ModifiedImageViewer.Source = grayBitmapSource;


        }

        private void CropImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a BitmapImage  
            BitmapImage bitmap = new BitmapImage();
            string filePath = FilePath.Text;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();
  
            CroppedBitmap cb = new CroppedBitmap((BitmapSource)bitmap,
                new Int32Rect(20, 20, 100, 100));
            ModifiedImageViewer.Source = cb;

        }

        private void BrightnessButton_Click(object sender, RoutedEventArgs e)
        {
            BitmapImage bitmap = new BitmapImage();
            string filePath = FilePath.Text;
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();

            BitMapImageToBitMap bp = new BitMapImageToBitMap();
            Bitmap bmp= bp.BitmapImage2Bitmap(bitmap);

            //get image dimension
            double width = bmp.Width;
            double height = bmp.Height;

            //color of pixel
            System.Drawing.Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                }
            }

            //load sepia image in picturebox2
             ModifiedImageViewer.Source = bmp;
           
        }
    }
}
