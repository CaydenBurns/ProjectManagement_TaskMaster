using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.APP.UI.App_Core;

namespace TM.APP.UI.Interfaces
{
    public interface INaviService
    {
        ViewModel CurrentView { get; }

        void NavigateTo<T>() where T : ViewModel;
    }
}
