using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.APP.UI.App_Core;
using TM.APP.UI.Interfaces;

namespace TM.APP.UI.Services
{



    public class NaviService : ObservableObject, INaviService
    {
        private readonly Func<Type, ViewModel> _viewModelFactory;

        private  ViewModel _currentView;

        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NaviService(Func<Type,ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }


        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
            
        }
    }
}
