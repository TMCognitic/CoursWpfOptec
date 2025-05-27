using CoursWpfOptec.ViewModels.Messages;
using System.Collections.ObjectModel;
using System.Windows;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Extensions;
using Tools.Mvvm.Messenger;
using Tools.Mvvm.ViewModels;

namespace CoursWpfOptec.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private RelayCommand? _addCommand;

        private string? _texte;

        public string? Texte
        {
            get
            {
                return _texte;
            }

            set
            {
                Set(ref _texte, value);
            }
        }

        public ObservableCollection<StringViewModel> Items { get; }

        public MainViewModel()
        {
            
            Mediator<DeleteStringViewModelMessage>.Instance.Register(OnDeleteStringViewModel);
            Items = new ObservableCollection<StringViewModel>() { new StringViewModel("Value 1"), new StringViewModel("Value 2") };
        }

        private void OnDeleteStringViewModel(object sender, DeleteStringViewModelMessage message)
        {
            Items.Remove(message.ViewModel);
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(Add, CanAdd);
            }
        }

        private void Add()
        {
            Items.Add(new StringViewModel(Texte!));
            Texte = null;
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Texte);
        }
    }
}
