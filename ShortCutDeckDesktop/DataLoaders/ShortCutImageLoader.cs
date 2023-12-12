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
using Newtonsoft.Json;

namespace ShortCutDeckDesktop.DataLoaders
{
    public static class ShortCutImageLoader
    {
        private static Dictionary<string, BitmapImage> loadedImages = new Dictionary<string, BitmapImage>();
        private static string defaultImageId;

        public static BitmapImage GetImageByID(string iconId)
        {
            bool exist = loadedImages.TryGetValue(iconId, out BitmapImage icon);
            if (exist)
                return icon;
            else
                return loadedImages[defaultImageId];
        }

        public static void LoadAllImages()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream? stream = assembly.GetManifestResourceStream(StringConstants.SHORT_CUT_ICONS_JSON_PATH);
            if (stream is null)
                return;

            StreamReader reader = new StreamReader(stream);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            LoadedData data = JsonConvert.DeserializeObject<LoadedData>(jsonData);

            foreach(LoadedData.IconData iconData in data.icons)
            {
                string fullURI = StringConstants.SHORT_CUT_ICONS_PACK_URL + iconData.iconURI;
                BitmapImage icon = new BitmapImage(new Uri(fullURI));
                if(!loadedImages.ContainsKey(iconData.iconId))
                    loadedImages.Add(iconData.iconId, icon);
            }

            defaultImageId = data.defIconId;
        }

        public struct LoadedData
        {
            public string defIconId;
            public List<IconData> icons;

            public LoadedData(string defIconId, List<IconData> icons)
            {
                this.defIconId = defIconId;
                this.icons = icons;
            }

            public struct IconData
            {
                public string iconId;
                public string iconURI;

                public IconData(string iconId, string iconURL)
                {
                    this.iconId = iconId;
                    this.iconURI = iconURL;
                }
            }
        }
    }
}
