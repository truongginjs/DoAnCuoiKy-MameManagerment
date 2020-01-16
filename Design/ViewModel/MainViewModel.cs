using Design.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Design.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
        public ICommand ButtonCommand { get; set; }
        public MainViewModel()
        {
            ButtonCommand = new RelayCommand<object>(p => true , p => { });
        }

    }
}
