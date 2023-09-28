﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions.ActionTypes.ShortCutActions
{
    internal class ActionPCMediaPausePlay : ActionBase
    {
        public override void executeAction()
        {
            base.executeAction();
            keybd_event(VirtualKeysConstants.VK_MEDIA_PLAY_PAUSE, 0, 0, 0);
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    }
}
