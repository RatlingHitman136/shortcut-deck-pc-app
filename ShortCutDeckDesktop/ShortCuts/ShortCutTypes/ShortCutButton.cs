using ShortCutDeckDesktop.Actions.ActionTypes;
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
        public ShortCutButton() : base()
        {
            _shortCutAction = new ActionBase();
        }

        public ShortCutButton(ActionBase action) : base()
        {
            _shortCutAction = action;
        }

        public override void ShortCutTriggered(List<string> additionalData)
        {
            _shortCutAction.executeAction();
        }
    }
}
