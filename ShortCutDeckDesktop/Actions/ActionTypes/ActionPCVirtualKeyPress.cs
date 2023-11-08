using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ShortCutDeckDesktop.Actions.ActionTypes
{
    public class ActionPCVirtualKeyPress:ActionBase
    {
        private byte _keyCode;
        public ActionPCVirtualKeyPress(byte keyCode)
        {
            _keyCode = keyCode;
        }
        public override void executeAction()
        {
            base.executeAction();
            keybd_event(_keyCode, 0, 0, 0);
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public override ActionPCVirtualKeyPressedDataHolder GetDataHolder()
        {
            var a = new ActionPCVirtualKeyPressedDataHolder(_keyCode);
            return a;
        }
    }

    public class ActionPCVirtualKeyPressedDataHolder:ActionBaseDataHolder
    {
        public byte keyCode;

        public ActionPCVirtualKeyPressedDataHolder(byte keyCode)
        {
            this.keyCode = keyCode;
        }
    }
}
