using ShortCutDeckDesktop.Actions;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors;
using ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ShortCutPreviewers;
using ShortCutDeckDesktop.ShortCuts;
using ShortCutDeckDesktop.ShortCuts.ShortCutTypes;
using System;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels
{
    internal static class ShortCutPreviewViewModelFactory
    {
        public static ShortCutPreviewerBaseViewModel CreatePreviewViewModelFromDataHolder(ShortCutBaseDataHolder data)
        {
            switch(data)
            {
                case ShortCutButtonDataHolder shortCutButtonDataHolder:
                    return new ShortCutButtonPreviewerViewModel(data.posX, data.posY, shortCutButtonDataHolder);
            }
            
            throw new NotImplementedException("View Model for the " + data.ToString() + "Data Holder class is not implemented");
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
