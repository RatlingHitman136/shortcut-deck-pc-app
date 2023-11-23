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

        public virtual void ExecuteAction() { }

        public virtual ActionBaseDataHolder GetDataHolder()
        {
            return new ActionBaseDataHolder();
        }
    }

    [Serializable]
    public class ActionBaseDataHolder 
    {}
}
