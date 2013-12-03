using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using MyReactiveUI.StreamingData;

namespace MyReactiveUI
{
    public class MainWindowViewModel : ReactiveObject
    {
        public readonly Guid ID = Guid.NewGuid();

        public MainWindowViewModel()
        {
            this._content = new StreamingDataViewModel(new DataFeed());
        }


        private ReactiveObject _content;
        public ReactiveObject Content 
        {
            get { return this._content; }
            private set
            {
                this.RaiseAndSetIfChanged(ref _content, value);
            }
        }
    }
}
