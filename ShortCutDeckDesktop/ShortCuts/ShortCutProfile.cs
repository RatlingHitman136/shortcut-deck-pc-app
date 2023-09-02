using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public class ShortCutProfile
    {
        // short cut, x coord, y coord
        private List<(ShortCutBase, GridPos)> _shortCuts;

        public ShortCutProfile() {
            _shortCuts = new List<(ShortCutBase, GridPos)>();
        }

        public List<(ShortCutBase, GridPos)> ShortCuts { get => _shortCuts; }

        public struct GridPos
        {
            private int _x;
            private int _y;

            public GridPos(int x, int y)
            {
                _x = x;
                _y = y;
            }

            public int X { get => _x;}
            public int Y { get => _y;}
        }
    }
}
