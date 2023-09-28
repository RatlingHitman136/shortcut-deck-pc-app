﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions.ActionTypes
{
    internal class ActionPCVirtualKeyPressed:ActionBase
    {
        byte _keyCode;
        public ActionPCVirtualKeyPressed(byte keyCode)
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
    }
}