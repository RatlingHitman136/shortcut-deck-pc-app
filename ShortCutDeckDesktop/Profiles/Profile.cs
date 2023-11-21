using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace ShortCutDeckDesktop.Profiles
{
    public class Profile
    {
        private List<ShortCutBase> _shortCuts;
        //public List<(ShortCutBase, GridPos)> ShortCuts { get => _shortCuts; }

        private string _id;
        public string Id { get => _id; }

        private string _name;
        public string Name { get => _name; }

        private int _size_X;
        private int _size_Y;
        public int Size_X { get => _size_X; }
        public int Size_Y { get => _size_X; }


        public Profile(string id, string name)
        {
            _shortCuts = new List<ShortCutBase>();
            _id = id;
            _name = name;
            _size_X = 4;
            _size_Y = 6;
        }
        public Profile(string id,
                               string name,
                               int size_X,
                               int size_Y,
                               List<ShortCutBase> shortCuts)
        {
            _shortCuts = shortCuts;
            _id = id;
            _name = name;
            _size_X = size_X;
            _size_Y = size_Y;
        }
        public Profile(ProfileDataHolder dataHolder)
        {
            _id = dataHolder.id;
            _name = dataHolder.name;
            _size_X = dataHolder.size_X;
            _size_Y = dataHolder.size_Y;
            _shortCuts = new List<ShortCutBase>();
            foreach (var shortCutData in dataHolder.shortCuts)
                _shortCuts.Add((ShortCutFactory.CreateShortCutFromDataHolder(shortCutData)));
        }


        public List<ShortCutBase> GetShortCutsInRightOrder()
        {
            List<ShortCutBase> shortCutsInRightOrder = new List<ShortCutBase>();

            for (int y = 0; y < ProfileManager.GridHeight; y++)
            {
                for (int x = 0; x < ProfileManager.GridWidth; x++)
                {
                    var selected = _shortCuts.FindAll(item => (item.PosX == x) && (item.PosY == y));
                    if (selected.Count > 0)
                    {
                        shortCutsInRightOrder.Add(selected[0]);
                    }
                    else //nothing was found at position
                    {
                        shortCutsInRightOrder.Add(new ShortCutBase(x, y));
                    }
                }
            }
            return shortCutsInRightOrder;
        }
        public bool TryGetShortCutByGridPos(int posX, int posY, out ShortCutBase shortCut)
        {
            shortCut = _shortCuts.Find(x => (x.PosX == posX) && (x.PosY == posY));
            return shortCut != null;
        }

        public ProfileDataHolder GetDataHolder()
        {
            List<ShortCutBaseDataHolder> dataHolders = new List<ShortCutBaseDataHolder>();

            foreach (var a in _shortCuts)
            {
                dataHolders.Add(a.GetDataHolder());
            }

            return new ProfileDataHolder(_id, _name, _size_X, _size_Y, dataHolders);
        }
    }

    [Serializable]
    public class ProfileDataHolder
    {
        public string id;
        public string name;
        public int size_X;
        public int size_Y;

        public ProfileDataHolder(string id, 
            string name, 
            int size_X, 
            int size_Y, 
            List<ShortCutBaseDataHolder> shortCuts)
        {
            this.id = id;
            this.name = name;
            this.size_X = size_X;
            this.size_Y = size_Y;
            this.shortCuts = shortCuts;
        }
    }
}
