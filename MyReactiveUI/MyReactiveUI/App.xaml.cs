using MyReactiveUI.StreamingData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyReactiveUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var r = RxApp.MutableResolver;
            r.Register(() => new StreamingDataView(), typeof(IViewFor<StreamingDataViewModel>));
        }
    }
}
