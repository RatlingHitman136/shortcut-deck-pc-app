using ShortCutDeckDesktop.ConstantValues;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShortCutDeckDesktop.DataLoaders
{
    public static class ShortCutImageLoader
    {
        private static Dictionary<string, BitmapImage> loadedImages = new Dictionary<string, BitmapImage>();
        private static BitmapImage defaultImage;

        private static BitmapImage GetDefaultImage() {
            string path = StringConstants.SHORT_CUT_ICONS_ABSOLUTE_PATH
                + StringConstants.SHORT_CUT_DEFAULT_ICON_ID + ".png";
            
            Stream? stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);

            Bitmap bitmap = new Bitmap(stream);

            BitmapSource i = Imaging.CreateBitmapSourceFromHBitmap(
                           bitmap.GetHbitmap(),
                           IntPtr.Zero,
                           Int32Rect.Empty,
                           BitmapSizeOptions.FromEmptyOptions());

            return (BitmapImage)i;
        }

        public static BitmapImage GetImageByID(string iconId)
        {
            bool exists = loadedImages.TryGetValue(iconId, out BitmapImage bitmap);
            if (!exists)
                return defaultImage;
            else
                return bitmap;
        }

        public static void LoadAllImages()
        {
            defaultImage = GetDefaultImage();

        }
    }
}
