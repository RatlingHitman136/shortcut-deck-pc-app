using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortCutDeckDesktop.Constants;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using static ShortCutDeckDesktop.ShortCuts.ShortCutProfile;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutProfileConverter
    {
        // setprof/0            /b:0 0/b:0 1/e/b:0 3 .....
        // setP   /index of Prof/data of profile

        //result from this factory = b:0 0/b:0 1/e/b:0 3 .....  

        public static string ParseProfileToString(ShortCutProfile profile)
        {
            string res = "";

            List<ShortCutTypes.ShortCutBase> list = profile.GetShortCutsInRightOrder();

            for (int i = 0; i < list.Count; i++)
            {
                ShortCutTypes.ShortCutBase item = list[i];
                switch (item)
                {
                    case ShortCutTypes.ShortCutButton:
                        res += StringConstants.SHORT_CUT_BUTTON_TAG +
                            StringConstants.SECOND_LEVEL_SPLIT_CHARACTER +
                            item.PosX.ToString() +
                            StringConstants.THIRD_LEVEL_SPLIT_CHARACTER +
                            item.PosY.ToString();
                        break;
                    case ShortCutTypes.ShortCutBase:
                        res += StringConstants.SHORT_CUT_EMPTY_TAG;
                        break;
                }
                if (i != list.Count - 1)
                    res += StringConstants.FIRST_LEVEL_SPLIT_CHARACTER;
            }

            return res;
        }

        public static (int x, int y, List<string> additionalData) ParseDataFromTriggeredShortCut(string msg)
        {
            try
            {
                List<string> data = msg.Trim().Split(StringConstants.SECOND_LEVEL_SPLIT_CHARACTER).ToList();
                List<string> posData = data[0].Split(StringConstants.THIRD_LEVEL_SPLIT_CHARACTER).ToList();
                data.RemoveAt(0);
                return (Convert.ToInt32(posData[0]), Convert.ToInt32(posData[1]), data);
            }
            catch (Exception e)
            {
                throw new Exception("Exception at getting data from msg, that server recieved from client", e);
            }
            
        }
    }
}
