using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public static class ShortCutProfileManager
    {
        private static List<ShortCutProfile> _profiles = new List<ShortCutProfile>();

        public static List<ShortCutProfile> Profiles { get => _profiles; }
    }
}
