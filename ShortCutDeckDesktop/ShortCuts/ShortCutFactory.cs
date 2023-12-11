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
        public static ShortCutBase CreateShortCutFromDataHolder(ShortCutBaseDataHolder dataHolder)
        {
            switch (dataHolder)
            {
                case ShortCutButtonDataHolder convertedDataHolder:
                    ActionBase buttonAction = ActionFactory.CreateActionFromDataHolder(convertedDataHolder.shortCutActionData);
                    ShortCutButton button = new ShortCutButton(buttonAction, convertedDataHolder.posX, convertedDataHolder.posY, convertedDataHolder.iconId);
                    return button;

                default:
                    throw new NotImplementedException("ShortCutFactory for " + dataHolder.ToString() + " is not implemented yet!");
            }
        }
    }
}
