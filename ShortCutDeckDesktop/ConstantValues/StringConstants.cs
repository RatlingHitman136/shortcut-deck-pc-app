using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ConstantValues
{
    public static class StringConstants
    {
        public const string FIRST_LEVEL_SPLIT_CHARACTER = "/";
        public const string THIRD_LEVEL_SPLIT_CHARACTER = " ";
        public const string SECOND_LEVEL_SPLIT_CHARACTER = ":";

        public const string SHORT_CUT_BUTTON_TAG = "b";
        public const string SHORT_CUT_EMPTY_TAG = "e";

        public const string ACTION_SCAN_TAG = "scan";
        public const string ACTION_REQUEST_ALL_PROFILES_TAG = "reqAllProf";
        public const string ACTION_SEND_PROFILE_TAG = "setP";
        public const string ACTION_SHORTCUT_TRIGGERED = "shortCutTrig";

        public const string PROFILE_SAVE_PATH = @"profiles\";

        public const string SHORT_CUT_DEFAULT_ICON_ID = "shortCut-Def";
        public const string SHORT_CUT_ICONS_JSON_PATH = "ShortCutDeckDesktop.Resources.Json.ShortCutIconsDictionary.json";
        public const string SHORT_CUT_ICONS_PACK_URL = "pack://application:,,,/ShortCutDeckDesktop;";
        public const string SHORT_CUT_ICONS_ABSOLUTE_PATH = @"ShortCutDeckDesktop\Resources\Icons\ShortCutIcons\";
    }
}
