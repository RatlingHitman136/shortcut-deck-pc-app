using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutFactory
    {
        // setprof/0            /b:0 0/b:0 1/e/b:0 3 .....
        // setP   /index of Prof/data of profile

        //result from this factory = b:0 0/b:0 1/e/b:0 3 .....  

        public static string ShortCutProfileToStringForClient(ShortCutProfile profile)
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
    }
}
