using CoursWpfOptec.ViewModels.Messages;
using Tools.Mvvm.Commands;
using Tools.Mvvm.Messenger;
using Tools.Mvvm.ViewModels;

namespace CoursWpfOptec.ViewModels
{
    public class StringViewModel : EntityViewModel<string>
    {
        private RelayCommand? _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ??= new RelayCommand(() => { Mediator<DeleteStringViewModelMessage>.Instance.Send(this, new DeleteStringViewModelMessage(this)); } );
            }
        }

        public StringViewModel(string value) : base(value)
        {            
        }


    }
}
