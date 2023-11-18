using ShortCutDeckDesktop.Actions;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal static class ShortCutEditorViewModelFactory
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

        public static ActionBaseEditorViewModel CreateActionEditorViewModelFromShortCutDataHolder(ShortCutBaseDataHolder shortCutBaseDataHolder)
        {
            switch(shortCutBaseDataHolder)
            {
                case ShortCutButtonDataHolder shortCutButtonDataHolder:
                    switch (shortCutButtonDataHolder.shortCutActionData)
                    {
                        case ActionPCVirtualKeyPressedDataHolder actionPCVirtualKeyPressDataHolder:
                            return new ActoinPCVirtualKeyPressEditorViewModel(actionPCVirtualKeyPressDataHolder);
                    }
                    throw new NotImplementedException("Action View Model for the " + shortCutBaseDataHolder.ToString() + " Data Holder class is not implemented");

            }

            throw new NotImplementedException("View Model for the " + shortCutBaseDataHolder.ToString() + " Data Holder class is not implemented");
        }
    }
}
