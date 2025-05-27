using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tools.Mvvm.Commands;

namespace Tools.Mvvm.ViewModels
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        public ObservableObject()
        {
            IEnumerable<RelayCommand> commands = this.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(RelayCommand) && p.CanRead)
                .Select(p => (RelayCommand)p.GetMethod!.Invoke(this, null)!);

            foreach (RelayCommand command in commands)
            {
                PropertyChanged += (s, e) => command.RaiseCanExecuteChanged();
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
