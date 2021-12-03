using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TeleMist.Helpers
{
    /// <summary>
    /// Кляс містить метод для конвертації зображень у масив байтів і навпаки
    /// </summary>
    /// 


    //internal class ImageBytesConverter : IValueConverter
    //{
    //    internal byte[] ConvertBitmapImageToByteArray(BitmapImage image)
    //    {

    //        ImageConverter imageConverter = new ImageConverter();
    //        byte[] bytes = (byte[])imageConverter.ConvertTo(image, typeof(byte[]));
    //        return bytes;
    //    }

    //    internal BitmapImage ConvertByteArrayToBitmapImage(byte[] imageByteArray)
    //    {

    //        BitmapImage img = new BitmapImage();
    //        using (MemoryStream memStream = new MemoryStream(imageByteArray))
    //        {
    //            img.StreamSource = memStream;
    //        }
    //        return img;
    //    }

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        BitmapImage img = new BitmapImage();

    //        if (value != null)
    //        {
    //            img = this.ConvertByteArrayToBitmapImage(value as byte[]);
    //        }
    //        return img;

    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        byte[] imageBytes = null;

    //        if (value != null)
    //        {
    //            imageBytes = this.ConvertBitmapImageToByteArray(value as BitmapImage);
    //        }
    //        return imageBytes;
    //    }
    //}

    //internal class ImageBytesConverter : IValueConverter
    //{
    //    internal byte[] ConvertImageToByteArray(Image image)
    //    {

    //        MemoryStream ms = new MemoryStream();
    //        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
    //        return ms.ToArray();
    //    }

    //    internal Image ConvertByteArrayToImage(byte[] imageByteArray)
    //    {

    //        MemoryStream ms = new MemoryStream(imageByteArray);
    //        Image returnImage = Image.FromStream(ms);
    //        return returnImage;

    //    }

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class ByteImageConverter
    {
        public ImageSource ByteToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            BitmapImage biImg = new BitmapImage();

            MemoryStream ms = new MemoryStream(imageData);

            try
            {
                biImg.BeginInit();
                ms.Seek(0, SeekOrigin.Begin);

                biImg.StreamSource = ms;
                biImg.EndInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка якась " + ex.Message);
                biImg = null;
            }
            
            ImageSource imgSrc = biImg as ImageSource;
            return imgSrc;
        }

        public byte[] ImageToByte(FileStream fs)
        {
            byte[] imgBytes = new byte[fs.Length];
            fs.Read(imgBytes, 0, Convert.ToInt32(fs.Length));
            return imgBytes;
        }
    }
}
