using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfOptec.ViewModels.Messages
{
    internal class DeleteStringViewModelMessage
    {
        public StringViewModel ViewModel { get; }

        public DeleteStringViewModelMessage(StringViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
