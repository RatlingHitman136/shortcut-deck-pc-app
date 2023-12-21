using ShortCutDeckDesktop.Actions;
using ShortCutDeckDesktop.ConstantValues;
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

        private string _iconId;


        public ShortCutButton(int posX, int posY, string iconId = "") : base(posX, posY)
        {
            _shortCutAction = new ActionBase();
            _iconId = iconId;
        }

        public ShortCutButton(ActionBase action, int posX, int posY, string iconId = "") : base(posX, posY)
        {
            _shortCutAction = action;
            _iconId = iconId;
        }

        public override void ShortCutTriggered(List<string> additionalData)
        {
            _shortCutAction.ExecuteAction();
        }

        public override ShortCutButtonDataHolder GetDataHolder()
        {
            var a = new ShortCutButtonDataHolder(_shortCutAction.GetDataHolder(), _iconId, _posX, _posY);
            return a;
        }
    }

    [Serializable]
    public class ShortCutButtonDataHolder : ShortCutBaseDataHolder
    {
        public ActionBaseDataHolder shortCutActionData;
        public string iconId;

        public ShortCutButtonDataHolder(ActionBaseDataHolder shortCutActionData, string iconId, int posX, int posY) : base(posX, posY)
        {
            this.shortCutActionData = shortCutActionData;
            this.iconId = iconId;
        }
    }
}
