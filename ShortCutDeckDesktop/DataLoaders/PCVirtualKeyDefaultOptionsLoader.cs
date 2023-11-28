using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.DataLoaders
{
    public static class PCVirtualKeyDefaultOptionsLoader
    {
        private static string dataRelPath = "Json.PCVirtualKeyDefaultOptions.json";

        public static void LoadData()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Stream? stream = assembly.GetManifestResourceStream(dataRelPath);
            if (stream is null)
                return;

            StreamReader reader = new StreamReader(stream);
            string jsonData = reader.ReadToEnd();
            reader.Close();

            LoadedData data = JsonConvert.DeserializeObject<LoadedData>(jsonData);

        }

        [Serializable]
        public struct LoadedData
        {
            public List<DefaultOptionData> loadedData;
        }

        [Serializable]
        public struct DefaultOptionData
        {
            public string name;
            public int value;
            public string description;
        }
    }
}
