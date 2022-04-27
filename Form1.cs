using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace png_to_asci
{
    public partial class Form1 : Form
    {
        int cmd_width = 236;//tested and that is the size for my pc
        int cmd_height = 63;//tested and that is the size for my pc
                            //3.74 ratio in cmd
                            //2.32 ratio in text vertical
        public  int width, height;
        Image source;//we will add the picture to here so we wont lose resolution
        string gray_scale = "$@B%8&WM#*oahkbdpqwmZO0QLCJUYXzcvunxrjft/\\|()1{}[]?-_+~<>i!lI;:,^`'.";
        //";//detailed stolen from google
        //" .:-=+*#%@"
        //in case of console this is white to black
        //(depends on background color and negetives so in html this is backwards by default)
        //string gray_scale= Reverse("   .:-=+*#%@");

        //gray_scale=Reverse(gray_scale);
        //string short_gray_scale = " .:-=+*#%@";
        //same but shorter
        public Form1()
        {
            InitializeComponent();
            //SetConsoleFont
            //for (int i = 0; i < 9999; i++)
            //{
            //    Console.Write(i);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            //fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = fdlg.FileName;
                txt_path.Visible = true;
                pbx_preview_Click(sender, e);
            }
        }

        private void pbx_preview_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(txt_path.Text);
            pbx_preview.Image = img;
            source = img;
            pbx_preview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public static Bitmap ResizeImage(Image image, int new_width, int new_height)
        {
            var destRect = new Rectangle(0, 0, new_width, new_height);
            var destImage = new Bitmap(new_width, new_height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }           
            return destImage;
        }

        private void btn_convert_Click(object sender, EventArgs e)
        {
            Bitmap pic = (Bitmap)pbx_preview.Image;
            pic = ResizeImage(pic, pic.Width, pic.Height / 2);//this  fixes natural text ratio(single char ratio in cmd)
                                                              //makes a square image to square to simplify

            double y_ratio = 1;
            double x_ratio = 1;

            if (pic.Height>62)
                y_ratio = pic.Height / 62;//62 vertical pixels
            if(pic.Height>264)
                x_ratio = pic.Width / 264;//264 horizontal pixels

            x_ratio = Math.Max(x_ratio, y_ratio);
            x_ratio = 1 / x_ratio;

            pic = ResizeImage(pic, (int)(pic.Width*x_ratio), (int)(pic.Height * x_ratio));



            pbx_preview.Image = pic;


            pic=MakeGrayscale((Bitmap)(pic));
            pbx_preview.Image = pic;

            char[,] arr=gray_scale_to_ascii(pic);

            print_ascii_to_console(arr);
        }

        private void print_ascii_to_console(char[,] arr)
        {
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                for (int y = 0; y < arr.GetLength(0); y++)
                {
                    Console.Write(arr[y, x]);
                }
                Console.WriteLine();
            }
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        //returns a string with \n's with ascii chars
        private char[,] gray_scale_to_ascii(Bitmap copy)
        {
            //final ratio is width of chars / width of image
            // height of chars / height of image
            //font Courier
            char[,] output = new char[copy.Width, copy.Height];
            //int l1 = copy.Width;
            //int l2 = copy.Height;
            char next_pixel=' ';
            int len = gray_scale.Length;
            //Console.WriteLine("resolution is:"+l1+"X"+l2);
            for (int x = 0; x < copy.Width; x++)
            {
                for (int y = 0; y < copy.Height; y++)
                {                    
                    Color originalColor = copy.GetPixel(x, y);                    
                    next_pixel = gray_scale[(int)(originalColor.R / (len+1))];// was /4
                    output[x, y] = next_pixel;                    
                    //catch
                    //{
                    //    Console.WriteLine("error thrown at gray_scale_to_ascii");
                    //    Console.WriteLine("x:" + x + "y:" + y + "pixel is:"+next_pixel);
                    //}
                }
            }
            return output;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
