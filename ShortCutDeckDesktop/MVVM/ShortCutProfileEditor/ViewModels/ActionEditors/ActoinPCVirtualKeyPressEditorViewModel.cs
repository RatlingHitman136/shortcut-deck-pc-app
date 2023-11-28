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

        #region  changable properties
        private string keyCode;
        #endregion

        internal ActoinPCVirtualKeyPressEditorViewModel(ActionPCVirtualKeyPressedDataHolder actionDataHolder) : base()
        {
            _actionDataHolder = actionDataHolder;
            keyCode = actionDataHolder.keyCode.ToString();
            _defVals = new ObservableCollection<string>();
            PCVirtualKeyDefaultOptionsLoader.GetData().loadedData.ForEach(x => _defVals.Add(x.name));
        }

        public ActionPCVirtualKeyPressedDataHolder ActionDataHolder { get => _actionDataHolder; }
        public string KeyCode {
            get => keyCode;
            set
            {
                keyCode = value;
                TryApplyChanges();
            }
        }

        public void TryApplyChanges()
        {
            try
            {
                _actionDataHolder.keyCode = Convert.ToByte(keyCode);
                OnPropertyChanged();
            }
            catch
            { }
        }
    }
}
