using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers
{
    internal class ShortCutButtonPreviewerViewModel : ShortCutPreviewerBaseViewModel
    {

        internal new ShortCutButtonDataHolder _dataHolder;

        //TODO only for test!!!
        public string ShortcutName { get => (_dataHolder.shortCutActionData as ActionPCVirtualKeyPressedDataHolder)?.keyCode.ToString(); }

        public ShortCutButtonPreviewerViewModel(ShortCutButtonDataHolder shortCutButtonDataHolder) : base(1, 1, shortCutButtonDataHolder)
        { 
            _dataHolder = shortCutButtonDataHolder;
        }

        public override void UpdateProperties(object? sender, PropertyChangedEventArgs e)
        {
            base.UpdateProperties(sender, e);
            OnPropertyChanged(nameof(ShortcutName));
        }
    }
}
