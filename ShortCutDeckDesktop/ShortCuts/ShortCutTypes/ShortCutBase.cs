using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.ShortCuts.ShortCutTypes
{
    public class ShortCutBase
    {
        public ShortCutBase() { }

        public virtual void shortCutTriggered(List<string> additionalData)
        {
            Logger.logServerMsg("shortcut activated");
        }

        public virtual ShortCutBaseDataHolder getDataHolder()
        {
            return new ShortCutBaseDataHolder();
        }
    }

    public class ShortCutBaseDataHolder
    {}
}
