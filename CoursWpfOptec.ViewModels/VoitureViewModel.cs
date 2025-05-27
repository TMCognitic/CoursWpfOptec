using CoursWpfOptec.Models.Entities;
using CoursWpfOptec.ViewModels.Messages;
using CoursWpfOptec.ViewModels.Repositories;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Messenger;
using Tools.Mvvm.ViewModels;

namespace CoursWpfOptec.ViewModels
{
    public class VoitureViewModel : EntityViewModel<Voiture>
    {
        private readonly IPopupRepository _popupRepository;
        private RelayCommand? _deleteCommand;
        private RelayCommand? _showCommand;

        public string Plaque { get { return Entity.Plaque; } }

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand(() => Mediator<DeleteStringViewModelMessage>.Instance.Send(this, new DeleteStringViewModelMessage(this)));
            }
        }

        public RelayCommand ShowCommand
        {
            get
            {
                return _showCommand ??= new RelayCommand(() => _popupRepository.Display(this));
            }
        }

        public VoitureViewModel(Voiture entity) : base(entity)
        {
            _popupRepository = (IPopupRepository)ServiceProvider.GetService(typeof(IPopupRepository))!;
        }
    }
}
