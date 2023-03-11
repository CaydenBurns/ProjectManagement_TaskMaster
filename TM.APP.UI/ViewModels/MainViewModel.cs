using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Autofac;
using DevExpress.Xpf.WindowsUI.Navigation;
using TM.DotNet.Entities;
using TM.DotNet.Models;
using TM.APP.UI.Views;
using TM.APP.UI.App_Core;
using TM.APP.UI.Interfaces;

namespace TM.APP.UI.ViewModels
{
    [POCOViewModel]
    public partial class MainViewModel : ViewModel
    {
        //private readonly TmDbContext _tmDbContext;
        private INaviService _navigation;

        public INaviService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                 OnPropertyChanged();
            }
        }


        public RelayCommand NavigateHomeCommand { get; set; }
        public RelayCommand NavigateUsersCommand { get; set; }
       



        public MainViewModel(INaviService navService)
        {
           
            //_tmDbContext = dbContext;
            Navigation = navService;
            NavigateHomeCommand = new RelayCommand(o => {Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateUsersCommand = new RelayCommand(o => {Navigation.NavigateTo<UserViewModel>(); }, o => true);

        }
    }
}