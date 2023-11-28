using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.DataLoaders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors
{
    internal class ActoinPCVirtualKeyPressEditorViewModel : ActionBaseEditorViewModel
    {
        private ActionPCVirtualKeyPressedDataHolder _actionDataHolder;

        private ObservableCollection<string> _defVals;

        public ObservableCollection<string> DefVals { get { return _defVals; } }


        internal ActoinPCVirtualKeyPressEditorViewModel(ActionPCVirtualKeyPressedDataHolder actionDataHolder) : base()
        {
            _actionDataHolder = actionDataHolder;
            _defVals = new ObservableCollection<string>();
            PCVirtualKeyDefaultOptionsLoader.GetData().loadedData.ForEach(x => _defVals.Add(x.name));
        }
    }
}
