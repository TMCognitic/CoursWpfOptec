using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfOptec.ViewModels.Messages
{
    internal class DeleteStringViewModelMessage
    {
        public VoitureViewModel ViewModel { get; }

        public DeleteStringViewModelMessage(VoitureViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
