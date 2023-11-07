using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal static class ShortCutViewModelFactory
    {
        public static ShortCutPreviewerBaseViewModel CreatePreviewViewModelFromDataHolder((ShortCutBaseDataHolder, ShortCutProfile.GridPos) data)
        {
            switch(data.Item1)
            {
                case ShortCutButtonDataHolder shortCutButtonDataHolder:
                    return new ShortCutButtonPreviewerViewModel(data.Item2.X, data.Item2.Y, shortCutButtonDataHolder);
            }
            
            throw new NotImplementedException("View Model for the " + data.Item1.ToString() + "Data Holder class is not implemented");
        }
    }
}
