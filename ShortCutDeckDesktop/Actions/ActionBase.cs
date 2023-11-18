using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.Actions
{
    public class ActionBase
    {
        public ActionBase() { }

        public virtual void executeAction() { }

        public virtual ActionBaseDataHolder getDataHolder()
        {
            return new ActionBaseDataHolder();
        }
    }

    public class ActionBaseDataHolder 
    {}
}
