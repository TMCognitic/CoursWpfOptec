using CoursWpfOptec.ViewModels;
using CoursWpfOptec.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursWpfOptec
{
    internal class Displayer : IPopupRepository
    {
        public void Display(VoitureViewModel viewModel)
        {
            Popup popup = new Popup();
            popup.DataContext = viewModel;
            popup.ShowDialog();
        }
    }
}
