using Newtonsoft.Json;
using ShortCutDeckDesktop.ShortCuts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.DataLoaders
{
    public static class ProfileJsonLoader
    {
        const string PROPFILE_SAVE_PATH = @"profiles\";

        private static JsonSerializerSettings json_settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, Formatting = Formatting.Indented };

        public static void SaveProfile(ShortCutProfile profile)
        {
            SaveProfile(profile.GetDataHolder());
        }

        public static void SaveProfile(ShortCutProfileDataHolder dataHolder)
        {
            string fileName = PROPFILE_SAVE_PATH + dataHolder.id + ".json";

            string res = JsonConvert.SerializeObject(dataHolder, json_settings);

            try
            {
                File.WriteAllText(fileName, res);
            }
            catch (Exception ex)
            {
                throw new Exception(ex + " Error by saving profile");
            }
        }

        public static List<ShortCutProfile> LoadAllProfiles()
        {
            List<ShortCutProfileDataHolder> resDataHolders = new List<ShortCutProfileDataHolder>();

            string folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + PROPFILE_SAVE_PATH;

            try
            {
                DirectoryInfo folderInfo = new DirectoryInfo(folderPath);
                FileInfo[] files = folderInfo.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".json")
                    {
                        resDataHolders.Add(LoadProfile(file.FullName));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex + " Error by loading all profiles from directory");
            }

            List<ShortCutProfile> res = new List<ShortCutProfile>();

            foreach (var data in resDataHolders)
            {
                try
                {
                    res.Add(new ShortCutProfile(data));
                }
                catch { }
            }

            return res;
        }

        public static ShortCutProfileDataHolder LoadProfile(string fullFileName)
        {
            try
            {
                string res = File.ReadAllText(fullFileName);
                ShortCutProfileDataHolder data = JsonConvert.DeserializeObject<ShortCutProfileDataHolder>(res, json_settings);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex + " Error by loading profile");
            }
        }
    }
}
