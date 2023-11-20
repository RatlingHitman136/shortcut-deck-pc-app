using ShortCutDeckDesktop.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts.ShortCutTypes
{
    public class ShortCutButton : ShortCutBase
    {
        private ActionBase _shortCutAction;
        public ShortCutButton(int posX, int posY) : base(posX, posY)
        {
            _shortCutAction = new ActionBase();
        }

        public ShortCutButton(ActionBase action, int posX, int posY) : base(posX, posY)
        {
            _shortCutAction = action;
        }

        public override void shortCutTriggered(List<string> additionalData)
        {
            _shortCutAction.executeAction();
        }

        public override ShortCutButtonDataHolder getDataHolder()
        {
            var a = new ShortCutButtonDataHolder(_shortCutAction.getDataHolder(), _posX, _posY);
            return a;
        }
    }

    public class ShortCutButtonDataHolder : ShortCutBaseDataHolder
    {
        public ActionBaseDataHolder shortCutActionData;

        public ShortCutButtonDataHolder(ActionBaseDataHolder shortCutActionData, int posX, int posY) : base(posX, posY)
        {
            this.shortCutActionData = shortCutActionData;
        }
    }
}
