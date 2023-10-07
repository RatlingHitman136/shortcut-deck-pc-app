using ShortCutDeckDesktop.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShortCutDeckDesktop.ShortCuts.ShortCutProfile;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutFactory
    {
        // setprof/0            /b:0 0/b:0 1/e/b:0 3 .....
        // setP   /index of Prof/data of profile

        //result from this factory = b:0 0/b:0 1/e/b:0 3 .....  

        public static string GetStringFromShortCutProfileForClient(ShortCutProfile profile)
        {
            string res = "";

            List<(ShortCutTypes.ShortCutBase, ShortCutProfile.GridPos)> list = profile.getShortCutsInRightOrder();

            for (int i = 0; i < list.Count; i++)
            {
                (ShortCutTypes.ShortCutBase, ShortCutProfile.GridPos) item = list[i];
                switch (item.Item1)
                {
                    case ShortCutTypes.ShortCutButton:
                        res += StringConstants.SHORT_CUT_BUTTON_TAG +
                            StringConstants.SECOND_LEVEL_SPLIT_CHARACTER +
                            item.Item2.X.ToString() +
                            StringConstants.THIRD_LEVEL_SPLIT_CHARACTER +
                            item.Item2.Y.ToString();
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

        public static (GridPos pos, List<string> additionalData) GetDataFromTriggeredShortCut(string msg)
        {
            try
            {
                List<string> data = msg.Trim().Split(StringConstants.SECOND_LEVEL_SPLIT_CHARACTER).ToList();
                List<string> posData = data[0].Split(StringConstants.THIRD_LEVEL_SPLIT_CHARACTER).ToList();
                data.RemoveAt(0);
                GridPos pos = new GridPos(Convert.ToInt32(posData[0]), Convert.ToInt32(posData[1]));
                return (pos, data);
            }
            catch (Exception e)
            {
                throw new Exception("Exception at getting data from msg, that server recieved from client", e);
            }
            
        }
    }
}
