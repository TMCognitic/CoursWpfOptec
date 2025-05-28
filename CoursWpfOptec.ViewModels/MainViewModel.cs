using CoursWpfOptec.Models.Commands;
using CoursWpfOptec.Models.Commands.Voitures;
using CoursWpfOptec.Models.Entities;
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
        private ObservableCollection<VoitureViewModel> _items;

        public MainViewModel()
        {
            _repository = (IVoitureRepository)ServiceProvider!.GetService(typeof(IVoitureRepository))!;
            Mediator<DeleteStringViewModelMessage>.Instance.Register(OnDeleteStringViewModel);

            _items = new ObservableCollection<VoitureViewModel>();
            Task.Run(LoadItems);
        }

        async Task LoadItems()
        {
            await Task.Delay(5000);
            IEnumerable<Voiture> voitures = await _repository.ExecuteAsync(new GetAllCarsQuery());

            foreach (Voiture voiture in voitures)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _items.Add(new VoitureViewModel(voiture));
                });
            }
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

        public ObservableCollection<VoitureViewModel> Items
        {
            get
            {
                return _items;
            }
        }

        private void Add()
        {
            Task.Run(async () => {
                Voiture voiture = await _repository.ExecuteAsync(new AddCarCommand(Texte!));
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Items.Add(new VoitureViewModel(voiture));
                    Texte = null;
                });
            });

            //Items.Add(new VoitureViewModel(Texte!));
            
        }

        private bool CanAdd()
        {
            return !string.IsNullOrWhiteSpace(Texte);
        }
    }
}
