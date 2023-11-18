using ShortCutDeckDesktop.Actions;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutFactory
    {
        public static ShortCutBase createShortCutFromDataHolder(ShortCutBaseDataHolder dataHolder)
        {
            switch (dataHolder)
            {
                case ShortCutButtonDataHolder convertedDataHolder:
                    ActionBase buttonAction = ActionFactory.createActionFromDataHolder(convertedDataHolder.shortCutActionData);
                    ShortCutButton button = new ShortCutButton(buttonAction);
                    return button;

                default:
                    throw new NotImplementedException("ShortCutFactory for " + dataHolder.ToString() + " is not implemented yet!");
            }
        }
    }
}
