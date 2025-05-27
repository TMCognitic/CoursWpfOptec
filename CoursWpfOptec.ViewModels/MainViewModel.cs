using CoursWpfOptec.Models.Queries.Voitures;
using CoursWpfOptec.Models.Repositories;
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
        private readonly IVoitureRepository _repository;

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

        public ObservableCollection<VoitureViewModel> Items { get; }

        public MainViewModel()
        {
            _repository = (IVoitureRepository)ServiceProvider!.GetService(typeof(IVoitureRepository))!;
            Mediator<DeleteStringViewModelMessage>.Instance.Register(OnDeleteStringViewModel);
            Items = new ObservableCollection<VoitureViewModel>(_repository.Execute(new GetAllCarsQuery()).Select(v => new VoitureViewModel(v)));
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

            //Items.Add(new VoitureViewModel(Texte!));
            Texte = null;
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Texte);
        }
    }
}
