using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShortCutDeckDesktop.Actions.ActionTypes;
using ShortCutDeckDesktop.DataLoaders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ShortCutDeckDesktop.MVVM.ShortCutProfileEditor.ViewModels.ActionEditors
{
    internal class ActoinPCVirtualKeyPressEditorViewModel : ActionBaseEditorViewModel
    {
        private ActionPCVirtualKeyPressedDataHolder _actionDataHolder;

        private ICommand _selectionChangedCommand;

        private PCVirtualKeyDefaultOptionsViewModel _selectedItem;

        private ObservableCollection<PCVirtualKeyDefaultOptionsViewModel> _items;


        public ICommand SelectionChangedCommand
        {
            get
            {
                if (_selectionChangedCommand is null)
                    _selectionChangedCommand = new RelayCommand<object?>(SelectionChanged);
                return _selectionChangedCommand;
            }
        }
        public ObservableCollection<PCVirtualKeyDefaultOptionsViewModel> Items { get => _items; }
        public PCVirtualKeyDefaultOptionsViewModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                if (_actionDataHolder.keyCode != _selectedItem.Data.value)
                    _actionDataHolder.keyCode = SelectedItem.Data.value;

                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        internal ActoinPCVirtualKeyPressEditorViewModel(ActionPCVirtualKeyPressedDataHolder actionDataHolder) : base()
        {
            _actionDataHolder = actionDataHolder;
            _items = new ObservableCollection<PCVirtualKeyDefaultOptionsViewModel>();
            PCVirtualKeyDefaultOptionsLoader.GetData().loadedData.ForEach(x => _items.Add(new(x)));

            foreach(var item in _items)
            {

                if (item.Data.value == _actionDataHolder.keyCode)
                    _selectedItem = item;
            }
        }

        public void SelectionChanged(object? o)
        {
            var e = o as SelectionChangedEventArgs;
        }
    }

    public class PCVirtualKeyDefaultOptionsViewModel : ObservableObject
    {
        private PCVirtualKeyDefaultOptionsLoader.DefaultOptionData _data;

        public PCVirtualKeyDefaultOptionsViewModel(PCVirtualKeyDefaultOptionsLoader.DefaultOptionData data)
        {
            _data = data;
        }

        public string Name { get => _data.name; }
        public PCVirtualKeyDefaultOptionsLoader.DefaultOptionData Data { get => _data; }
    }
}
