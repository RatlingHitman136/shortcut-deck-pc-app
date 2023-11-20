using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts.ShortCutTypes
{
    public class ShortCutBase
    {
        protected int _posX;
        protected int _posY;

        public int PosX { get => _posX;}
        public int PosY { get => _posY; }

        public ShortCutBase(int  posX, int posY) 
        {
            _posX = posX;
            _posY = posY;
        }

        public virtual void ShortCutTriggered(List<string> additionalData)
        {
            Logger.logServerMsg("shortcut activated");
        }

        public virtual ShortCutBaseDataHolder GetDataHolder()
        {
            return new ShortCutBaseDataHolder(_posX, _posY);
        }
    }

    public class ShortCutBaseDataHolder
    {
        public int posX;
        public int posY;

        public ShortCutBaseDataHolder(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }
    }
}
