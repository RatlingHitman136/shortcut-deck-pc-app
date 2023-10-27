﻿using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts
{
    public class ShortCutProfile
    {
        private List<(ShortCutBase, GridPos)> _shortCuts;
        //public List<(ShortCutBase, GridPos)> ShortCuts { get => _shortCuts; }

        private  string _id;
        public string Id { get => _id; }

        private string _name;
        public string Name { get => _name; }
        
        private int _size_X;
        private int _size_Y;
        public int Size_X { get => _size_X; }
        public int Size_Y { get => _size_X; }


        public ShortCutProfile(string id, string name)
        {
            _shortCuts = new List<(ShortCutBase, GridPos)>();
            _id = id;
            _name = name;
            _size_X = 4;
            _size_Y = 6;
        }
        public ShortCutProfile(string id, string name, List<(ShortCutBase, GridPos)> shortCuts)
        {
            _shortCuts = shortCuts;
            _id = id;
            _name = name;
            _size_X = 4;
            _size_Y = 6;
        }
        public List<(ShortCutBase, GridPos)> getShortCutsInRightOrder()
        {
            List<(ShortCutBase, GridPos)> shortCutsInRightOrder = new List<(ShortCutBase, GridPos)>();

            for(int y = 0; y < ShortCutProfileManager.GridHeight; y++)
            {
                for(int x = 0; x < ShortCutProfileManager.GridWidth; x++)
                { 
                    GridPos curPos = new GridPos(x, y);
                    var selected = _shortCuts.FindAll(item => item.Item2.Equals(curPos));
                    if (selected.Count > 0)
                    {
                        shortCutsInRightOrder.Add(selected[0]);
                    }
                    else //nothing was found at position

                    {
                        shortCutsInRightOrder.Add((new ShortCutBase(), curPos));
                    }
                }
            }
            return shortCutsInRightOrder;
        }
        public bool TryGetShortCutByGridPos(GridPos pos, out ShortCutBase shortCut)
        {
            shortCut = _shortCuts.Find(x => x.Item2.Equals(pos)).Item1;
            return shortCut!= null;
        }

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

            public override bool Equals(object? obj)
            {
                return obj is GridPos pos &&
                       _x == pos._x &&
                       _y == pos._y;
            }
        }
    }
}
